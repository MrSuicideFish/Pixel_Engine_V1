using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelEngine;
using PixelEngine.Engine;
using PixelEngine.Graphics;

namespace PixelEngine.Graphics
{
    [Serializable]
    public class Camera : Component
    {
        private readonly Viewport _Viewport;

        private float _Zoom = 1.0f;
        private float _Rotation;

        private Vector2 _Position;

        private bool IsViewMatrixDirty = true;

        //Origin
        private Vector2 Origin;

        //Main View Matrix
        private Matrix ViewMatrix = Matrix.Identity;

        //Operational Matricies
        private Matrix TransMatrix  = Matrix.Identity;
        private Matrix RotMatrix    = Matrix.Identity;
        private Matrix ScaleMatrix  = Matrix.Identity;

        public static Camera main
        {
            get
            {
                return PixelEngine.GAME_CAMERA;
            }
        }

        public float Zoom
        {
            get { return _Zoom; }
            set
            {
                _Zoom = value;

                if ( _Zoom <= 1.0f ) _Zoom = 1.0f;

                IsViewMatrixDirty = true;
            }
        }

        public float Rotation
        {
            get { return _Rotation; }
            set
            {
                _Rotation = value;
                IsViewMatrixDirty = true;
            }
        }

        public Vector2 Position
        {
            get { return _Position; }
            set
            {
                _Position = value;
                IsViewMatrixDirty = true;
            }
        }

        public Camera( Viewport _viewport, GameObject _parent = null )
            : base( _parent )
        {
            Origin = new Vector2( _viewport.Width / 2, _viewport.Height / 2 );
        }

        public Matrix GetViewTransformMatrix( )
        {
            return
                Matrix.CreateTranslation( new Vector3( -Position + Origin, 0.0f ) ) *
                Matrix.CreateTranslation( new Vector3( -Origin, 0.0f ) ) *
                Matrix.CreateRotationX( Rotation ) *
                Matrix.CreateScale( Zoom, Zoom, 1 ) *
                Matrix.CreateTranslation( new Vector3( Origin, 0.0f ) );
        }

        public void LookAt( Transform _transform )
        {
            Position = new Vector2
                ( 
                    _transform.Position.X + ( _transform.Scale.X / 2 ),
                    _transform.Position.Y + ( _transform.Scale.Y / 2 ) 
                );
        }
        public void LookAt( GameObject _gameObject )
        {
            Position = new Vector2
                (
                    _gameObject.transform.Position.X + ( _gameObject.transform.Scale.X / 2 ),
                    _gameObject.transform.Position.Y + ( _gameObject.transform.Scale.Y / 2 )
                );
        }

        public override void Update( GameTime _gameTime )
        {
            gameObject.transform.Position = Position;
            base.Update( _gameTime );
        }
    }
}