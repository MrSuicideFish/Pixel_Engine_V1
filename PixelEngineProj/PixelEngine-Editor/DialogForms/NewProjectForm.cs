using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PixelEngine_Editor.DialogForms {
    public partial class NewProjectForm : Form {
        private Form1 MainWindow;

        string newProjectDirectory;
        string newProjectName;

        public NewProjectForm() {
            InitializeComponent();
            MainWindow = new Form1();
        }

        private void ProjectNameTextBox_TextChanged(object sender, EventArgs e) {

        }

        private void CancelButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void BrowseLocButton_Click(object sender, EventArgs e) {
            FolderBrowserDialog SaveDialog = new FolderBrowserDialog();
            SaveDialog.ShowDialog();
            ProjectLocationTextBox.Text = SaveDialog.SelectedPath;
            newProjectDirectory = SaveDialog.SelectedPath;
        }

        private void CreateProjButton_Click(object sender, EventArgs e) {
            //Set the name and dir of the project
            newProjectName = ProjectNameTextBox.Text;
            MainWindow.projectDirectory = newProjectDirectory;
            MainWindow.projectName = newProjectName;

            Form1.WindowStatusLabel.Text = "Loading Project...";

            //Create project folder structure
            Directory.CreateDirectory(newProjectDirectory + "/" + newProjectName + "/Resources");
            Directory.CreateDirectory(newProjectDirectory + "/" + newProjectName + "/Src");
            Directory.CreateDirectory(newProjectDirectory + "/" + newProjectName + "/Dependencies");
            Directory.CreateDirectory(newProjectDirectory + "/" + newProjectName + "/bin");

            //Re-load the editor
            Program.LoadProject(newProjectName, newProjectDirectory + "/" + newProjectName);
           
            this.Close();
        }
    }
}