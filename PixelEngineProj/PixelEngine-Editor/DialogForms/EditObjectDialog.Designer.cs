namespace PixelEngine_Editor.DialogForms {
    partial class EditObjectDialog {
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
            this.dialogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.SuspendLayout();
            // 
            // dialogLayout
            // 
            this.dialogLayout.ColumnCount = 2;
            this.dialogLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dialogLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dialogLayout.Location = new System.Drawing.Point(12, 12);
            this.dialogLayout.Name = "dialogLayout";
            this.dialogLayout.RowCount = 2;
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dialogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.dialogLayout.Size = new System.Drawing.Size(407, 309);
            this.dialogLayout.TabIndex = 0;
            // 
            // EditObjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(431, 333);
            this.Controls.Add(this.dialogLayout);
            this.Name = "EditObjectDialog";
            this.Text = "Edit Object";
            this.Load += new System.EventHandler(this.EditObjectDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel dialogLayout;
    }
}