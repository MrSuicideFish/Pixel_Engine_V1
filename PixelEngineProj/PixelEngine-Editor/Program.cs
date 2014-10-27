using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using SFML;
using SFML.Window;
using SFML.Graphics;
using System.Xml;
using System.Xml.Serialization;
using PixelEngineProj;

namespace PixelEngine_Editor {
    static class Program {
        //Engine
        private static string EngineVersion = PixelEngineProj.Program.engineName;
        public static EditorScene _scene;

        //Project
        public static bool bProjectLoaded = false;
        public static string _projdir;
        public static string _projectname;

        /// <summary>
        /// Editor
        /// </summary>
        public static Form1 form { get; set; }
        public static ResourcesForm resourcesForm { get; set; }

        [STAThread]
        static void Main()
        {
            //Get the splash screen graphic
            System.Windows.SplashScreen EngineSplashScreen = new System.Windows.SplashScreen("Resources/SplashScreen.jpg");
            EngineSplashScreen.Show(true);//Show splash screen

            // initialize the main engine form
            EngineMessage("Intializing Pixel Engine", eEngineMessageType.NONE);
            form = new Form1();
            form.Show(); // show our form

            LoadCfg();//Load config files

            DrawingSurface rendersurface = new DrawingSurface();
            rendersurface.Size = new System.Drawing.Size(form.Width, form.Height);
            rendersurface.Location = new System.Drawing.Point(0, 0);
            form.Controls.Add(rendersurface);

            EngineMessage("Pixel Engine Ready!", eEngineMessageType.CONFIRM);

            // initialize sfml
            SFML.Graphics.RenderWindow renderwindow = new SFML.Graphics.RenderWindow(rendersurface.Handle);
			//Main cam
            SFML.Graphics.View mainRenderView = new SFML.Graphics.View(new FloatRect(0, 0, 1920, 1080));
            renderwindow.SetView(mainRenderView);
			//UI Cam
			SFML.Graphics.View uiRenderView = new SFML.Graphics.View(new FloatRect(0,0,1920, 1080));

            _scene = new EditorScene(renderwindow, mainRenderView);

            //Initialize the resources form
            resourcesForm = new ResourcesForm();
            resourcesForm.Size = new System.Drawing.Size(800, 600);
            resourcesForm.Location = new System.Drawing.Point(form.Location.X + form.Width, form.Location.Y);
            resourcesForm.Show();
            resourcesForm.Disposed += new EventHandler(DisposedResourceForm);

            //Debug: create sprite
			PixelEngineProj.Gameplay.PixelSprite newSprite = new PixelEngineProj.Gameplay.PixelSprite("Resources/SpriteIcon.png", new IntRect(0, 0, 128, 128), new Vector2f(0, 0));
            newSprite.Position = new Vector2f(0, 0);

			Text t = new Text("Testing", new Font("Resources/pixelmix.ttf"));

            // drawing loop
            while (form.Visible) {
                System.Windows.Forms.Application.DoEvents();
                renderwindow.DispatchEvents();
                renderwindow.Clear(new SFML.Graphics.Color(40, 40, 40));

				//Draw main scene
				renderwindow.SetView(mainRenderView);
                _scene.Draw(renderwindow);

				renderwindow.SetView(uiRenderView);

				//Draw engine text
				renderwindow.SetView(uiRenderView);
				t.Position = new Vector2f(1700, 100);
				t.Draw(renderwindow, RenderStates.Default);

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

        public static void DisposedResourceForm(object sender, EventArgs args) {
            resourcesForm = null;
        }
    }

    public class DrawingSurface : System.Windows.Forms.Control
    {
        public DrawingSurface() {
            //Add event handlers
            this.Click += new EventHandler(OnViewportClick);
        }
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e){}
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent){}

        private void OnViewportClick(object sender, EventArgs args) {
            MouseEventArgs a = (MouseEventArgs)args;
            if (a.Button == MouseButtons.Left) {
            }
            if (a.Button == MouseButtons.Right) {
                Program.form.viewpoortContextMenu.Show(Program.form, MousePosition);
            }
        }
    }

    public class EditorScene : PixelEngineProj.System.PixelScene{
        public Sprite[] spriteBatch;
        private SFML.Graphics.View v;
        private SFML.Graphics.RenderWindow w;
		private PixelEngineProj.System.PixelObject[] sceneObjects;

        public EditorScene(SFML.Graphics.RenderWindow drawingWindow,SFML.Graphics.View drawingView) {
            w = drawingWindow;
            v = drawingView;

            //Debug, add new sprites here
            spriteBatch = new Sprite[0];
			sceneObjects = new PixelEngineProj.System.PixelObject[0];
        }


        public void AddSpriteToLevel(Sprite o, Vector2f worldPosition) {
        }

		public void AddObjectToLevel(PixelEngineProj.System.PixelObject o) {
			//create new object
			PixelEngineProj.System.PixelObject[] obj = new PixelEngineProj.System.PixelObject[sceneObjects.Length + 1];
			for (int i = 0; i < spriteBatch.Length; i++) {
				obj[i] = sceneObjects[i];
			}
			obj[obj.Length - 1] = o;
			sceneObjects = obj;
		}

        public void AddSpriteToLevel(Sprite s){

            //create new sprite batch
            Sprite[] batch = new Sprite[spriteBatch.Length + 1];
            for (int i = 0; i < spriteBatch.Length; i++) {
                batch[i] = spriteBatch[i];
            }

            //batch[batch.Length - 1].Position = worldPosition;
			batch[batch.Length - 1] = s;
            spriteBatch = batch;
        }

        public void Draw(RenderWindow _r) {
            if (_r != null) {
                foreach (Sprite s in spriteBatch) {
                    s.Draw(_r, RenderStates.Default);
                }
            }
			base.Draw();
        }

        public void Update() {
			base.Update();
        }


        public Vector2f GetMouseWorldPos() {
            return w.MapPixelToCoords(Mouse.GetPosition(w));
        }

        public XmlDocument SaveScene() {
            XmlDocument newDoc = new XmlDocument();

            return newDoc;
        }
    }
}