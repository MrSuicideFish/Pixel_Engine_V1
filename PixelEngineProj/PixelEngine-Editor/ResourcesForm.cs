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
        string[] resourceDirFiles;
        private int selectedResource;

        public ResourcesForm() {
            InitializeComponent();
            resourceDir = (string)Program.CfgGetNodeValue("ResourceDirectory"); //Get resource directory from config file
            if (resourceDir != "" && resourceDir != null) {
                PopulateBrowser();
            }
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e) {}
        private void IconSizeTrackBar_Scroll(object sender, EventArgs e) {}
        private void ResourcesContextMenu_Click(object sender, EventArgs e) {}
        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e) {}

        private void AssignResourceDir() {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.ShowDialog();
            if (Directory.Exists(browser.SelectedPath)) {
                resourceDir = browser.SelectedPath;
                Program.EngineMessage("New resource directory: " + resourceDir, Program.eEngineMessageType.CONFIRM);
                //Save the cfg
                Program.CfgWriteNode("ResourceDirectory", resourceDir);

                PopulateBrowser();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            if (resourceDir != null && resourceDir != "") {
                OpenFileDialog _d = new OpenFileDialog();
                _d.InitialDirectory = resourceDir;
                _d.Filter = "Image Files (.png)|*.png|All Files (*.*)|*.*";
                _d.ShowDialog();
                if (_d.FileName != "") {
                    ImportResource(_d.FileName);
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

        private void PopulateBrowser() {
            if (resourceDir != "") {
                //Get the browser icons
                Image FolderIcon = Image.FromFile("Resources/FolderIcon.png");
                Image FolderUpIcon = Image.FromFile("Resources/FolderUpIcon.png");

                //Clear the resource panel
                ResourcePanel.Controls.Clear();

                resourceDirFiles = Directory.GetFiles(resourceDir);
                foreach (string i in resourceDirFiles) {
                    Button newButton = resourceButton(i);
                    ResourcePanel.Controls.Add(newButton);
                }
            }
        }

        private Button resourceButton(string _f) {
            //Create a new button
            Button _b = new Button();

            //Modify text and dimensions
            _b.Name = Path.GetFileName(_f);
            _b.Text = Path.GetFileName(_f).Substring(0, Path.GetFileName(_f).IndexOf('.'));
            _b.Height = 100; _b.Width = 100;

            //Add Background and border
            //Todo: Add different icon for each type of file
            _b.BackgroundImage = Image.FromFile("Resources/SpriteIcon.png");
            _b.BackgroundImageLayout = ImageLayout.Zoom;

            _b.Font = new Font("Resources/pixelmix.ttf", 16, FontStyle.Bold);
            _b.ForeColor = Color.White;
            _b.TextAlign = ContentAlignment.BottomCenter;

            _b.FlatAppearance.BorderSize = 0;
            _b.FlatAppearance.MouseOverBackColor = Color.DarkGray;
            _b.FlatAppearance.CheckedBackColor = Color.DarkKhaki;
            _b.FlatStyle = FlatStyle.Flat;

            //Add events
            _b.Click += new EventHandler(OnResourceItemClick);

            //Retun the new button
            return _b;
        }

        private void OnResourceItemClick(object sender, EventArgs e) {
            Button newButton = (Button)sender;
            SelectResourceItem(newButton.Name);
        }

        private void SelectResourceItem(string ResourceName) {
            for (int i = 0; i < resourceDirFiles.Length; i++) {
                if (ResourceName == Path.GetFileName(resourceDirFiles[i])) {
                    selectedResource = i;
                }
            }
        }

        public string GetSelectedResourceItem() {
            Console.WriteLine(resourceDirFiles[selectedResource]);
            return resourceDirFiles[selectedResource];
        }

        private void ImportResource(string _dir) {
            Program.EngineMessage("Importing new asset: " + _dir, Program.eEngineMessageType.NONE);
            if (File.Exists(_dir)) {
                //Search the current resource directory to see if the same file exists
                string newFileName = Path.GetFileName(_dir);
            } 
        }

        private void entityToolStripMenuItem_Click(object sender, EventArgs e) {
            //Create new resource dialog
            DialogForms.NewObjectDialog newResourceDialog;

            //Set dialog properties
            newResourceDialog = new DialogForms.NewObjectDialog();
            newResourceDialog.StartPosition = FormStartPosition.CenterScreen;
            newResourceDialog.TopMost = true;

            //Show the dialog window
            newResourceDialog.ShowDialog();
        }
    }
}