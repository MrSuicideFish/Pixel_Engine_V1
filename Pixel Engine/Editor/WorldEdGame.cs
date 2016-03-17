using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XNAControl;

namespace Editor
{
    public class WorldEdGame : XNAControlGame
    {
        public static SpriteBatch SPRITE_BATCH { get; private set; }
        private Texture2D SpriteTex;

        public WorldEdGame(IntPtr handle, string contentRoot)
            :base(handle, contentRoot )
        {
            SPRITE_BATCH = new SpriteBatch( GraphicsDevice );
        }

        protected override bool BeginDraw( )
        {
            GraphicsDevice.Clear( Color.CornflowerBlue );

            SPRITE_BATCH.Begin( );

            DrawLine( new Vector2( 0, 100 ), 300, 1, Color.Black );

            SPRITE_BATCH.End( );

            return base.BeginDraw( );
        }

        private void DrawLine(int x1, int y1, int x2, int y2, Color color )
        {
            if(SpriteTex == null )
            {
                SpriteTex = new Texture2D( GraphicsDevice, 1, 1, false, SurfaceFormat.Color );
                SpriteTex.SetData( new Color[1] { color } );
            }


            SPRITE_BATCH.Draw(
                SpriteTex,
                new Rectangle(
                    x1,
                    y1,
                    x2 - x1,
                    y2 - y1 ),
                color );
        }

        private void DrawLine( Vector2 start, int width, int height, Color color )
        {
            if ( SpriteTex == null )
            {
                SpriteTex = new Texture2D( GraphicsDevice, 1, 1, false, SurfaceFormat.Color );
                SpriteTex.SetData( new Color[1] { color } );
            }


            SPRITE_BATCH.Draw(
                SpriteTex,
                new Rectangle(
                    ( int )start.X,
                    ( int )start.Y,
                    width,
                    height ),
                color );
        }

        protected override void Update( GameTime gameTime )
        {
            Console.WriteLine( "Update" );
            base.Update( gameTime );
        }
    }
}
