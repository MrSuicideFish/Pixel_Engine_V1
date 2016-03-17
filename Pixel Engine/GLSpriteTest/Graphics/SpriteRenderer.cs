using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PixelEngine.Engine;
using IDrawable = PixelEngine.Interfaces.IDrawable;

namespace PixelEngine.Graphics
{
    [Serializable]
    public sealed class SpriteRenderer : Component, IDrawable, IUpdateable
    {
        //Public
        public int SpriteIndex { get; set; }
        public Color Color { get; set; }

        //Private
        private Rectangle RenderRect;

        //Event dispatches
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        //Properties
        public bool Visible { get; private set; }
        public int DrawOrder { get; private set; }

        public SpriteRenderer( GameObject _parent = null, int _spriteIdx = 0 ) : base( _parent )
        {
            RenderRect = new Rectangle( );
            SpriteIndex = _spriteIdx;
        }

        public override void Start( )
        {
            base.Start( );
        }

        public override void Update( GameTime _gameTime )
        {
            base.Update( _gameTime );

            if ( RenderRect == null ) RenderRect = new Rectangle( );

            RenderRect.X = ( int )gameObject.transform.Position.X;
            RenderRect.Y = ( int )gameObject.transform.Position.Y;

            RenderRect.Width = ( int )gameObject.transform.Scale.X;
            RenderRect.Height = ( int )gameObject.transform.Scale.Y;
        }

        public void Draw( GameTime gameTime ) { }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch )
        {
            spriteBatch.Draw(
                PixelEngine.ENGINE.SpriteSheets[SpriteIndex],
                RenderRect,
                new Rectangle( 0, 0, PixelEngine.ENGINE.SpriteSheets[SpriteIndex].Width, PixelEngine.ENGINE.SpriteSheets[SpriteIndex].Height ),
                Color );
        }

        public void SetSpriteIndex(int _idx ) { SpriteIndex = _idx; }
    }
}