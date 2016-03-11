using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GLSpriteTest.Interfaces;
using Microsoft.Xna.Framework;

namespace GLSpriteTest.Engine
{
    public abstract class Component : Object, IUpdateable
    {
        public string Name { get; private set; }
        public GameObject gameObject { get; private set; }

        //Event dispatches
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public bool Enabled { get; private set; }
        public int UpdateOrder { get; private set; }

        public Component( GameObject _parent = null )
        {
            if ( _parent == null )
                _parent = Game1.m_ROOT_GAMEOBJECT;

            Name = this.GetType( ).ToString( );
            gameObject = _parent;
        }

        public void SetActive( bool _active )
        {
            Enabled = _active;
        }

        //Virtual methods
        public virtual void Start( ) { }
        public virtual void Update( GameTime _gameTime ) { }
        public virtual void FixedUpdate( ) { }
        public virtual void OnDestroy( ) { }

        #region Operator Overload
        public override bool Equals( object obj )
        {
            if ( obj.GetType( ) != this.GetType( ) )
                return false;

            Component _newComponent = ( Component )obj;

            if ( _newComponent == null )
                return false;

            return this.m_InstanceId == _newComponent.m_InstanceId;
        }

        public override int GetHashCode( )
        {
            return m_InstanceId;
        }

        //public static bool operator ==( Component _componentA, Component _componentB )
        //{
        //    return _componentA.m_InstanceId == _componentB.m_InstanceId;
        //}

        //public static bool operator !=( Component _componentA, Component _componentB )
        //{
        //    return _componentA.m_InstanceId != _componentB.m_InstanceId;
        //}
        #endregion
    }
}
