using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using SFML.Graphics;

namespace PixelEngineProj.System {
    static class PixelScene{

        private static string currentLevel;

        public static int Init(string _scene) {
            if (_scene != "" && _scene != null) {
				if (LoadLevel(_scene) == 1) {
					//Parse the found data
				}
            } else {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No scene passed to PixelScene Init(), loading default front end.");
                Console.ForegroundColor = ConsoleColor.White;
            }
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

		//Handle the information loaded from the level's XML File
		private static void ParseXML() {}
        public static int Update() {return 0;}
        public static int Draw() {return 0;}
    }
}