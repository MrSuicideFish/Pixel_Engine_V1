using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Window;

namespace PixelEngine.Editor {
    public class EditorPlaceable : PixelEngine.System.pObject {
        public string name { get; set; }
        public Vector2f position { get; set; }
        public float rotation;
        public string id;

        public void SaveScene() {
        }
    }
}