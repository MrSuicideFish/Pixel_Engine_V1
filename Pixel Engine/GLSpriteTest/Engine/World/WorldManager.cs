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
        public string LocalPath = "";

        public WorldSettings Settings;

        public HashSet<GameObject> Objects;

        public World( string _worldName = "Untitled" )
        {
            Settings = new WorldSettings( );
            Objects = new HashSet<GameObject>( );
        }
    }

    public static class WorldManager
    {
        #region Error Strings
        private static readonly string Error_Object_Add = "Failed to create object: ";
        #endregion

        #region Loaded Objects
        private static World LOADED_WORLD;
        private static WorldSettings WORLD_SETTINGS;
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
            LOADED_WORLD = new World( );
            LOADED_WORLD.LocalPath = "localhost";

            WORLD_SETTINGS = LOADED_WORLD.Settings;
            WORLD_OBJECTS = LOADED_WORLD.Objects;

            IsInitialized = true;

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

        public static void Draw( SpriteBatch _spriteBatch, GameTime gameTime )
        {
            foreach ( GameObject _obj in WORLD_OBJECTS )
            {
                _obj.DrawComponents( _spriteBatch, gameTime );
            }
        }

        #region World Load/Save
        public static void LoadWorld( string _path )
        {
            Debug.Print( "Loading World..." );
            try
            {
                if ( !string.IsNullOrEmpty( _path ) )
                {
                    FileInfo _info = new FileInfo( _path );
                    if ( _info.Exists )
                    {
                        if ( !string.IsNullOrEmpty( _info.Extension ) && _info.Extension.ToLower( ) == ".world" )
                        {
                            try
                            {
                                string _worldData = File.ReadAllText( _path );
                                World _newWorld = JsonConvert.DeserializeObject<World>( _worldData );

                                LOADED_WORLD = _newWorld;

                                WORLD_SETTINGS = LOADED_WORLD.Settings;
                                WORLD_OBJECTS = LOADED_WORLD.Objects;

                                Debug.Print( WORLD_OBJECTS.Count.ToString( ) );

                            }
                            catch(JsonException _jsonEx )
                            {
                                throw _jsonEx;
                            }
                        }
                        else
                        {
                            throw new FileNotFoundException( "Failed to load world" );
                        }

                    }
                    else
                    {
                        throw new FileNotFoundException( "File '" + _path + "does not exist." );
                    }

                }
                else
                {
                    throw new ArgumentNullException( "World path is NULL or EMPTY" );
                }
            }
            catch ( Exception _nf )
            {
                Debug.Print( _nf.Message + ":" + _nf.StackTrace, DEBUG_LOG_TYPE.ERROR );
                throw _nf;
            }
            finally
            {
                Debug.Print( "World Loaded - " + LOADED_WORLD.LocalPath );
            }
        }

        public static void SaveWorld( string _worldName = "Untitled", string _path = "" )
        {
            if ( LOADED_WORLD != null )
            {
                if ( string.IsNullOrEmpty( _path ) )
                    _path = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );

                Debug.Print( "Saving World to '" + _path + "'" );

                World _worldToSave = LOADED_WORLD;

                _worldToSave.LocalPath = _path + "\\" + _worldName + ".world";
                string _worldData = JsonConvert.SerializeObject( _worldToSave, Formatting.Indented );

                File.WriteAllText( _path + "\\" + _worldName + ".world", _worldData );

                Debug.Print( "World Saved! " );
            }
        }

        private static void InstantiateWorldObjects( )
        {
            try
            {
                if(LOADED_WORLD != null )
                {
                    for(int i = 0; i < LOADED_WORLD.Objects.Count - 1; i++ )
                    {

                    }
                }
                else
                {
                    throw new NullReferenceException( "Internal: LOADED_WORLD is NULL" );
                }
            }
            catch ( NullReferenceException _n )
            {
                Debug.Print( _n.Message, DEBUG_LOG_TYPE.ERROR );
                throw _n;
            }
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