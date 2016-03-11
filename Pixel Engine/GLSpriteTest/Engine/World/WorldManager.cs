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
    }

    public static class WorldManager
    {
        private static World LOADED_WORLD;
        private static WorldSettings WORLD_SETTINGS;
        private static GameObject[] WORLD_OBJECTS;

        public static int Initialize( )
        {
            return 0;
        }

        public static void LoadWorld( string path )
        {
        }

        public static void SaveWorld( )
        {
            World testWorld = new World( );
            testWorld.Settings = new WorldSettings( );
            testWorld.Objects = new GameObject[]
            {

            };

            string _worldData = JsonConvert.SerializeObject( testWorld );

            File.WriteAllText( Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ) + "/FirstLevel.world", _worldData );
        }

        public static void LoadWorldAsync( )
        {

        }
    }
}