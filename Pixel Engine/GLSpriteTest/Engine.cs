using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GLSpriteTest.Engine;
using GLSpriteTest.Graphics;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using FarseerPhysics.DebugView;

using WorldManager = GLSpriteTest.Engine.World.WorldManager;

namespace GLSpriteTest
{
    public class Game1 : Game
    {
        /// <summary>
        /// DEBUG
        /// </summary>
        private DebugViewXNA DebugView;

        public GraphicsDeviceManager m_Graphics { get; private set; }
        public SpriteBatch m_SpriteBatch { get; private set; }

        public static GameObject m_ROOT_GAMEOBJECT { get; private set; }
        public static Camera GAME_CAMERA { get; private set; }

        /// <summary>
        /// PHYSICS
        /// </summary>
        public static World PHYSICS_WORLD { get; private set; }

        public delegate void PHYS_UPDATE( World _phyWorld );
        public static event PHYS_UPDATE OnPhysicsUpdate;

        //TESTING STUFF
        public SortedList<int, Texture2D> SpriteSheets { get; private set; }
        public SortedList<int, GameObject> SceneObjects = new SortedList<int, GameObject>( );

        public static Game1 Game { get; private set; }

        public Game1( )
        {
            m_Graphics = new GraphicsDeviceManager( this );
            m_Graphics.PreferredBackBufferWidth = 1440;
            m_Graphics.PreferredBackBufferHeight = 900;

            Content.RootDirectory = "Content";
            Game = this;

            SpriteSheets = new SortedList<int, Texture2D>( );

            //Initialize Physics
            PHYSICS_WORLD = new World( new Vector2( 0f, 0f ) );
        }

        protected override void Initialize( )
        {
            base.Initialize( );

            //Init world manager
            WorldManager.Initialize( );

            m_ROOT_GAMEOBJECT = new GameObject( "ROOT" );
        }

        Graphics.RectCollider _colliderA;
        Graphics.RectCollider _colliderB;
        protected override void LoadContent( )
        {
            PHYSICS_WORLD.Clear( );

            if(DebugView == null )
            {
                DebugView = new DebugViewXNA( PHYSICS_WORLD );
                DebugView.DefaultShapeColor = Color.White;
                DebugView.SleepingShapeColor = Color.LightGray;
                DebugView.LoadContent( GraphicsDevice, Content );
                DebugView.AppendFlags( FarseerPhysics.DebugViewFlags.Shape );
            }

            //create sprite batch
            m_SpriteBatch = new SpriteBatch( GraphicsDevice );

            //add sprite texture
            SpriteSheets.Add( 0, Content.Load<Texture2D>( "PikaSprite" ) );

            //Create camera
            GameObject _camObj = new GameObject( "SCENE_CAMERA" );
            GAME_CAMERA = new Camera( GraphicsDevice.Viewport, _camObj );
            _camObj.AddComponent( GAME_CAMERA );

            ////create scene object and add test components
            //GameObject _objA = new GameObject( "ColliderA" );
            //Graphics.SpriteRenderer _rendererA = new Graphics.SpriteRenderer( _objA, 0 ); // Renderer
            //_colliderA = new Graphics.RectCollider( _objA ); // Collider
            //_objA.AddComponent( _rendererA );
            //_objA.AddComponent( _colliderA );

            //GameObject _objB = new GameObject( "ColliderB" );
            //Graphics.SpriteRenderer _rendererB = new Graphics.SpriteRenderer( _objB, 0 ); // Renderer
            //_colliderB = new Graphics.RectCollider( _objB ); // Collider
            //_objB.AddComponent( _rendererB );
            //_objB.AddComponent( _colliderB );

            WorldManager.SaveWorld( );
        }

        protected override void UnloadContent( )
        {

        }

        protected override void Update( GameTime gameTime )
        {
            var deltaTime = ( float )gameTime.ElapsedGameTime.TotalSeconds;

            if ( GamePad.GetState( PlayerIndex.One ).Buttons.Back == ButtonState.Pressed || Keyboard.GetState( ).IsKeyDown( Keys.Escape ) )
                Exit( );

            //Do Physics step
            PHYSICS_WORLD.Step( Math.Min( ( float )gameTime.ElapsedGameTime.TotalSeconds, ( 1f / 30f ) ) );

            //Dispatch Physics Events
            if (OnPhysicsUpdate != null )
            {
                OnPhysicsUpdate( PHYSICS_WORLD );
            }

            //Dispatch update events
            foreach ( KeyValuePair<int, GameObject> _obj in SceneObjects )
            {
                if ( _obj.Value.Name == "ROOT" ) continue;

                _obj.Value.Update( gameTime );
            }

            base.Update( gameTime );
        }

        protected override void Draw( GameTime gameTime )
        {
            //Clear the back-buffer
            GraphicsDevice.Clear( Color.Black );

            //Begin batch
            var viewMatrix = GAME_CAMERA.GetViewTransformMatrix( );
            m_SpriteBatch.Begin( SpriteSortMode.BackToFront, transformMatrix: viewMatrix );

            //Dispatch draw events
            foreach ( KeyValuePair<int, GameObject> _obj in SceneObjects )
            {
                _obj.Value.DrawComponents( m_SpriteBatch, gameTime );
            }

            //End batch
            m_SpriteBatch.End( );

            //Parent callback
            base.Draw( gameTime );
        }

        /*#################################
        * VIEWPORT MANAGEMENT
        *#################################*/
        

        /*#################################
         * SCENE MANAGEMENT
         *#################################*/
        private static int ObjectCount;
        public static void AddGameObjectToWorld( GameObject _newObj )
        {
            if ( _newObj == null ) return;

            Game.SceneObjects.Add( ObjectCount++, _newObj );
            _newObj.Start( );
        }

        GameObject GetObjectById( int _id )
        {
            foreach ( KeyValuePair<int, GameObject> _obj in SceneObjects )
            {
                if ( _obj.Value.m_InstanceId == _id )
                {
                    return _obj.Value;
                }
            }

            return null;
        }

        /*#################################
         * SPRITE SHEET MANAGEMENT
         *#################################*/
        public static Texture2D GetSpriteTexture2D( int sheetIdx )
        {
            return Game.SpriteSheets[sheetIdx];
        }
    }
}
