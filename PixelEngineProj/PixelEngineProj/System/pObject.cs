using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace PixelEngine.System {
    public class pObject{
        public string id;
        public bool bEnabled { get; set; }

        /// <summary>
        /// Allow pObject to call it's constructor methods while disabled
        /// </summary>
        public pObject() {

        }

        public virtual void Begin() {

        }

        public virtual void Update() { }
    }
}