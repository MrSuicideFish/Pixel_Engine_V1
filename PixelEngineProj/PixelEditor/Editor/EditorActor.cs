using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;

namespace PixelEditor {
    /// <summary>
    /// The EditorActor class is the editor-compliant version of pActor
    /// with editor-specific members and methods.
    /// </summary>
    public class EditorActor : PixelEngine.System.pActor, Interfaces.IPlacable{
        public EditorActor()
            : base() {

        }
    }
}
