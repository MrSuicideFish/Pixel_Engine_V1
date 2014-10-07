using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PixelEngineProj.Interfaces {
    public interface IScene {
        string sceneName {get;set;}
        int sceneId {get;set;}

        void Draw();
        void Update();
    }
}
