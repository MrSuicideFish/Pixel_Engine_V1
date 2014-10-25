using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace PixelEngineEditor {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            //create a drawing surface

            RenderWindow renderWindow = new RenderWindow(VideoMode.DesktopMode, "Sometihng");
            renderWindow.Display();

            //EditorViewportContainer.Controls.Add();
        }
    }
}
