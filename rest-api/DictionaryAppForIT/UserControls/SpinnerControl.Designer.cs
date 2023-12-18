namespace DictionaryAppForIT.UserControls
{
    partial class SpinnerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpinnerControl));
            this.pbSpinner = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSpinner
            // 
            this.pbSpinner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSpinner.Image = ((System.Drawing.Image)(resources.GetObject("pbSpinner.Image")));
            this.pbSpinner.Location = new System.Drawing.Point(0, 0);
            this.pbSpinner.Name = "pbSpinner";
            this.pbSpinner.Size = new System.Drawing.Size(165, 97);
            this.pbSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSpinner.TabIndex = 0;
            this.pbSpinner.TabStop = false;
            // 
            // SpinnerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbSpinner);
            this.Name = "SpinnerControl";
            this.Size = new System.Drawing.Size(165, 97);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSpinner;
    }
}
