using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GLSpriteTest.Interfaces
{
    public interface IDrawable
    {
        int DrawOrder { get; }
        bool Visible { get; }

        event EventHandler<EventArgs> DrawOrderChanged;
        event EventHandler<EventArgs> VisibleChanged;

        void Draw( GameTime gameTime, SpriteBatch spriteBatch );
    }
}