using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using PixelEngineProj;
using PixelEngineProj.System;

namespace PixelEditor {
    static class Program {
        /// <summary>
        /// Public Variables
        /// </summary>
        public static double deltaTime { get; set; }
        public static PixelScene SCENE;
        /// <summary>
        /// Private Variables
        /// </summary>
        private static Form1 EDITOR;

        [STAThread]
        static void Main() {
            //Init the scene
            SCENE = new PixelScene();

            //Init the main editor
            EDITOR = new Form1();
            EDITOR.Show();
            EDITOR.Focus();

            while (EDITOR.Visible) {
                Application.DoEvents();
            }
        }
    }


}
