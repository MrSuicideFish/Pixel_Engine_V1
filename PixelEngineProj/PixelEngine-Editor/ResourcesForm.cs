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

namespace PixelEngine_Editor {
    public partial class ResourcesForm : Form {
        private string resourceDir = "";

        public ResourcesForm() {
            InitializeComponent();
            resourceDir = (string)Program.CfgGetNodeValue("ResourceDirectory"); //Get resource directory from config file
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e) {}

        private void PopulateBrowser(string Dir) {
            //Get the browser icons
            Image FolderIcon = Image.FromFile("Resources/FolderIcon.png");
            Image FolderUpIcon = Image.FromFile("Resources/FolderUpIcon.png");
        }

        private void FindResources() {
        }

        private void IconSizeTrackBar_Scroll(object sender, EventArgs e) {
        }

        private void ResourcesContextMenu_Click(object sender, EventArgs e) {
        }

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void AssignResourceDir() {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.ShowDialog();

            if (Directory.Exists(browser.SelectedPath)) {
                resourceDir = browser.SelectedPath;
                Program.EngineMessage("New resource directory: " + resourceDir, Program.eEngineMessageType.CONFIRM);

                //Save the cfg
                Program.CfgWriteNode("ResourceDirectory", resourceDir);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (resourceDir != null && resourceDir != "") {
                OpenFileDialog _d = new OpenFileDialog();
                _d.Filter = "Image Files (.png)|*.png|All Files (*.*)|*.*";
                _d.ShowDialog();

                if (_d.FileName != "") {
                    Console.WriteLine("File Ok");
                }
            } else {
                var msgOk = MessageBox.Show("You must first specify a resource directory. Would you like to do that now?", "Missing Resources Folder", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (msgOk == DialogResult.Yes) {
                    AssignResourceDir();
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            AssignResourceDir();
        }

        private static void something() {

        }
    }
}