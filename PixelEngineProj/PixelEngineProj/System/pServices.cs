using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEngine.System {
    /// <Summary>
    /// PUBLIC VARIABLES
    /// </Summary>

    /// <Summary>
    /// PRIVATE VARIABLES
    /// </Summary>

    /// <summary>
    /// Define Services
    /// </summary>
    public class pSceneService : pObject{
        public virtual void Update() {}
    }

    public class pSystemService : pObject {
        public virtual void Update() { }
    }
}
