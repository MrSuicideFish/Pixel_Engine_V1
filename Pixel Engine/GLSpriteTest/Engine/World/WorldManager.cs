using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GLSpriteTest.Engine.World
{
    public struct WorldSettings
    {

    }

    public class World
    {
        public WorldSettings Settings;
        public HashSet<GameObject> Objects;

        public string LocalPath = "";

        public World( string _worldName = "Untitled" )
        {
            Settings = new WorldSettings( );
            Objects = new HashSet<GameObject>( );
        }
    }

    public static class WorldManager
    {
        #region Error Strings
        private static readonly string Error_Object_Add = "ERROR - Failed to create object: ";
        #endregion

        #region Loaded Objects
        private static World            LOADED_WORLD;
        private static WorldSettings    WORLD_SETTINGS;
        private static HashSet<GameObject> WORLD_OBJECTS;
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

        public static void Update( GameTime gameTime )
        {
            foreach ( GameObject _obj in WORLD_OBJECTS )
            {
                _obj.Update( gameTime );
            }
        }

        public static void FixedUpdate( GameTime gameTime )
        {
            foreach ( GameObject _obj in WORLD_OBJECTS )
            {
                //_obj.FixedUpdate( gameTime );
            }
        }

        public static void Draw(SpriteBatch _spriteBatch, GameTime gameTime )
        {
            foreach ( GameObject _obj in WORLD_OBJECTS )
            {
                _obj.DrawComponents( _spriteBatch, gameTime );
            }
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
        public static void AddGameObjectToWorld( GameObject _newObj )
        {
            if ( _newObj == null )
            {
                Debug.Print( Error_Object_Add + "The Object is null", DEBUG_LOG_TYPE.ERROR );
            }

            if ( !IsInitialized || LOADED_WORLD == null )
            {
                Debug.Print( Error_Object_Add + "The world did not initialize properly", DEBUG_LOG_TYPE.ERROR );
            }

            WORLD_OBJECTS.Add( _newObj );
            _newObj.Start( );
        }
        #endregion

        #region Settings Management

        #endregion
    }
}