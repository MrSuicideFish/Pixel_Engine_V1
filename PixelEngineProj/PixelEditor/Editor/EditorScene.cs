using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelEngine;
using PixelEngine.System;

namespace PixelEditor {
    /// <summary>
    /// EditorScene is the editor-equivilent of pScene
    /// which handles instanced objects as collections
    /// </summary>
    public class EditorScene{
        /// <summary>
        /// PUBLIC VARIABLES
        /// </summary>

        /// <summary>
        /// PRIVATE VARIABLES
        /// </summary>
        private static string sceneName = "";

        /// <summary>
        /// SCENE VARIABLES
        /// </summary>
        private static List<pObject> SCENE_OBJECTS;
        private static List<pSceneService> SCENE_SERVICES;

        /// <summary>
        /// Initiates the scene
        /// </summary>
        /// <returns></returns>
        public EditorScene(string _sceneName = "Untitled") {
            Program.EngineMessage("Initializing editor scene manager");
            try {
                SCENE_OBJECTS = new List<pObject>();
                SCENE_SERVICES = new List<pSceneService>();

                sceneName = _sceneName;

                //Debug, create an editor actor to test

            } catch (NullReferenceException _n) {
                Program.EngineMessage(_n.Message, Program.eEngineMessageType.EXCEPTION);
            }
            Program.EngineMessage("Editor scene manager Initialized", Program.eEngineMessageType.CONFIRM);
        }

        public void Update() {

        }

        public string getSceneName() {
            return sceneName;
        }

        public void setSceneName(string _newSceneName) {
            if (_newSceneName != "") {
                sceneName = _newSceneName;
            }
        }
    }
}
