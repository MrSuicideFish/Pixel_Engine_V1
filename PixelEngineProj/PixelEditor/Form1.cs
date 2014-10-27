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
using SFML.Window;
using SFML.Graphics;
using PixelEngineProj;

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

        /// <summary>
        /// Public Variables
        /// </summary>
        public static EditorCamera VIEWPORT_CAMERA_VIEW;
        public static EditorGrid _grid;

        //public enum EditorToolEnum {DRAW}
        //public EditorToolEnum EditorToolMode = EditorToolEnum.DRAW;

        //World Vars
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

            //Init sfml
            settings.AntialiasingLevel = 16;
            RENDER_WINDOW = new RenderWindow(RENDER_SURFACE.Handle, settings);

            //Create the main viewport view
            VIEWPORT_CAMERA_VIEW = new EditorCamera(new FloatRect(0, 0, RENDER_SURFACE.Width, RENDER_SURFACE.Height));
            VIEWPORT_UI_VIEW = new SFML.Graphics.View(new FloatRect(0, 0, RENDER_SURFACE.Width, RENDER_SURFACE.Height));

            //Init editor debug info
            EditorDebugInfo = new string[1];
        }

        private void Form1_Load(object sender, EventArgs e) {
            _grid = new EditorGrid();
            EditorDebug _debug = new EditorDebug(new SFML.Graphics.Font("EditorResources/pixelmix.ttf"));
            Stopwatch deltaClock = new Stopwatch();
            TimeSpan _deltaTime = new TimeSpan();
            Stopwatch clock = new Stopwatch();

            float frames = 0;
            float fps = 0;

            clock.Start();
            while (Visible) {
                Application.DoEvents();
                RENDER_WINDOW.DispatchEvents();
                RENDER_WINDOW.Clear(new SFML.Graphics.Color(143, 242, 255));

                //Calculate deltaTime
                _deltaTime = deltaClock.Elapsed;
                deltaClock.Restart();
                Program.deltaTime = _deltaTime.TotalSeconds;

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
                Program.SCENE.Update();
                Program.SCENE.Draw(RENDER_WINDOW, RenderStates.Default);

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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            EditorModals.OptionsModal optionsDialog = new EditorModals.OptionsModal();
            optionsDialog.ShowDialog();
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
            Form1.VIEWPORT_CAMERA_VIEW.Zoom(_z);
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
        public SFML.Graphics.Color gridColor;

        public EditorGrid() {
            gridSize = 100;
            gridColor = new SFML.Graphics.Color(30, 30, 30);

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

    public class EditorCamera : SFML.Graphics.View {
        public float cameraSpeed = 200;
        public int turbo = 1;
        public EditorCamera(FloatRect viewRect) : base(viewRect) { }

        /// <summary>
        /// PRIVATE VARIABLES
        /// </summary>
        private bool bMoving = false;

        Vector2i initMousePos;
        Vector2i curMousePos;
        Vector2f initCenter;
        public void Update() {
            turbo = !SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.LShift) ? 1 : 3;
            
            if (SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Middle)) {
                if (!bMoving) {
                    //Get the initial mouse world position
                    initMousePos = Form1.mouseScreenPos;
                    initCenter = Center;
                    bMoving = true;
                } else {
                    //Get the current mouse world position
                    curMousePos = Form1.mouseScreenPos;
                }
                //add the difference to the camera world position
                Vector2f newPos = new Vector2f(curMousePos.X, curMousePos.Y) - new Vector2f(initMousePos.X, initMousePos.Y);
                Center = initCenter + -newPos;

            }else if(!SFML.Window.Mouse.IsButtonPressed(Mouse.Button.Middle)){
                bMoving = false;
            }

            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.W)) {
                Move(new Vector2f(0, (float)(-cameraSpeed * turbo * Program.deltaTime)));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.S)) {
                Move(new Vector2f(0, (float)(cameraSpeed * turbo * Program.deltaTime)));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.A)) {
                Move(new Vector2f((float)(-cameraSpeed * turbo * Program.deltaTime), 0));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.D)) {
                Move(new Vector2f((float)(cameraSpeed * turbo * Program.deltaTime), 0));
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.R)) {
                Rotate(0.05f);
            }
            if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.Q)) {
                Rotate(-0.05f);
            }
        }

        public void SetZoomState(float factor){
            Zoom(1.0f);
        }
    }
}