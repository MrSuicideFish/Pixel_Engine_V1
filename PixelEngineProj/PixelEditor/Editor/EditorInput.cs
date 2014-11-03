using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;

namespace PixelEditor {
    /// <summary>
    /// The editor input class is responsible for the construction of button commands.
    /// </summary>
    
    //TODO: This class....  :p
    public static class EditorInput{
        /// <summary>
        /// Modify Key Instances
        /// </summary>
        /// 
        public static byte Ctrl { get; set; }
        public static byte Space { get; set; }
        public static byte Alt { get; set; }
        public static byte bModifier { get; set; }

        public static void Update() {
            bModifier = 0;
            if (Keyboard.IsKeyPressed(Keyboard.Key.LControl) || Keyboard.IsKeyPressed(Keyboard.Key.RControl)) {
                Ctrl = 1;
                bModifier = 1;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space)) {
                Space = 1;
                bModifier = 1;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.LAlt) || Keyboard.IsKeyPressed(Keyboard.Key.RAlt)) {
                Alt = 1;
                bModifier = 1;
            }
            if (!Keyboard.IsKeyPressed(Keyboard.Key.LAlt) && !Keyboard.IsKeyPressed(Keyboard.Key.RAlt)) {
                Alt = 0;
            }
            if (!Keyboard.IsKeyPressed(Keyboard.Key.LControl) && !Keyboard.IsKeyPressed(Keyboard.Key.RControl)) {
                Ctrl = 0;
            }
            if (!Keyboard.IsKeyPressed(Keyboard.Key.Space)) {
                Space = 0;
            }
        }
    }
}
