using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SFML.Window;
using SFML.Graphics;
using PixelEngine.System;

namespace PixelEditor {
    public partial class Form1 : Form {
        /// <summary>
        /// Private Variables
        /// </summary>
        private static DrawingSurface RENDER_SURFACE;
        private static RenderWindow RENDER_WINDOW;
        private static SFML.Graphics.View VIEWPORT_UI_VIEW;
        private static string[] EditorDebugInfo;
        private ContextSettings settings;
        //private static string DATA_DIRECTORY;

        /// <summary>
        /// Public Variables
        /// </summary>
        public static EditorCamera VIEWPORT_CAMERA_VIEW;
        public static EditorGrid _grid;

        //public enum EditorToolEnum {DRAW}
        //public EditorToolEnum EditorToolMode = EditorToolEnum.DRAW;

        //World Vars
        public static SFML.Graphics.Color viewportBackgroundColor { get; set; }
        public static Vector2i mouseScreenPos;
        public static Vector2f mouseWorldPos;

        public Form1() {
            InitializeComponent();

            RENDER_SURFACE = new DrawingSurface();
            RENDER_SURFACE.Size = new System.Drawing.Size(1920, 1080);
            RENDER_SURFACE.Dock = DockStyle.Fill;

            Controls.Add(RENDER_SURFACE);
            RENDER_SURFACE.Location = new System.Drawing.Point(100, 100);
            RENDER_SURFACE.BringToFront();
            RENDER_SURFACE.Focus();

            //Load resources
            //DATA_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            //Init sfml
            settings.AntialiasingLevel = 16;
            RENDER_WINDOW = new RenderWindow(RENDER_SURFACE.Handle, settings);

            //Create the main viewport view
            VIEWPORT_CAMERA_VIEW = new EditorCamera(new FloatRect(0, 0, RENDER_SURFACE.Width, RENDER_SURFACE.Height));
            VIEWPORT_UI_VIEW = new SFML.Graphics.View(new FloatRect(0, 0, RENDER_SURFACE.Width, RENDER_SURFACE.Height));

            //Init editor debug info
            EditorDebugInfo = new string[1];
            this.FormClosed += new FormClosedEventHandler(OnEditorClose);
        }

        private void Form1_Load(object sender, EventArgs e) {
            //Intialize config data
            InitConfigData();

            //Intialize viewport data
            _grid = new EditorGrid();
            Console.WriteLine();
            EditorDebug _debug = new EditorDebug(new SFML.Graphics.Font(Directory.GetCurrentDirectory() + "/EditorResources/pixelmix.ttf"));
            Stopwatch deltaClock = new Stopwatch();
            TimeSpan _deltaTime = new TimeSpan();
            Stopwatch clock = new Stopwatch();

            float frames = 0;
            float fps = 0;

            clock.Start();
            while (Visible) {
                Application.DoEvents();
                RENDER_WINDOW.DispatchEvents();
                RENDER_WINDOW.Clear(viewportBackgroundColor);

                //Calculate deltaTime
                _deltaTime = deltaClock.Elapsed;
                deltaClock.Restart();
                Editor.deltaTime = _deltaTime.TotalSeconds;

                /////////////////////
                /// UPDATE
                /////////////////////
                pScene.Update();

                /////////////////////
                /// DRAW CAMERA VIEW
                /////////////////////
                RENDER_WINDOW.SetView(VIEWPORT_CAMERA_VIEW);

                //Update the camera
                VIEWPORT_CAMERA_VIEW.Update();

                //Get debug info
                mouseScreenPos = Mouse.GetPosition(RENDER_WINDOW);
                mouseWorldPos = RENDER_WINDOW.MapPixelToCoords(mouseScreenPos);

                //Draw the editor grid
                RENDER_WINDOW.Draw(_grid);

                //Do scene drawing and update
                pScene.Draw(RENDER_WINDOW, RenderStates.Default);

                ///////////////////
                /// DRAW UI CAMERA
                ///////////////////
                RENDER_WINDOW.SetView(VIEWPORT_UI_VIEW);

                //Update ui camera
                VIEWPORT_UI_VIEW.Size = new Vector2f(RENDER_SURFACE.Width, RENDER_SURFACE.Height);
                VIEWPORT_UI_VIEW.Center = new Vector2f(RENDER_SURFACE.Width / 2, RENDER_SURFACE.Height/2);

                //Draw debug information
                _debug.SetDebugInfo(0, "FPS: " + fps.ToString());
                _debug.SetDebugInfo(1, "Mouse Screen Position: " + mouseScreenPos);
                _debug.SetDebugInfo(2, "Mouse World Position: " + mouseWorldPos);
                RENDER_WINDOW.Draw(_debug);
                RENDER_WINDOW.Display();
                frames++;

                //Calculate FPS
                if (clock.Elapsed.Seconds > 0) {
                    fps = frames / clock.Elapsed.Seconds;
                    frames = 0;
                    clock.Restart();
                }
            }
        }

