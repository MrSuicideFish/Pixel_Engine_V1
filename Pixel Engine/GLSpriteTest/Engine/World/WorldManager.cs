using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GLSpriteTest.Engine.World
{
    public struct WorldSettings
    {

    }

    public class World
    {
        public WorldSettings Settings;
        public GameObject[] Objects;

        public string LocalPath = "";

        public World( string _worldName = "Untitled" )
        {
            Settings = new WorldSettings( );
            Objects = new GameObject[0];
        }
    }

    public static class WorldManager
    {
        #region Loaded Objects
        private static World            LOADED_WORLD;
        private static WorldSettings    WORLD_SETTINGS;
        private static GameObject[]     WORLD_OBJECTS;
        #endregion

        #region World Events
        public delegate void SettingsChanged( );
        public static event SettingsChanged OnSettingsChanged;

        public delegate void ObjectsChanged( );
        public static event ObjectsChanged OnObjectsChanged;
        #endregion

        public static bool IsInitialized { get; private set; }

        public static int Initialize( )
        {
            //Create empty world
            LOADED_WORLD    = new World( );
            LOADED_WORLD.LocalPath = "localhost";

            WORLD_SETTINGS  = LOADED_WORLD.Settings;
            WORLD_OBJECTS   = LOADED_WORLD.Objects;

            IsInitialized   = true;

            return 0;
        }

        #region World Load/Save
        public static void LoadWorld( string _path )
        {

        }

        public static void SaveWorld( string _worldName = "Untitled" )
        {
            string _worldData = JsonConvert.SerializeObject( LOADED_WORLD );

            File.WriteAllText( Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ) + "/" + _worldName + ".world", _worldData );
        }
        #endregion

        #region Object Management

        #endregion

        #region Settings Management

        #endregion
    }
}