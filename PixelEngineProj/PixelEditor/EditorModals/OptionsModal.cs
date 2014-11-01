using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using PixelEngineProj;

namespace PixelEditor.EditorModals {
    public partial class OptionsModal : Form {
        public OptionsModal() {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) {
            //Save the config
            Config.SaveConfig();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e) {
        }

        private void OptionsModal_Load(object sender, EventArgs e) {
            //Set the color panel backgrounds to Form1 colors
            ViewportBackgroundPanel.BackColor = System.Drawing.Color.FromArgb(Form1.viewportBackgroundColor.A, Form1.viewportBackgroundColor.R, Form1.viewportBackgroundColor.G, Form1.viewportBackgroundColor.B);
            ViewportGridColorPanel.BackColor = System.Drawing.Color.FromArgb(Form1._grid.GetGridColor().A, Form1._grid.GetGridColor().R, Form1._grid.GetGridColor().G, Form1._grid.GetGridColor().B);
        }

        /// <summary>
        /// Do viewport grid color picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewportGridColorPanel_Clicked(object sender, MouseEventArgs e) {
            //Display the color dialog
            ColorDialog _dialog = new ColorDialog();
            _dialog.ShowDialog();

            //Apply the new color to the preview box
            if (_dialog.Color != System.Drawing.Color.Empty) {
                ViewportGridColorPanel.BackColor = _dialog.Color;
                Form1._grid.SetGridColor(new SFML.Graphics.Color(_dialog.Color.R, _dialog.Color.G, _dialog.Color.B, _dialog.Color.A));

                //Save settings to config state
                Config.SetData("EditorViewportGridColor", new SFML.Graphics.Color(_dialog.Color.R, _dialog.Color.G, _dialog.Color.B, _dialog.Color.A).ToString()); //Save the background color
            }
        }

        /// <summary>
        /// Do viewport background color picker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewportBackgroundPanel_Clicked(object sender, MouseEventArgs e) {
            //Display the color dialog
            ColorDialog _dialog = new ColorDialog();
            _dialog.ShowDialog();

            //Apply the new color to the preview box
            if (_dialog.Color != System.Drawing.Color.Empty) {
                ViewportBackgroundPanel.BackColor = _dialog.Color;
                Form1.viewportBackgroundColor = new SFML.Graphics.Color(_dialog.Color.R, _dialog.Color.G, _dialog.Color.B, _dialog.Color.A);
                //Save this change to the config
                Config.SetData("EditorViewportBackgroundColor", new SFML.Graphics.Color(_dialog.Color.R, _dialog.Color.G, _dialog.Color.B, _dialog.Color.A).ToString()); //Save the background color
            }
        }
    }
}