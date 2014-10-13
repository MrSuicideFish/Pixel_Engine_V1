using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using PixelEngineProj;

namespace PixelEngine_Editor {
    static class Program {
        //Engine
        private static string EngineVersion = PixelEngineProj.Program.engineName;

        //Project
        public static bool bProjectLoaded = false;
        public static string _projdir;
        public static string _projectname;

        /// <summary>
        /// Editor
        /// </summary>
        public static ResourcesForm resourcesForm;

        [STAThread]
        static void Main()
        {
            //Get the splash screen graphic
            System.Windows.SplashScreen EngineSplashScreen = new System.Windows.SplashScreen("Resources/SplashScreen.jpg");
            EngineSplashScreen.Show(true);

            // initialize the main engine form
            Form1 form = new Form1();
            form.Show(); // show our form
            form.WindowStatus = "Initializing Engine";

            //Create a CFG (if needed)
            LoadCfg();

            DrawingSurface rendersurface = new DrawingSurface();
            rendersurface.Size = new System.Drawing.Size(form.Width, form.Height);
            rendersurface.Location = new System.Drawing.Point(0, 0);

            form.Controls.Add(rendersurface);
            form.WindowStatus = "Engine Started!";

            // initialize sfml
            SFML.Graphics.RenderWindow renderwindow = new SFML.Graphics.RenderWindow(rendersurface.Handle);

            //Initialize the resources form
            resourcesForm = new ResourcesForm();
            resourcesForm.Size = new System.Drawing.Size(800, 600);
            resourcesForm.Location = new System.Drawing.Point(form.Location.X + form.Width, form.Location.Y);
            resourcesForm.Show();
            resourcesForm.Disposed += new EventHandler(DisposedResourceForm);

            // drawing loop
            while (form.Visible) {
                System.Windows.Forms.Application.DoEvents();
                renderwindow.DispatchEvents();
                renderwindow.Clear(SFML.Graphics.Color.Black);
                renderwindow.Display();
                rendersurface.Size = new System.Drawing.Size(form.Width - 300, form.Height);
            }
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

        public enum eEngineMessageType { WARNING, EXCEPTION, CONFIRM, NONE};
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
            Console.WriteLine("["+DateTime.Now.ToLocalTime() +"] " + message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void CfgWriteNode(string cfgNode, object val) {
            if (cfgNode != null && cfgNode != "" && val != null) {
                List<string> lines = new List<string>();
                if (File.Exists(Directory.GetCurrentDirectory() + "/PixelEngine.cfg")) {
                    //Add cfg file to temp lines
                    foreach (string line in File.ReadAllLines(Directory.GetCurrentDirectory() + "/PixelEngine.cfg")) {
                        lines.Add(line);
                    }
                    //index of the desired node
                    int nodeIndex;

                    //Check if node exists
                    if (CfgNodeExists(lines, cfgNode, out nodeIndex)) {
                        lines[nodeIndex] = cfgNode + "=" + val;
                    } else {
                        lines.Add(cfgNode + "=" + val);
                    }

                    File.WriteAllLines(Directory.GetCurrentDirectory() + "/PixelEngine.cfg", lines.ToArray());
                } else {
                    LoadCfg();
                }
            }
        }

        private static bool CfgNodeExists(List<string> lines, string nodeId, out int lineIndex) {
            bool exists = false;
            lineIndex = 0;
            for (int i = 0; i < lines.Count; i++) {
                if (lines[i].IndexOf('=') > 0) {
                    string _nId = lines[i].Substring(0, lines[i].IndexOf('='));
                    if (_nId == nodeId) {
                        lineIndex = i;
                        exists = true;
                    }
                }
            }
                return exists;
        }

        public static object CfgGetNodeValue(string nodeId) {
            var val = "";
            if (File.Exists(Directory.GetCurrentDirectory() + "/PixelEngine.cfg")) {
                string[] lines = File.ReadAllLines(Directory.GetCurrentDirectory() + "/PixelEngine.cfg");
                for (int i = 0; i < lines.Length; i++) {
                    if (lines[i].IndexOf('=') > 0) {
                        string _nId = lines[i].Substring(0, lines[i].IndexOf('='));
                        if (_nId == nodeId) {
                            val = lines[i].Substring(lines[i].IndexOf('=') + 1,
                                lines[i].Length - lines[i].IndexOf('=') - 1);
                        }
                    }
                }
            } else {
                LoadCfg();
            }
            return val;
        }

        public static void LoadCfg() {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/PixelEngine.cfg")) {
                EngineMessage("No config found. Creating new  PixelEngine.cfg", eEngineMessageType.WARNING);
                string[] cfgVal = {};
                File.WriteAllLines(Directory.GetCurrentDirectory() + "/PixelEngine.cfg", cfgVal);
            }
        }

        private static void DisposedResourceForm(object sender, EventArgs args) {
            resourcesForm = null;
        }
    }
    public class DrawingSurface : System.Windows.Forms.Control
    {
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e){}
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent){}
        void ShowGrid(System.Windows.Forms.PaintEventArgs e) {}
    }
}