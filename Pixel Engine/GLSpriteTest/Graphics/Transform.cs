using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PixelEngine.Engine;

namespace PixelEngine.Graphics
{
    [Serializable]
    public class Transform : Component
    {
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public Quaternion Rotation { get; set; }

        public Transform(GameObject _parent = null ) 
            : base( _parent )
        {

        }
    }
}