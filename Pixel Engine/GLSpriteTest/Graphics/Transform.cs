using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GLSpriteTest.Engine;

namespace GLSpriteTest.Graphics
{
    public class Transform : Component
    {
        public Vector2 Position;
        public Vector2 Scale;
        public Quaternion Rotation;
    }
}