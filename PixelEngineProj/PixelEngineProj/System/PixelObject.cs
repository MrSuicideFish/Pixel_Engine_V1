using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace PixelEngineProj.System {
    public class PixelObject{
        public string id;

        public PixelObject(string _id = null) {
            //Assign an id to this object
            if (_id == null) {
                Random rand = new Random();
                id = rand.Next(0, 30000).ToString();
            } else {
                id = _id;
            }
        }

        protected void Update(){
        }

        protected void Draw() {
        }
    }
}