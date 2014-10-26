using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace PixelEngineProj.Interfaces {
    public interface IPlaceable : Drawable{
        void Begin();
        void Draw(RenderTarget target, RenderStates states);
        void Update();
    }
}
