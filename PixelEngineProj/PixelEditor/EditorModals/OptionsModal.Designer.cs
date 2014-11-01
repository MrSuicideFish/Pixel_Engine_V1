namespace PixelEditor.EditorModals {
    partial class OptionsModal {
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
            this.OptionsCloseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ViewportGridColorPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ViewportBackgroundPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // OptionsCloseBtn
            // 
            this.OptionsCloseBtn.AccessibleName = "OptionsCloseBtn";
            this.OptionsCloseBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OptionsCloseBtn.Location = new System.Drawing.Point(461, 283);
            this.OptionsCloseBtn.Name = "OptionsCloseBtn";
            this.OptionsCloseBtn.Size = new System.Drawing.Size(75, 23);
            this.OptionsCloseBtn.TabIndex = 1;
            this.OptionsCloseBtn.Text = "Close";
            this.OptionsCloseBtn.UseVisualStyleBackColor = true;
            this.OptionsCloseBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Viewport Grid Color";
            // 
            // ViewportGridColorPanel
            // 
            this.ViewportGridColorPanel.AccessibleName = "ViewportGridColorPanel";
            this.ViewportGridColorPanel.BackColor = System.Drawing.Color.Gray;
            this.ViewportGridColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ViewportGridColorPanel.Location = new System.Drawing.Point(17, 37);
            this.ViewportGridColorPanel.Name = "ViewportGridColorPanel";
            this.ViewportGridColorPanel.Size = new System.Drawing.Size(193, 21);
            this.ViewportGridColorPanel.TabIndex = 3;
            this.ViewportGridColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ViewportGridColorPanel_Clicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Viewport Background Color";
            // 
            // ViewportBackgroundPanel
            // 
            this.ViewportBackgroundPanel.AccessibleName = "ViewportBackgroundPanel";
            this.ViewportBackgroundPanel.BackColor = System.Drawing.Color.Gray;
            this.ViewportBackgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ViewportBackgroundPanel.Location = new System.Drawing.Point(17, 115);
            this.ViewportBackgroundPanel.Name = "ViewportBackgroundPanel";
            this.ViewportBackgroundPanel.Size = new System.Drawing.Size(193, 21);
            this.ViewportBackgroundPanel.TabIndex = 4;
            this.ViewportBackgroundPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ViewportBackgroundPanel_Clicked);
            // 
            // OptionsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(548, 318);
            this.Controls.Add(this.ViewportBackgroundPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ViewportGridColorPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OptionsCloseBtn);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "OptionsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Options";
            this.Load += new System.EventHandler(this.OptionsModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OptionsCloseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ViewportGridColorPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel ViewportBackgroundPanel;
    }
}