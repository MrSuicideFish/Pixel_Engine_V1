using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PixelEngine.Interfaces;
using Microsoft.Xna.Framework;

namespace PixelEngine.Engine
{
    [Serializable]
    public class Component : Object, IUpdateable
    {
        public string Name { get; set; }

        [JsonIgnore]
        public GameObject gameObject { get; private set; }

        //Event dispatches
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        [JsonIgnore]
        private bool enabled = false;

        public bool Enabled
        {
            get { return enabled; }
            private set { enabled = value; }
        }

        [JsonIgnore]
        private int updateOrder = 0;

        public int UpdateOrder
        {
            get { return updateOrder; }
            set { updateOrder = value; }
        }

        public Component( GameObject _parent = null )
        {
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
