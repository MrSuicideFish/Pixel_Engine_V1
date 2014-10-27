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
            this.button1 = new System.Windows.Forms.Button();
            this.OptionsCloseBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ViewportGridColorPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(380, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            // 
            // OptionsModal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(548, 318);
            this.Controls.Add(this.ViewportGridColorPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OptionsCloseBtn);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsModal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor Options";
            this.Load += new System.EventHandler(this.OptionsModal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OptionsCloseBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ViewportGridColorPanel;
    }
}