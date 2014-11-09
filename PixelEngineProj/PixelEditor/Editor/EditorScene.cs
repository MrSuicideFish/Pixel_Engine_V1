using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
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
        public static List<EditorActor> SCENE_ACTORS { get; set; }
        public static List<pSceneService> SCENE_SERVICES { get; set; }
        
        /// <summary>
        /// Initiates the scene
        /// </summary>
        public EditorScene(string _sceneName = "Untitled") {
            Program.EngineMessage("Initializing editor scene manager");
            try {
                SCENE_ACTORS = new List<EditorActor>();
                SCENE_SERVICES = new List<pSceneService>();
                sceneName = _sceneName;
            } catch (NullReferenceException _n) {
                Program.EngineMessage(_n.Message, Program.eEngineMessageType.EXCEPTION);
            }
            Program.EngineMessage("Editor scene manager Initialized", Program.eEngineMessageType.CONFIRM);
            //DoDebugStuff();
        }

        void DoDebugStuff() {
            //Random _n = new Random();
            //Vector2f newLoc;
            //for (int i = 0; i < 0; i++) {
            //    newLoc = new Vector2f(_n.Next(0, 5000), _n.Next(0, 5000));
            //    EditorActor _newActor = new EditorActor("Test Actor", newLoc);
            //    AddActorToScene(ref _newActor);
            //}
        }

        //Update actors
        public virtual void Update() {
            //Call update on scene actors
            foreach (EditorActor _a in SCENE_ACTORS) {
                _a.Update();
            }
        }

        //Draw scene actors
        public virtual void Draw(RenderTarget target, RenderStates states) {
            foreach (EditorActor _a in SCENE_ACTORS) {      
                if (_a.actorSprite != null) {
                    _a.Draw(target, states);
                }
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
        public void AddActorToScene(ref EditorActor _newActor) {
            if (_newActor != null) {
                //Generate new unique id for this actor
                _newActor.GenerateUniqueId();
                try {
                    _newActor.position = _newActor.position - new Vector2f(_newActor.actorSprite.Texture.Size.X/2, _newActor.actorSprite.Texture.Size.Y/2);
                    SCENE_ACTORS.Add(_newActor);
                    _newActor.Create();
                } catch (NullReferenceException _n) {
                    Editor.EngineMessage(_n.Message, Editor.eEngineMessageType.EXCEPTION);
                }
            } else {
                Editor.EngineMessage("ERROR: FAILED TO ADD ACTOR TO SCENE BECAUSE THE OBJECT YOU ARE TRYING TO ADD IS NULL");
            }
        }

        /// <summary>
        /// Destroys the specified actor and removes it from memory
        /// NOTE: An actor MUST be in the scene's actor collection to exist. Actors removed from the collection
        /// are dereferenced completely.
        /// </summary>
        /// <param name="_actor"></param>
        public void DestroyActor(EditorActor _actor) {
            if (_actor != null) {
                try {
                    //Find the actor
                    foreach (EditorActor _a in SCENE_ACTORS) {
                        if (_a.GetUniqueId() == _actor.GetUniqueId()) {
                            //Call the actor's dispose method
                            if (_a.Destroy() == 0) {
                                //Remove the actor from the list
                                SCENE_ACTORS.Remove(_a);
                                //Dereference and call GC
                                GC.Collect();
                                return;
                            }
                        }
                    }
                    Editor.EngineMessage("ERROR: Failed to destroy scene actor because the actor does not exist.", Editor.eEngineMessageType.EXCEPTION);
                    return;
                } catch (NullReferenceException _n) {
                    Editor.EngineMessage(_n.Message, Editor.eEngineMessageType.EXCEPTION);
                }
            }
        }

        /// <summary>
        /// Finds an actor based on the specified ID string
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public EditorActor FindActorById(string _id) {
            foreach (EditorActor _a in SCENE_ACTORS) {
                if (_a != null && _a.id == _id) {
                    return _a;
                }
            }
            return null;
        }

        /// <summary>
        /// Finds an actor based on the specified unique ID int
        /// </summary>
        /// <param name="_uid"></param>
        /// <returns></returns>
        public EditorActor FindActorByUid(Int16 _uid) {
            return null;
        }
    }
}