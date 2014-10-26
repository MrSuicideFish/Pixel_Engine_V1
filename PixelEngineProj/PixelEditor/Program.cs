using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using PixelEngineProj.System;

namespace PixelEditor {
    static class Program {
        /// <summary>
        /// Public Variables
        /// </summary>

        /// <summary>
        /// Private Variables
        /// </summary>
        private static Form1 EDITOR;

        [STAThread]
        static void Main() {
            //Init the level


            //Init the main editor
            EDITOR = new Form1();
            EDITOR.Show();

            while (EDITOR.Visible) {
                Application.DoEvents();
            }
        }
    }


}