        private void InitConfigData() {
            if (Config.CommandExists("EditorViewportBackgroundColor")) {
                viewportBackgroundColor = Config.GetConfigColor("EditorViewportBackgroundColor");
            } else {
                viewportBackgroundColor = new SFML.Graphics.Color(36, 36, 36);
                //Save settings to config state
                Config.SetData("EditorViewportBackgroundColor", viewportBackgroundColor.ToString()); //Save the background color
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            EditorModals.OptionsModal optionsDialog = new EditorModals.OptionsModal();
            optionsDialog.ShowDialog();
        }

        public static DrawingSurface GetRenderSurface() {
            if (RENDER_SURFACE != null)
                return RENDER_SURFACE;
            else
                return null;
        }

        private static void OnEditorClose(object sender, FormClosedEventArgs args) {
            if (args.CloseReason == CloseReason.UserClosing || args.CloseReason == CloseReason.WindowsShutDown) {
                //Apply and save the config state only when the program is
                //shut down deliberately to avoid unexected I/O errors
                Config.ApplyConfigState();
                Config.SaveConfig();
            }
        }
    }

    public class DrawingSurface : Control {
        protected override void OnPaint(PaintEventArgs e) {
            //base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            //base.OnPaintBackground(e);
        }
        protected override void OnMouseDown(MouseEventArgs e) {
            Application.OpenForms[0].Focus();
        }
        protected override void OnMouseWheel(MouseEventArgs e) {
            float _z = 1 - (float)(e.Delta / 120) / 10;
            Form1.VIEWPORT_CAMERA_VIEW.SetZoomState(_z);
            base.OnMouseWheel(e);
        }
        protected override void OnSizeChanged(EventArgs e) {
            if (Form1.VIEWPORT_CAMERA_VIEW != null) {
                Form1.VIEWPORT_CAMERA_VIEW.Size = new Vector2f(this.Width, this.Height);
            }
            base.OnSizeChanged(e);
        }
    }

    /// <summary>
    /// Define the editor's grid
    /// </summary>
    public class EditorGrid : Drawable {
        RectangleShape[] _gridlines;
        public int gridFactorScale = 24;
        public int gridSize;
        private SFML.Graphics.Color gridColor;

        public EditorGrid() {
            gridSize = 100;
            gridColor = (Config.CommandExists("EditorViewportGridColor")) ? Config.GetConfigColor("EditorViewportGridColor") : new SFML.Graphics.Color(30, 30, 30);

            //Create the grid arrays
            _gridlines = new RectangleShape[gridSize * 2];

            ///
            ///Grid Lines
            ///
            for (int x = 0; x < _gridlines.Length; x++) {
                if (x % 2 != 0) {
                    ///X Coord
                    _gridlines[x] = new RectangleShape(new Vector2f(1, (gridFactorScale * 2) * (_gridlines.Length / 2 - 1)));
                    _gridlines[x].Position = new Vector2f(gridFactorScale * x, 0);
                } else {
                    ///Y Coord
                    _gridlines[x] = new RectangleShape(new Vector2f((gridFactorScale * 2) * (_gridlines.Length/2 - 1), 1));
                    _gridlines[x].Position = new Vector2f(25, gridFactorScale * x);
                }
                //Set the grid color
                _gridlines[x].FillColor = gridColor;
            }
        }

        public void Draw(RenderTarget target, RenderStates states) {
            for (int x = 0; x < _gridlines.GetLength(0); x++) {
                target.Draw(_gridlines[x]);
            }
        }
        public void SetGridColor(SFML.Graphics.Color color) {
            gridColor = color;
            ApplySettingsCallback();
        }

        public SFML.Graphics.Color GetGridColor() {
                return gridColor;
        }

        private void ApplySettingsCallback() {
            foreach (RectangleShape line in _gridlines) {
                line.FillColor = gridColor;
            }
        }
    }

    /// <summary>
    /// Define editor debug info
    /// </summary>
    public class EditorDebug : Drawable {
        private Text[] DEBUG_INFO;
        private SFML.Graphics.Font EditorFont;
        private SFML.Graphics.Color TextColor = SFML.Graphics.Color.White;

        public EditorDebug(SFML.Graphics.Font SystemFont) {
            //Init debug info
            DEBUG_INFO = new Text[5]{
                new Text("", SystemFont),
                new Text("", SystemFont),
                new Text("", SystemFont),
                new Text("", SystemFont),
                new Text("", SystemFont)
            };
            EditorFont = SystemFont;

            TextPropertiesCallback();
        }

        public void Draw(RenderTarget target, RenderStates states) {
            for (int i = 0; i < DEBUG_INFO.Length; i++) {
                target.Draw(DEBUG_INFO[i]);
            }
        }

        public void SetDebugInfo(int index, string message) {
            if (DEBUG_INFO != null && message != "") {
                DEBUG_INFO[index].DisplayedString = message;
            }
        }

        public void SetTextColor(SFML.Graphics.Color newColor) {
            TextColor = newColor;
            TextPropertiesCallback();
        }

        private void TextPropertiesCallback() {
            for (int i = 0; i < DEBUG_INFO.Length; i++) {
                DEBUG_INFO[i].CharacterSize = 8;
                DEBUG_INFO[i].Position = new Vector2f(5, 5 + (16 * i));
                DEBUG_INFO[i].Color = TextColor;
            }
        }
    }
}