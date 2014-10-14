namespace PixelEngine_Editor.DialogForms {
    partial class NewObjectDialog {
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
            this.objectLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.dialogLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // objectLayoutPanel
            // 
            this.objectLayoutPanel.Location = new System.Drawing.Point(3, 35);
            this.objectLayoutPanel.Name = "objectLayoutPanel";
            this.objectLayoutPanel.Size = new System.Drawing.Size(465, 288);
            this.objectLayoutPanel.TabIndex = 0;
            // 
            // dialogLabel
            // 
            this.dialogLabel.AutoSize = true;
            this.dialogLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dialogLabel.Location = new System.Drawing.Point(-1, 12);
            this.dialogLabel.Name = "dialogLabel";
            this.dialogLabel.Size = new System.Drawing.Size(218, 20);
            this.dialogLabel.TabIndex = 1;
            this.dialogLabel.Text = "Select a new object to create.";
            // 
            // NewObjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(472, 328);
            this.Controls.Add(this.dialogLabel);
            this.Controls.Add(this.objectLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewObjectDialog";
            this.Padding = new System.Windows.Forms.Padding(1000);
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Create New Object";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel objectLayoutPanel;
        private System.Windows.Forms.Label dialogLabel;

    }
}