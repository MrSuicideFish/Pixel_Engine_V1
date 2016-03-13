using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PixelEngine;
using PixelEngine.Engine;
using FarseerPhysics.Common;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision.Shapes;

namespace PixelEngine.Graphics
{
    public abstract class CollisionComponent : Component
    {
        public Body RigidBody { get; protected set; }

        protected FarseerPhysics.Common.Transform RB_Transform;

        public delegate void CollisionDelegate( CollisionComponent col );
        public event CollisionDelegate OnCollisionEnter;
        public event CollisionDelegate OnCollisionExit;

        public CollisionComponent( GameObject _parent = null ) : base( _parent )
        {
            //Create Rigidbody
            RigidBody = BodyFactory.CreateRectangle( PixelEngine.PHYSICS_WORLD, 1, 1, 1.0f );
            RigidBody.BodyType = BodyType.Dynamic;
            RigidBody.GetTransform( out RB_Transform );

            PixelEngine.OnPhysicsUpdate += OnPhyicsUpdate;
        }

        protected virtual void OnPhyicsUpdate( World _phyWorld )
        {
            gameObject.transform.Position += RigidBody.LinearVelocity;
            //gameObject.transform.Rotation += RigidBody.AngularVelocity;
        }

        protected virtual void OnCollisionHit( CollisionComponent col )
        {
            //Invoke event
            if ( OnCollisionEnter != null )
            {
                OnCollisionEnter( col );
            }
        }

        protected virtual void OnCollisionLeave( CollisionComponent col )
        {
            //Invoke event
            if ( OnCollisionEnter != null )
            {
                OnCollisionExit( col );
            }
        }
    }

    public sealed class RectCollider : CollisionComponent
    {
        public RectCollider( GameObject _parent = null )
            : base( _parent )
        {

        }
    }

    public sealed class CircleCollider : CollisionComponent
    {
        public CircleCollider( GameObject _parent = null ) 
            : base( _parent )
        {

        }
    }

    public sealed class PolygonCollider : CollisionComponent
    {
        public PolygonCollider( GameObject _parent = null ) 
            : base( _parent )
        {

        }
    }
}
