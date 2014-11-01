using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using SFML.Graphics;

namespace PixelEngine.System {
    public static class PixelScene{
        /// <summary>
        /// PRIVATE VARIABLES
        /// </summary>
        private static string currentLevel;

        /// <summary>
        /// SCENE VARIABLES
        /// </summary>
        public static List<System.PixelActor> SCENE_OBJECTS;

        public static int Init() {
            Program.EngineMessage("Initializing scene manager");
            SCENE_OBJECTS = new List<PixelActor>();
            Program.EngineMessage("Scene manager Initialized", Program.eEngineMessageType.CONFIRM);
            return 0;
        }

        public static int LoadLevel(string _sceneName) {
            Console.WriteLine("Loading level - " + _sceneName);
            try {
                //Locate the level in the repo
                XmlDocument scene = new XmlDocument();
                scene.LoadXml(Directory.GetCurrentDirectory() + "/scenes/" + _sceneName + ".xml");
            }catch(XmlException f_exception){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("PixelScene.LoadLevel() FAILED with exception: " + f_exception.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
            currentLevel = _sceneName;
            return 0;
        }

        public static void AddObjectToScene(PixelActor obj) {
            if (obj != null) {
                SCENE_OBJECTS.Add(obj);
            } else {
                Program.EngineMessage("Failed to load object to scene because the object you are trying to add is NULL.", Program.eEngineMessageType.EXCEPTION);
            }
        }

        public static List<System.PixelActor> GetSceneObjects() {
            return SCENE_OBJECTS;
        }

        public static System.PixelActor FindObjectWithName() {
            return SCENE_OBJECTS[0];
        }

        //Handle the information loaded from the level's XML File
        private static void ParseXML() { }

        public static void Update() {
            //Update the actors
            foreach (System.PixelActor _actor in SCENE_OBJECTS) {
                _actor.Update();
            }
        }

        public static void Draw(RenderTarget target, RenderStates states) {
            //Draw the Actors
            foreach(System.PixelActor _actor in SCENE_OBJECTS){
                target.Draw(_actor);
            }
        }
    }
}