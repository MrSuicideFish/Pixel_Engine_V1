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

namespace PixelEditor {
    public partial class Form1 : Form {
        /// <summary>
        /// Public Variables
        /// </summary>
        public static double deltaTime = 0;

        /// <summary>
        /// Private Variables
        /// </summary>
        private static DrawingSurface RENDER_SURFACE;
        private static RenderWindow RENDER_WINDOW;
        private static SFML.Graphics.View VIEWPORT_CAMERA_VIEW;
        private static SFML.Graphics.View VIEWPORT_UI_VIEW;
        private static string[] EditorDebugInfo;

        public Form1() {
            InitializeComponent();

            RENDER_SURFACE = new DrawingSurface();
            RENDER_SURFACE.Size = new System.Drawing.Size(800, 600);
            RENDER_SURFACE.Dock = DockStyle.Fill;

            Controls.Add(RENDER_SURFACE);
            RENDER_SURFACE.Location = new System.Drawing.Point(100, 100);

            //Init sfml
            RENDER_WINDOW = new RenderWindow(RENDER_SURFACE.Handle);

            //Create the main viewport view
            VIEWPORT_CAMERA_VIEW = new SFML.Graphics.View(new FloatRect(0, 0, RENDER_SURFACE.Width, RENDER_SURFACE.Height));
            VIEWPORT_UI_VIEW = new SFML.Graphics.View(new FloatRect(0, 0, RENDER_SURFACE.Width, RENDER_SURFACE.Height));

            //Init editor debug info
            EditorDebugInfo = new string[1];
        }

        private void Form1_Load(object sender, EventArgs e) {
            EditorGrid _grid = new EditorGrid();


            EditorDebug _debug = new EditorDebug(new SFML.Graphics.Font("EditorResources/pixelmix.ttf"));

            Stopwatch deltaClock = new Stopwatch();
            TimeSpan _deltaTime = new TimeSpan();
            Stopwatch clock = new Stopwatch();

            float frames = 0;
            float fps = 0;
            float cameraSpeed = 200;
            int turbo = 1;

            clock.Start();

            while (Visible) {
                Application.DoEvents();
                RENDER_WINDOW.DispatchEvents();
                RENDER_WINDOW.Clear(SFML.Graphics.Color.Black);

                //Calculate deltaTime
                _deltaTime = deltaClock.Elapsed;
                deltaClock.Restart();
                deltaTime = _deltaTime.TotalSeconds;

                turbo = !SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.LShift) ? 1 : 3;

                if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.W)) {
                    VIEWPORT_CAMERA_VIEW.Move(new Vector2f(0, (float)(-cameraSpeed * turbo * deltaTime)));
                }
                if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.S)) {
                    VIEWPORT_CAMERA_VIEW.Move(new Vector2f(0, (float)(cameraSpeed * turbo * deltaTime)));
                }
                if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.A)) {
                    VIEWPORT_CAMERA_VIEW.Move(new Vector2f((float)(-cameraSpeed * turbo * deltaTime), 0));
                }
                if (SFML.Window.Keyboard.IsKeyPressed(Keyboard.Key.D)) {
                    VIEWPORT_CAMERA_VIEW.Move(new Vector2f((float)(cameraSpeed * turbo * deltaTime), 0));
                }

                ///
                /// DRAW CAMERA VIEW
                /// 
                RENDER_WINDOW.SetView(VIEWPORT_CAMERA_VIEW);
                RENDER_WINDOW.Draw(_grid);

                ///
                /// DRAW UI VIEW
                /// 
                RENDER_WINDOW.SetView(VIEWPORT_UI_VIEW);
                //Draw debug information
                _debug.SetDebugInfo(0, "FPS: " + fps.ToString());
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
    }

    public class DrawingSurface : Control {
        protected override void OnPaint(PaintEventArgs e) {
            //base.OnPaint(e);
        }

        protected override void OnPaintBackground(PaintEventArgs e) {
            //base.OnPaintBackground(e);
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
        }

        public void Draw(RenderTarget target, RenderStates states) {
            for (int i = 0; i < DEBUG_INFO.Length; i++) {
                DEBUG_INFO[i].CharacterSize = 8;
                DEBUG_INFO[i].Position = new Vector2f(0, 16);
                target.Draw(DEBUG_INFO[i]);
            }
        }

        public void SetDebugInfo(int index, string message) {
            if (DEBUG_INFO != null && message != "") {
                DEBUG_INFO[index].DisplayedString = message;
            }
        }
    }
}