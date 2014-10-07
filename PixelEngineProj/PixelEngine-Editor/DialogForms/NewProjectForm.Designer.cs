namespace PixelEngine_Editor.DialogForms {
    partial class NewProjectForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProjectForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ProjectNameTextBox = new System.Windows.Forms.TextBox();
            this.ProjectLocationTextBox = new System.Windows.Forms.TextBox();
            this.BrowseLocButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateProjButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project Name";
            // 
            // ProjectNameTextBox
            // 
            this.ProjectNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNameTextBox.Location = new System.Drawing.Point(12, 36);
            this.ProjectNameTextBox.Name = "ProjectNameTextBox";
            this.ProjectNameTextBox.Size = new System.Drawing.Size(558, 27);
            this.ProjectNameTextBox.TabIndex = 1;
            this.ProjectNameTextBox.TextChanged += new System.EventHandler(this.ProjectNameTextBox_TextChanged);
            // 
            // ProjectLocationTextBox
            // 
            this.ProjectLocationTextBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ProjectLocationTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectLocationTextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.ProjectLocationTextBox.Location = new System.Drawing.Point(12, 100);
            this.ProjectLocationTextBox.Name = "ProjectLocationTextBox";
            this.ProjectLocationTextBox.ReadOnly = true;
            this.ProjectLocationTextBox.Size = new System.Drawing.Size(479, 27);
            this.ProjectLocationTextBox.TabIndex = 2;
            this.ProjectLocationTextBox.Text = "Project Directory";
            // 
            // BrowseLocButton
            // 
            this.BrowseLocButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BrowseLocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseLocButton.Location = new System.Drawing.Point(498, 100);
            this.BrowseLocButton.Name = "BrowseLocButton";
            this.BrowseLocButton.Size = new System.Drawing.Size(73, 27);
            this.BrowseLocButton.TabIndex = 3;
            this.BrowseLocButton.Text = ". . .";
            this.BrowseLocButton.UseVisualStyleBackColor = false;
            this.BrowseLocButton.Click += new System.EventHandler(this.BrowseLocButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Project Folder";
            // 
            // CreateProjButton
            // 
            this.CreateProjButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.CreateProjButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateProjButton.Location = new System.Drawing.Point(366, 136);
            this.CreateProjButton.Name = "CreateProjButton";
            this.CreateProjButton.Size = new System.Drawing.Size(125, 27);
            this.CreateProjButton.TabIndex = 5;
            this.CreateProjButton.Text = "Create";
            this.CreateProjButton.UseVisualStyleBackColor = false;
            this.CreateProjButton.Click += new System.EventHandler(this.CreateProjButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.CancelButton.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.CancelButton.Location = new System.Drawing.Point(498, 136);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(74, 27);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NewProjectForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(583, 177);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.CreateProjButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrowseLocButton);
            this.Controls.Add(this.ProjectLocationTextBox);
            this.Controls.Add(this.ProjectNameTextBox);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "NewProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Project";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ProjectNameTextBox;
        private System.Windows.Forms.TextBox ProjectLocationTextBox;
        private System.Windows.Forms.Button BrowseLocButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateProjButton;
        private System.Windows.Forms.Button CancelButton;
    }
}