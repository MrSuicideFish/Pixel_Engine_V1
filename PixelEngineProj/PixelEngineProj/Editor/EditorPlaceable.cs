using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;

namespace PixelEngineProj.Editor {
    public class EditorPlaceable : PixelEngineProj.System.PixelObject{
        public string name { get; set; }
        public Vector2f position { get; set; }
        public float rotation;
        public string id;

        public void SaveScene() {
        }
    }
}