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
using SFML;
using SFML.Window;
using SFML.Graphics;

namespace PixelEngine_Editor.DialogForms {
    public partial class EditObjectDialog : Form {
        PixelEngineProj.Editor.EditorPlaceable _obj;

        public EditObjectDialog(PixelEngineProj.Editor.EditorPlaceable Obj) {
            InitializeComponent();
            try {
                //Assign object to edit
                _obj = Obj;
            } catch (NullReferenceException n) {
                Program.EngineMessage(n.Message, Program.eEngineMessageType.EXCEPTION);
            } finally {
                PopulateProperties();
            }
        }

        private void EditObjectDialog_Load(object sender, EventArgs e) {}

        private void PopulateProperties() {
            Control[] newControls = new Control[5];
            var objProperties = _obj.GetType().GetProperties();

            foreach (var p in objProperties) {
                if (p.PropertyType != null && p != null) {
                    this.Controls.AddRange(GetNewControls(p.PropertyType));
                }
            }
            dialogLayout.Controls.AddRange(newControls);
        }

        private Control[] GetNewControls(Type propertyType) {
            Control[] newControls = new Control[0];

            if (newControls != null) {
                Console.WriteLine("Creating new controls");
            }
            return newControls;
        }
    }
}