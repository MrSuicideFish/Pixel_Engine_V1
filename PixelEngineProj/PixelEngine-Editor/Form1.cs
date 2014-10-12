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

namespace PixelEngine_Editor {
    public partial class Form1 : Form {
        /// <summary>
        /// Public Vars 
        /// </summary>
        private static string ProjectName;
        private static string ProjectDir;

        public string CurrentProject = "No Project";
        public static ToolStripStatusLabel WindowStatusLabel;
        private static string EngineVersion = PixelEngineProj.Program.engineName;

        public string projectName {
            get { return ProjectName; }
            set { ProjectName = value; }
        }
        public string projectDirectory {
            get { return ProjectDir; }
            set { ProjectDir = value; }
        }

        /// <summary>
        /// Private vars
        /// </summary>
        List<PixelEngineProj.Editor.EditorPlaceable> PlaceableClasses;

        public Form1() {
            InitializeComponent();
            WindowStatusLabel = toolStripStatusLabel1;
            this.Text = CurrentProject + EngineVersion;
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            statusStrip1.ResetText();
            
            statusStrip1.Update();
        }

        public string WindowStatus {
            get { return toolStripStatusLabel1.Text; }
            set { toolStripStatusLabel1.Text = value; }
        }

        private void newMapToolStripMenuItem_Click(object sender, EventArgs e) {
            //Do new project dialog window
            DialogForms.NewProjectForm newProjForm = new DialogForms.NewProjectForm();
            newProjForm.Show();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {Application.Exit();}
        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {}
        private void Form1_Load(object sender, EventArgs e) {}

        private void entityList_Load(object sender, EventArgs e) {
            try {
                //Create the entity node
                entityList.Nodes.Add("Placeable Objects");

                //Populate the entity list
                Program.EngineMessage("Populating entity list", "Warning");
                PlaceableClasses = Assembly.GetAssembly(typeof(PixelEngineProj.Editor.EditorPlaceable)).GetTypes().
                    Where(t => t.IsSubclassOf(typeof(PixelEngineProj.Editor.EditorPlaceable))).
                    ToList().ConvertAll(x => (PixelEngineProj.Editor.EditorPlaceable)Activator.CreateInstance(x));

                //Add the found classes to the nodes
                foreach (var types in PlaceableClasses) {
                    var newNode = entityList.Nodes[0].Nodes.Add(types.name);
                    newNode.Name = types.ToString();
                    Program.EngineMessage("Register: " + types.name);
                }


            } catch (MissingMemberException mem) {
                Program.EngineMessage(mem.Message, "Exception");
            } finally {
                Program.EngineMessage("Populating entity list: Done!", "Confirm");
            }
        }

        private void entityList_DblClick(object sender, TreeNodeMouseClickEventArgs e) {
            Console.WriteLine(e.Node.Name + " was clicked");
        }

        private void entityList_Dragged(object sender, ItemDragEventArgs e) {
            Console.WriteLine(e.Item.ToString() + " was dragged");
        }
    }
}