using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;

namespace PixelEditor {
    /// <summary>
    /// The EditorActor class is the editor-compliant version of pActor
    /// with editor-specific members and methods.
    /// </summary>
    public class EditorActor : Interfaces.IPlacable, SFML.Graphics.Drawable{
        /// <summary>
        /// PUBLIC VARIABLES
        /// </summary>
        public string id { get; set; }
        public PixelEngine.Gameplay.pSprite actorSprite;
        public Vector2f position { get; set; }
        public float rotation { get; set; } //proabbly won't need this?

        /// <summary>
        /// PRIVATE VARIABLES
        /// </summary>
        private Int16 uid;
        private static FloatRect boundingBox;

        /// <summary>
        /// Actor constructor.
        /// NOTE: Actors should not be assigned unique id's by anything other than the scene manager
        /// except for specific reasons?
        /// </summary>
        /// <param name="_uid"></param>
        /// <param name="_id"></param>
        public EditorActor(string _id = "New Actor", Vector2f _position = new Vector2f(), FloatRect _renderRect = new FloatRect(), PixelEngine.Gameplay.pSprite _actorSprite = null) {
            id = _id;
            if (_actorSprite != null) {
                //Assign the sprite
                actorSprite = _actorSprite;
                position = _actorSprite.Position;
            } else {
                //Get the correct sprite for this type of actor
                actorSprite = new PixelEngine.Gameplay.pSprite("EditorResources/EditorActorIcon.png", new SFML.Graphics.IntRect(0, 0, 64, 64), _position); //Default actor sprite
                position = Form1.mouseWorldPos;
            }
            boundingBox = new FloatRect(actorSprite.GetGlobalBounds().Left, actorSprite.GetGlobalBounds().Top, actorSprite.GetGlobalBounds().Width, actorSprite.GetGlobalBounds().Height);
        }

        public virtual void Create(){
        }

        public virtual int Destroy(){
            return 0;
        }

        public virtual void Update(){
            //Update the actor's sprite
            actorSprite.Position = position;
            actorSprite.Rotation = rotation;
            boundingBox.Width = actorSprite.Texture.Size.X;
            boundingBox.Height = actorSprite.Texture.Size.Y;
        }

        public virtual void Draw(RenderTarget target, RenderStates states) {
            actorSprite.Draw(target, states);
        }

        public Int16 GetUniqueId() {
            return uid;
        }

        public FloatRect GetBoundingBox() {
            return boundingBox;
        }

        /// <summary>
        /// Generates a new unique identifier for this actor and returns the result to the encroacher.
        /// </summary>
        public Int16 GenerateUniqueId() {
            Random _r = new Random();
            uid = Math.Abs((Int16)_r.Next(1000, 90000));
            //Return a warning if the identifier is invalid
            if (uid <= 0) {
                Editor.EngineMessage("WARNING: Editor Actor failed to produce a valid unique identifier. Is this intentional?", Editor.eEngineMessageType.WARNING);
            }
            return uid;
        }

        public void SetActorSprite() {

        }
    }
}