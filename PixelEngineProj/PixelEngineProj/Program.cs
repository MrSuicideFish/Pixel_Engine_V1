using System;
using System.Diagnostics;
using System.IO;
using SFML.Audio;
using SFML.Window;
using SFML.Graphics;
using PixelEngineProj.System;


namespace PixelEngineProj {
    public class Program {
        /// <summary>
        /// System variables
        /// </summary>
        public static double deltaTime = 0;
        private static bool bDevMode = true;
        private static SFML.Graphics.Font systemFont;
        public static string engineName = "Pixel Engine 0.02a";
        private static RenderWindow _window;

        //Timers and clocks
        static Stopwatch clock = new Stopwatch();
        private static Stopwatch deltaClock = new Stopwatch();

        /// <summary>
        /// Global
        /// </summary>
        public static TimeSpan _deltaTime = new TimeSpan();

        public static void Main(string[] args) {
            //Process program arguments
            ProcessArgs(args);

            // Create the main _window
            _window = new RenderWindow(new VideoMode(1280, 720), "Pixel Engine", Styles.Titlebar);
            _window.SetVerticalSyncEnabled(true);
            _window.Resized += new EventHandler<SizeEventArgs>(onResize);
            _window.Closed += new EventHandler(OnClose);

            //Create the main camera and hud camera
            View renderView = new View(new FloatRect(0, 0, _window.Size.X, _window.Size.Y));
            View renderViewUI = new View(new FloatRect(0, 0, _window.Size.X, _window.Size.Y));

            //Load system resources
            LoadSystemResources();

            //Testing DEBUG
            Gameplay.PixelSprite newSprite = new Gameplay.PixelSprite("Resources/deleteMe.png", new IntRect(0,0,300,300), new Vector2f(200, 200));

            //Fps stuff
            clock.Start();
            float frames = 0;
            float fps = 0;

            // Start the game loop
            while (_window.IsOpen()) {
                // Process events
                _window.DispatchEvents();

                if (Keyboard.IsKeyPressed(Keyboard.Key.Tilde)) {
                    ToggleDevMode();
                }
                if (!Keyboard.IsKeyPressed(Keyboard.Key.Tilde)) {
                    bCanToggle = true;
                }

                // Clear screen
                _window.Clear();
                _window.SetView(renderView);

                /// <summary>
                /// UPDATES AND DRAW CALLS HERE
                /// </summary>

                //Call the update method on all modules

                newSprite.Draw(_window, new RenderStates());

                /// <summary>
                /// DEBUG DEV MODE DRAWING
                /// </summary>
                if (bDevMode) {
                    //Camera controls
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Left)){
                        renderView.Move(new Vector2f((float)(-300 * deltaTime), 0));
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) {
                        renderView.Move(new Vector2f((float)(300 * deltaTime), 0));
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) {
                        renderView.Move(new Vector2f(0, (float)(-300 * deltaTime)));
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) {
                        renderView.Move(new Vector2f(0, (float)(300 * deltaTime)));
                    }

                    Text debugHelp = new Text("Dev mode Enabled! Arrow Keys - Move", systemFont, 16);
                    debugHelp.Position = new Vector2f((int)(_window.Size.X / 2 - 100), (int)(_window.Size.Y - 32));
                    Text fpsText = new Text("FPS: " + fps.ToString(), systemFont, 16);
                    Text mouseScreenPos = new Text("Mouse Screen Position: " + Mouse.GetPosition(_window).ToString(), systemFont, 16);
                    mouseScreenPos.Position = new Vector2f(0, 16);
                    Text mouseWorldPos = new Text("Mouse World Position: " + _window.MapPixelToCoords(Mouse.GetPosition(_window)), systemFont, 16);
                    mouseWorldPos.Position = new Vector2f(0, 32);

                    //Do hud drawing
                    _window.SetView(renderViewUI);
                    _window.Draw(fpsText);
                    _window.Draw(mouseScreenPos);
                    _window.Draw(mouseWorldPos);
                    _window.Draw(debugHelp);
                }

                _window.Display();
                frames++;

                //Calculate deltaTime
                _deltaTime = deltaClock.Elapsed;
                deltaClock.Restart();
                deltaTime = _deltaTime.TotalSeconds;
                //Calculate FPS
                if (clock.Elapsed.Seconds > 0) {
                    fps = frames / clock.Elapsed.Seconds;
                    frames = 0;
                    clock.Restart();
                }
            }
        }

        public enum eEngineMessageType { WARNING, EXCEPTION, CONFIRM, NONE };
        public static void EngineMessage(string message, eEngineMessageType messageType = eEngineMessageType.NONE) {
            ConsoleColor newColor = ConsoleColor.White;
            switch (messageType) {
                case eEngineMessageType.WARNING:
                    newColor = ConsoleColor.Yellow;
                    break;
                case eEngineMessageType.EXCEPTION:
                    newColor = ConsoleColor.Red;
                    break;
                case eEngineMessageType.CONFIRM:
                    newColor = ConsoleColor.Green;
                    break;
                default:
                    newColor = ConsoleColor.White;
                    break;
            }
            Console.ForegroundColor = newColor;
            Console.WriteLine("[" + DateTime.Now.ToLocalTime() + "] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void OnClose(object sender, EventArgs e) {
            Console.WriteLine("Window Closing!");
            // Close the _window when OnClose event is received
            RenderWindow _window = (RenderWindow)sender;
            _window.Close();
        }

        static void onResize(object sender, SizeEventArgs e) {
            Debug.WriteLine("Resized!");
        }

        static bool bCanToggle = true;
        private static void ToggleDevMode() {
            if (bCanToggle) {
                bCanToggle = false;
                bDevMode = !bDevMode;
            }
        }

        private static void LoadSystemResources() {
            try {
                systemFont = new Font("Resources/pixelmix.ttf");
            } catch (SFML.LoadingFailedException fileException) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fileException.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ProcessArgs(string[] arguments) {
            Console.WriteLine("Processing arguments");
        }
    }
}