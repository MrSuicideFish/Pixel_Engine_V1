using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using PixelEngineProj.System;

namespace PixelEngineProj.Gameplay {
    class PixelSprite : PixelObject{

        public static Texture _tex {get;set;}
        public Vector2f position;
        public float rotation;

        public PixelSprite(string spriteTexture = null) {
            if (spriteTexture != null) {
                SetSpriteTexture(null,spriteTexture);
            }
        }

        public Texture GetSpriteTexture() {return _tex;}

        public void SetSpriteTexture(Texture newTexture = null, string newTexturePath = "") {
            if (newTexture != null) {
                _tex.Dispose();
                _tex = new Texture(newTexture);
            } else {
                if (newTexturePath != null && newTexturePath != "") {
                    _tex.Dispose();
                    _tex = new Texture(newTexturePath);
                } else {
                    Console.WriteLine("Neither texture nor path were disclosed. SetSpriteTexture() failed with -1.");
                }
            }
        }

        protected void Update() {
            base.Update();
        }

        protected void Draw() {
            base.Draw();
        }
    }
}
