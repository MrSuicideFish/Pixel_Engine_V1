using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace PixelEngine.Gameplay {
    public class pCamera : SFML.Graphics.View {
        public pCamera(FloatRect viewRect) : base(viewRect) {
        }
    }
}