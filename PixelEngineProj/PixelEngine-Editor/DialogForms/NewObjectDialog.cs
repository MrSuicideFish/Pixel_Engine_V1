using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using PixelEngineProj.Editor;

namespace PixelEngine_Editor.DialogForms {
    public partial class NewObjectDialog : Form {

        List<PixelEngineProj.Editor.EditorPlaceable> PlaceableClasses;
        public NewObjectDialog() {
            InitializeComponent();

            //Populate classes
            PlaceableClasses = Assembly.GetAssembly(typeof(PixelEngineProj.Editor.EditorPlaceable)).GetTypes().
                Where(t => t.IsSubclassOf(typeof(PixelEngineProj.Editor.EditorPlaceable))).
                    ToList().ConvertAll(x => (PixelEngineProj.Editor.EditorPlaceable)Activator.CreateInstance(x));

            if (PlaceableClasses != null) {
                PopulateObjectButtons();
            } else {
                Program.EngineMessage("Error: Could not find engine classes or object failed to initialize.", Program.eEngineMessageType.EXCEPTION);
            }
        }

        private void PopulateObjectButtons() {
            //Add the found classes to the nodes
            foreach(var x in PlaceableClasses){
                if (x != null) {
                    //Create a new button
                    Button _b = new Button();
                    _b.Size = new Size(64, 64);
                    _b.Text = x.name;
                    _b.Name = x.ToString();
                    _b.Click += new EventHandler(OnCreateButtonClick); //Add event handler to button

                    //Add the buton to the flowLayout
                    objectLayoutPanel.Controls.Add(_b);
                }
            }
        }

        private void OnCreateButtonClick(object sender, EventArgs e) {
            //recast the sender as button type
            Button thisButton = (Button)sender;
            if (thisButton != null) {
                string newClass = thisButton.Name;

                foreach (var t in PlaceableClasses) {
                    if (newClass == t.ToString()) {
                        DialogForms.EditObjectDialog _d = new EditObjectDialog(t);
                        _d.StartPosition = FormStartPosition.CenterScreen;

                        this.Dispose();
                        _d.ShowDialog();
                    }
                }
            }
        }
    }
}
