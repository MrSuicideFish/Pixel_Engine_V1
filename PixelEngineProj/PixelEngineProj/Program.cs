using System;
using System.Diagnostics;
using System.IO;
using SFML.Audio;
using SFML.Window;
using SFML.Graphics;
using PixelEngineProj.System;


namespace PixelEngineProj {
    class Program {
        private static RenderWindow _window;

        //Timers and clocks
        static Stopwatch clock = new Stopwatch();
        private static Stopwatch deltaClock = new Stopwatch();

        /// <summary>
        /// System variables
        /// </summary>
        public static double deltaTime = 0;
        private static bool bDevMode = true;
        private static SFML.Graphics.Font systemFont;

        static void Main(string[] args) {
            // Create the main _window
            _window = new RenderWindow(new VideoMode(1920, 1080), "Pixel Engine", Styles.Fullscreen);
            _window.SetVerticalSyncEnabled(true);
            _window.Resized += new EventHandler<SizeEventArgs>(onResize);
            _window.Closed += new EventHandler(OnClose);

            //Create the main camera and hud camera
            View MainCamera = new View(new FloatRect(0, 0, _window.Size.X, _window.Size.Y));
            View HUDCamera = new View(new FloatRect(0, 0, _window.Size.X, _window.Size.Y));

            //Initiate modules
            PixelScene.Init("");

            //Load system resources
            LoadSystemResources();

            //Testing DEBUG
            Texture texture = new Texture("Resources/deleteMe.png", new IntRect(0,0,300, 300));
            texture.Update(_window);
            Sprite newSprite = new Sprite(texture);
            newSprite.Texture = texture;
            newSprite.Rotation = 180;
            texture.Smooth = false;
            texture.Repeated = false;
            //-------------------------------\\

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
                _window.SetView(MainCamera);

                /// <summary>
                /// UPDATES AND DRAW CALLS HERE
                /// </summary>

                //Call the update method on all modules
                if (PixelScene.Update() == 0)
                    PixelScene.Draw();
                else
                    new ApplicationException("Exception: Could not complete Update process on PixelScene.Update()");

                newSprite.Position = new Vector2f(300, 300);
                newSprite.Scale = new Vector2f(3, 3);
                newSprite.Draw(_window, new RenderStates(texture));

                /// <summary>
                /// DEBUG DEV MODE DRAWING
                /// </summary>
                if (bDevMode) {
                    //Camera controls
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Left)){
                        MainCamera.Move(new Vector2f((float)(-300 * deltaTime), 0));
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) {
                        MainCamera.Move(new Vector2f((float)(300 * deltaTime), 0));
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) {
                        MainCamera.Move(new Vector2f(0, (float)(-300 * deltaTime)));
                    }
                    if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) {
                        MainCamera.Move(new Vector2f(0, (float)(300 * deltaTime)));
                    }

                    Text debugHelp = new Text("Dev mode Enabled! Arrow Keys - Move", systemFont, 16);
                    debugHelp.Position = new Vector2f((int)(_window.Size.X / 2 - 100), (int)(_window.Size.Y - 32));
                    Text fpsText = new Text("FPS: " + fps.ToString(), systemFont, 16);
                    Text mouseScreenPos = new Text("Mouse Screen Position: " + Mouse.GetPosition(_window).ToString(), systemFont, 16);
                    mouseScreenPos.Position = new Vector2f(0, 16);
                    Text mouseWorldPos = new Text("Mouse World Position: " + _window.MapPixelToCoords(Mouse.GetPosition(_window)), systemFont, 16);
                    mouseWorldPos.Position = new Vector2f(0, 32);

                    //Do hud drawing
                    _window.SetView(HUDCamera);
                    _window.Draw(fpsText);
                    _window.Draw(mouseScreenPos);
                    _window.Draw(mouseWorldPos);
                    _window.Draw(debugHelp);
                }

                _window.Display();

                frames++;

                //Calculate deltaTime
                TimeSpan _deltaTime = new TimeSpan();
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
    }
}