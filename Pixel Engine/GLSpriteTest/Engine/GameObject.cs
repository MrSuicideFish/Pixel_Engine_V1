using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLSpriteTest.Interfaces;
using GLSpriteTest.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = GLSpriteTest.Interfaces.IDrawable;

namespace GLSpriteTest.Engine
{
    public class GameObject : Object, IUpdateable
    {
        public string Name { get; private set; }
        public Component[] Components { get; private set; }
        public Transform transform { get; private set; }

        //Event dispatches
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled { get; private set; }
        public int UpdateOrder { get; private set; }

        #region Constructors

        public GameObject( )
        {
            Name = "New Gameobject";
            World.WorldManager.AddGameObjectToWorld( this );
        }

        public GameObject( string _name )
        {
            Name = _name;

            Components = new Component[0];

            Graphics.Transform _transComponent = new Graphics.Transform( );
            _transComponent.Position = new Vector2( 0, 0 );
            _transComponent.Scale = new Vector2( 32, 32 );

            transform = ( Transform )AddComponent( _transComponent );

            Enabled = true;

            World.WorldManager.AddGameObjectToWorld( this );
        }

        #endregion

        /// <summary>
        /// Initializes the GameObject upon ready
        /// </summary>
        public virtual void Start( )
        {
        }

        /// <summary>
        /// Updates this GameObject and each of it's components.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update( GameTime gameTime )
        {
            //Update components
            for ( int i = 0; i < Components.Length; i++ )
            {
                if ( Components[i] == null ) continue;

                Components[i].Update( gameTime );
            }
        }

        /// <summary>
        /// Draws each child component of this GameObject.
        /// NOTE: GameObjects do not directly need a draw call.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public virtual void DrawComponents( SpriteBatch spriteBatch, GameTime gameTime )
        {
            for ( int i = 0; i < Components.Length; i++ )
            {
                IDrawable _drawableComp = Components[i] as IDrawable;

                if ( _drawableComp == null ) continue;
                else
                {
                    _drawableComp.Draw( gameTime, spriteBatch );
                }
            }
        }

        /// <summary>
        /// Called multiple times after physics processing
        /// </summary>
        public virtual void FixedUpdate( ) { }

        /// <summary>
        /// Called when this GameObject is destroyed.
        /// </summary>
        public virtual void OnDestroy( ) { }

        #region Query
        public static GameObject FindByName( string _name )
        {
            return null;
        }

        public static GameObject FindById(int id )
        {
            return null;
        }
        #endregion

        #region Component Management
        public Component AddComponent( Component _component )
        {
            Component[] _newCompList = new Component[Components.Length + 1];

            for ( int i = 0; i < _newCompList.Length; i++ )
                if ( i == _newCompList.Length - 1 )
                    _newCompList[i] = _component;
                else
                    _newCompList[i] = Components[i];

            Components = _newCompList;
            
            _component.Start( );
            return _component;
        }

        public void RemoveComponent( int _id )
        {
            Component[] _newCompList = new Component[Components.Length - 1];

            for ( int i = 0; i < Components.Length; i++ )
            {
                if ( Components[i].m_InstanceId == _id )
                    continue;
                else
                    _newCompList[i] = Components[i];
            }

            Components = _newCompList;
        }

        public void RemoveComponent( Type _type )
        {
            Component[] _newCompList = new Component[Components.Length - 1];

            for ( int i = 0; i < Components.Length; i++ )
            {
                if ( Components[i].GetType( ) == _type )
                    continue;
                else
                    _newCompList[i] = Components[i];
            }

            Components = _newCompList;
        }

        public T GetComponent<T>( ) where T : Component
        {
            int _idx = 0;
            T comp = null;

            while ( _idx < Components.Length )
            {
                if ( Components[_idx].GetType( ) == typeof( T ) )
                {
                    comp = ( T )Components[_idx];
                }

                _idx++;
            }

            return comp;
        }

        public Component GetComponent( Type _type )
        {
            Component _newComponent = null;

            try
            {
                for ( int _idx = 0; _idx < Components.Length - 1; _idx++ )
                {
                    if ( Components[_idx].GetType( ) == _type )
                    {
                        _newComponent = Components[_idx];
                    }
                }
            }
            catch ( NullReferenceException _NullEx )
            {
                throw _NullEx;
            }
            catch ( IndexOutOfRangeException _rangeEx )
            {
                throw _rangeEx;
            }

            return _newComponent;
        }

        public Component GetComponent( int _id )
        {
            Component _newComponent = null;

            try
            {
                for ( int _idx = 0; _idx < Components.Length - 1; _idx++ )
                {
                    if ( Components[_idx].m_InstanceId == _id )
                    {
                        return Components[_idx];
                    }
                }
            }
            catch ( NullReferenceException _NullEx )
            {
                throw _NullEx;
                return null;
            }
            catch ( IndexOutOfRangeException _rangeEx )
            {
                throw _rangeEx;
                return null;
            }

            return _newComponent;
        }
        #endregion

    }
}