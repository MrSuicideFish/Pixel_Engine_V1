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
        private string CurrentDir;

        public ResourcesForm() {
            InitializeComponent();
            if (Program.bProjectLoaded) {
                //Populate the directories list
                PopulateBrowser(Program._projdir+"/Resources");
                CurrentDir = Program._projdir+"/Resources";
            }
            IconSizeTrackBar.Value = 5;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void PopulateBrowser(string Dir) {
            //Get the browser icons
            Image FolderIcon = Image.FromFile("Resources/FolderIcon.png");
            Image FolderUpIcon = Image.FromFile("Resources/FolderUpIcon.png");

            if (Directory.Exists(Dir)) {
                CurrentDir = Dir;
                //Do up directory
                if (Dir == Program._projdir + "/Resources") {
                    Button UpFolder = new Button();
                    UpFolder.ForeColor = Color.White;
                    UpFolder.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    UpFolder.Size = new Size(IconSizeTrackBar.Value + 20, IconSizeTrackBar.Value);
                    UpFolder.Text = "Up";
                    UpFolder.FlatStyle = FlatStyle.Flat;
                    UpFolder.FlatAppearance.BorderSize = 0;
                    UpFolder.Image = FolderUpIcon;
                    ResourcePanel.Controls.Add(UpFolder);
                }
                //populate sub directories
                string[] Items = new string[Directory.GetFileSystemEntries(Dir).Length];
                Items = Directory.GetFileSystemEntries(Dir);

                foreach(string item in Items){
                    DirectoryInfo d = new DirectoryInfo(item);
                    Button newFolder = new Button();
                    newFolder.ForeColor = Color.White;
                    newFolder.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    newFolder.Text = d.Name;
                    newFolder.Size = new Size(50, 50);
                    newFolder.TextAlign = ContentAlignment.MiddleCenter;
                    newFolder.FlatStyle = FlatStyle.Flat;
                    newFolder.FlatAppearance.BorderSize = 0;
                    if (Directory.Exists(item)) {
                        newFolder.Image = FolderIcon;
                        newFolder.ImageAlign = ContentAlignment.MiddleCenter;
                        //newFolder.Click += new EventHandler(Folder_DoubleClick(newFolder, d.FullName));
                    }
                    ResourcePanel.Controls.Add(newFolder);
                    ResourcePanel.AutoSize = true;
                }
            }
        }

        private void Folder_DoubleClick(object sender, EventArgs e) {
            Console.WriteLine(sender);
            //Clear all of the buttons in the panel
            while (ResourcePanel.Controls.Count > 0) {
                for (int i = 0; i < ResourcePanel.Controls.Count; i++) {
                    ResourcePanel.Controls[i].Dispose();
                }
            }

            //Populate the panel again
            //PopulateBrowser(CurrentDir + sender.
        }
        private void IconSizeTrackBar_Scroll(object sender, EventArgs e) {
            if (IconSizeTrackBar.Value != 0) {
                //resize icons
                foreach (Control control in ResourcePanel.Controls) {
                    control.Size = new Size(IconSizeTrackBar.Value * 30 + 20, IconSizeTrackBar.Value * 30 + 5);
                }
            }
        }

        private void ResourcesContextMenu_Click(object sender, EventArgs e) {
            //Refresh resource browser
            while (ResourcePanel.Controls.Count > 0) {
                for (int i = 0; i < ResourcePanel.Controls.Count; i++) {
                    ResourcePanel.Controls[i].Dispose();
                }
            }
            PopulateBrowser(CurrentDir);
        }

        private void openInExplorerToolStripMenuItem_Click(object sender, EventArgs e) {
            //System.Diagnostics.Process.Start(CurrentDir);
        }
    }
}
