using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PixelEngineProj.System;

namespace PixelEngine_Editor {
    public partial class Form1 : Form {
        private static string ProjectName;
        private static string ProjectDir;

        public string CurrentProject = "No Project";
        public static ToolStripStatusLabel WindowStatusLabel;
        private static string EngineVersion = "Pixel Engine 0.01a";

        public string projectName {
            get { return ProjectName; }
            set { ProjectName = value; }
        }
        public string projectDirectory {
            get { return ProjectDir; }
            set { ProjectDir = value; }
        }

        public Form1() {
            InitializeComponent();
            WindowStatusLabel = toolStripStatusLabel1;
            this.Text = "No Project - " + this.Text;
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

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e) {

        }
    }
}
