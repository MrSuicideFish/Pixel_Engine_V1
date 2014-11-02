using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEditor.Interfaces {
    interface IPlacable {
        void Create();
        void Destroy();
        void Update();
    }
}
