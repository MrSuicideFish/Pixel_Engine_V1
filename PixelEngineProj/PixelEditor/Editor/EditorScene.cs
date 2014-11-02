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
        private static List<EditorActor> SCENE_ACTORS;
        private static List<pSceneService> SCENE_SERVICES;

        /// <summary>
        /// Initiates the scene
        /// </summary>
        /// <returns></returns>
        public EditorScene(string _sceneName = "Untitled") {
            Program.EngineMessage("Initializing editor scene manager");
            try {
                SCENE_OBJECTS = new List<pObject>();
                SCENE_ACTORS = new List<EditorActor>();
                SCENE_SERVICES = new List<pSceneService>();
                sceneName = _sceneName;
            } catch (NullReferenceException _n) {
                Program.EngineMessage(_n.Message, Program.eEngineMessageType.EXCEPTION);
            }
            Program.EngineMessage("Editor scene manager Initialized", Program.eEngineMessageType.CONFIRM);
            DoDebugStuff();
        }

        void DoDebugStuff() {
            //Actor testing
            TestEditorActor _a = new TestEditorActor("Test editor actor");
            AddActorToScene(_a);
        }

        public virtual void Update() {
            //Update Scene Services
            //foreach (pSceneService _sceneService in SCENE_SERVICES) {
            //    _sceneService.Update();
            //}
            //Call update on scene actors
            foreach (EditorActor _a in SCENE_ACTORS) {
                _a.Update();
            }
        }

        public string getSceneName() {
            return sceneName;
        }

        public void setSceneName(string _newSceneName) {
            if (_newSceneName != "") {
                sceneName = _newSceneName;
            }
        }

        /// <summary>
        /// Actor Collection Methods
        /// </summary>
        public void AddActorToScene(EditorActor newActor) {
            if (newActor != null) {
                //Generate new unique id for this actor
                newActor.GenerateUniqueId();
                try {
                    SCENE_ACTORS.Add(newActor);
                    newActor.Create();
                    Console.WriteLine("Added " + newActor.id + " to scene");
                } catch (NullReferenceException _n) {
                    Editor.EngineMessage(_n.Message, Editor.eEngineMessageType.EXCEPTION);
                }
            } else {
                Editor.EngineMessage("ERROR: FAILED TO ADD ACTOR TO SCENE BECAUSE THE OBJECT YOU ARE TRYING TO ADD IS NULL");
            }
        }

        public EditorActor FindActorById(string _id) {
            foreach (EditorActor _a in SCENE_ACTORS) {
                if (_a != null && _a.id == _id) {
                    return _a;
                }
            }
            return null;
        }

        public EditorActor FindActorByUid(string _uid) {
            return null;
        }
    }
}