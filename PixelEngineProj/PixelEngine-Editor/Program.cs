using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using PixelEngineProj;

namespace PixelEngine_Editor {
    static class Program {
        //Engine
        private static string EngineVersion = PixelEngineProj.Program.engineName;

        //Project
        public static bool bProjectLoaded = false;
        public static string _projdir;
        public static string _projectname;

        [STAThread]
        static void Main()
        {
            //Get the splash screen graphic
            System.Windows.SplashScreen EngineSplashScreen = new System.Windows.SplashScreen("Resources/SplashScreen.jpg");
            EngineSplashScreen.Show(true);

            // initialize the main engine form
            Form1 form = new Form1();
            form.Size = new System.Drawing.Size(1280, 720);
            if (bProjectLoaded)
                form.Text = _projectname + " - " + EngineVersion;
            else
                form.Text = "No Project" + " - " + EngineVersion;

            form.Show(); // show our form
            form.WindowStatus = "Initializing Engine";

            DrawingSurface rendersurface = new DrawingSurface();
            rendersurface.Size = new System.Drawing.Size(form.Width, form.Height);
            rendersurface.Location = new System.Drawing.Point(0, 0);

            form.Controls.Add(rendersurface);
            form.WindowStatus = "Engine Started!";

            // initialize sfml
            SFML.Graphics.RenderWindow renderwindow = new SFML.Graphics.RenderWindow(rendersurface.Handle);

            // drawing loop
            while (form.Visible) {
                System.Windows.Forms.Application.DoEvents();
                renderwindow.DispatchEvents();
                renderwindow.Clear(SFML.Graphics.Color.Magenta);
                renderwindow.Display();
                rendersurface.Size = new System.Drawing.Size(form.Width - 300, form.Height);
            }

            //Initialize the resources form
            //ResourcesForm resourcesForm = new ResourcesForm();
            //resourcesForm.Size = new System.Drawing.Size(800, 600);
            //resourcesForm.Location = new System.Drawing.Point(form.Location.X + form.Width, form.Location.Y);
            //resourcesForm.Show();
        }

        public static void LoadProject(string newProjName, string newProjDir) {
            //Close all the forms
            FormCollection fc = Application.OpenForms;
            if (fc != null && fc.Count > 0) {
                for (int i = 0; i < fc.Count; i++) {
                    if (fc[i] != null && !fc[i].IsDisposed) {
                        fc[i].Dispose();
                    }
                }
            }

            //Set the values of the new project
            _projdir = newProjDir;
            _projectname = newProjName;
            bProjectLoaded = true;

            //Load other proj settings here

            //Start the main thread again
            Main();
        }

        public static void EngineMessage(string message, string messageType = "") {
            ConsoleColor newColor = ConsoleColor.White;
            switch (messageType) {
                case "Warning":
                    newColor = ConsoleColor.Yellow;
                    break;
                case "Exception":
                    newColor = ConsoleColor.Red;
                    break;
                case "Confirm":
                    newColor = ConsoleColor.Green;
                    break;
                default:
                    newColor = ConsoleColor.White;
                    break;
            }
            Console.ForegroundColor = newColor;
            Console.WriteLine("["+DateTime.Now.ToLocalTime() +"] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public class DrawingSurface : System.Windows.Forms.Control
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e){}
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent){}
        void ShowGrid(System.Windows.Forms.PaintEventArgs e) {}
    }
}
