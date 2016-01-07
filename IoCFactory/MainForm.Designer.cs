namespace IoCFactory
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openDialogButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openDialogButton
            // 
            this.openDialogButton.Location = new System.Drawing.Point(104, 100);
            this.openDialogButton.Name = "openDialogButton";
            this.openDialogButton.Size = new System.Drawing.Size(75, 23);
            this.openDialogButton.TabIndex = 0;
            this.openDialogButton.Text = "Open dialog";
            this.openDialogButton.UseVisualStyleBackColor = true;
            this.openDialogButton.Click += new System.EventHandler(this.openDialogButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(104, 158);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 1;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.openButton);
            this.Controls.Add(this.openDialogButton);
            this.Name = "MainForm";
            this.Text = "Main form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openDialogButton;
        private System.Windows.Forms.Button openButton;
    }
}

