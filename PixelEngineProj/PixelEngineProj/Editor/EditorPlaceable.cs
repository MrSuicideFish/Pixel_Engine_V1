using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;

namespace PixelEngineProj.Editor {
    public class EditorPlaceable : PixelEngineProj.System.PixelObject{
        public string name = "Object";
        public Vector2f position;
        public float rotation;
        public string id;

        public void SaveScene() {
        }
    }
}