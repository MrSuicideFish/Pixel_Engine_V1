﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using SFML.Graphics;

namespace PixelEngine.System {
    /// <summary>
    /// pScene should only handle main engine scenes (not editor)
    /// </summary>
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
        private static List<pObject> SCENE_OBJECTS;
        private static List<pSceneService> SCENE_SERVICES;

        /// <summary>
        /// Initiates the scene
        /// </summary>
        /// <returns></returns>
        public static int Init() {
            Program.EngineMessage("Initializing scene manager");
            try {
                SCENE_OBJECTS = new List<pObject>();
                SCENE_SERVICES = new List<pSceneService>();

            } catch (NullReferenceException _n) {
                Program.EngineMessage(_n.Message, Program.eEngineMessageType.EXCEPTION);
            }
            Program.EngineMessage("Scene manager Initialized", Program.eEngineMessageType.CONFIRM);
            return 0;
        }

        /// <summary>
        /// Loads a new level with the given string
        /// </summary>
        /// <param name="_sceneName"></param>
        /// <returns></returns>
        //public static int LoadLevel(string _sceneName) {
        //}

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

        //public static List<System.pActor> GetSceneObjects() {
        //    return SCENE_OBJECTS;
        //}

        //public static System.pActor FindObjectWithName() {
        //    return SCENE_OBJECTS[0];
        //}

        public static void Update() {
            //Update the actors??
        }

        public static void Draw(RenderTarget target, RenderStates states) {
            //Draw the Actors
            foreach(System.pActor _actor in SCENE_OBJECTS){
                target.Draw(_actor);
            }
        }
    }
}