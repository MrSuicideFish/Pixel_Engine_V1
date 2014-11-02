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
    public class EditorActor : Interfaces.IPlacable{
        /// <summary>
        /// PUBLIC VARIABLES
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// PRIVATE VARIABLES
        /// </summary>
        private Int16 uid;
        private static PixelEngine.Gameplay.pSprite actorSprite;
        private static FloatRect renderRect;

        /// <summary>
        /// Actor constructor.
        /// NOTE: Actors should not be assigned unique id's by anything other than the scene manager
        /// except for specific reasons?
        /// </summary>
        /// <param name="_uid"></param>
        /// <param name="_id"></param>
        public EditorActor(string _id = "New Actor", PixelEngine.Gameplay.pSprite _actorSprite = null) {
            id = _id;

            if (_actorSprite != null) {
                //Assign the sprite
                actorSprite = _actorSprite;
            } else {
                //Get the correct sprite for this type of actor
            }
        }

        public virtual void Create(){
            Editor.EngineMessage(id + " has been created!");
        }

        public virtual void Destroy(){
            
        }

        public virtual void Update(){
            Console.WriteLine("Update called on " + id);
        }
        public virtual void Draw() {
        }
        public Int16 GetUniqueId() {
            return uid;
        }

        /// <summary>
        /// Generates a new unique identifier for this actor and returns the result to the encroacher.
        /// </summary>
        public Int16 GenerateUniqueId() {
            Random _r = new Random(55012);
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