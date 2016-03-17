using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAControl;
using Color = Microsoft.Xna.Framework.Color;

namespace Editor
{
    public class EditorGame : XNAControlGame
    {
        public EditorGame( IntPtr windowHandle, string contentRoot ) 
            : base( windowHandle, contentRoot )
        {

        }

        protected override bool BeginDraw( )
        {
            GraphicsDevice.Clear( Color.Black );

            return base.BeginDraw( );
        }

        protected override void Update( GameTime gameTime )
        {
            base.Update( gameTime );
        }
    }
}
