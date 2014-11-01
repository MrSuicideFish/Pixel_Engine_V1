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
    public static class pScene{
        /// <summary>
        /// PUBLIC VARIABLES
        /// </summary>

        /// <summary>
        /// PRIVATE VARIABLES
        /// </summary>
        private static string currentLevel;

        /// <summary>
        /// SCENE VARIABLES
        /// </summary>
        public static List<System.pActor> SCENE_OBJECTS;

        /// <summary>
        /// Initiates the scene
        /// </summary>
        /// <returns></returns>
        public static int Init() {
            Program.EngineMessage("Initializing scene manager");
            SCENE_OBJECTS = new List<pActor>();
            Program.EngineMessage("Scene manager Initialized", Program.eEngineMessageType.CONFIRM);
            return 0;
        }

        /// <summary>
        /// Loads a new level with the given string
        /// </summary>
        /// <param name="_sceneName"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a new object to the scene
        /// </summary>
        /// <param name="obj"></param>
        public static void AddObjectToScene(pActor obj) {
            if (obj != null) {
                SCENE_OBJECTS.Add(obj);
            } else {
                Program.EngineMessage("Failed to load object to scene because the object you are trying to add is NULL.", Program.eEngineMessageType.EXCEPTION);
            }
        }

        public static List<System.pActor> GetSceneObjects() {
            return SCENE_OBJECTS;
        }

        public static System.pActor FindObjectWithName() {
            return SCENE_OBJECTS[0];
        }

        //Handle the information loaded from the level's XML File
        private static void ParseXML() { }

        public static void Update() {
            //Update the actors
            foreach (System.pActor _actor in SCENE_OBJECTS) {
                _actor.Update();
            }
        }

        public static void Draw(RenderTarget target, RenderStates states) {
            //Draw the Actors
            foreach(System.pActor _actor in SCENE_OBJECTS){
                target.Draw(_actor);
            }
        }
    }
}