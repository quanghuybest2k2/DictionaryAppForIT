namespace DictionaryAppForIT.CustomMessageBox
{
    partial class Form_Alert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Alert));
            this.lblTuVung = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.lblNghia = new System.Windows.Forms.Label();
            this.lblPhienAm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTuVung
            // 
            this.lblTuVung.AutoSize = true;
            this.lblTuVung.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuVung.ForeColor = System.Drawing.Color.White;
            this.lblTuVung.Location = new System.Drawing.Point(59, 19);
            this.lblTuVung.Name = "lblTuVung";
            this.lblTuVung.Size = new System.Drawing.Size(120, 23);
            this.lblTuVung.TabIndex = 0;
            this.lblTuVung.Text = "Component";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pbClose
            // 
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(327, 32);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(24, 30);
            this.pbClose.TabIndex = 3;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // lblNghia
            // 
            this.lblNghia.AutoSize = true;
            this.lblNghia.ForeColor = System.Drawing.Color.White;
            this.lblNghia.Location = new System.Drawing.Point(59, 49);
            this.lblNghia.Name = "lblNghia";
            this.lblNghia.Size = new System.Drawing.Size(175, 21);
            this.lblNghia.TabIndex = 0;
            this.lblNghia.Text = "Thành phần, bộ phận";
            // 
            // lblPhienAm
            // 
            this.lblPhienAm.AutoSize = true;
            this.lblPhienAm.ForeColor = System.Drawing.Color.White;
            this.lblPhienAm.Location = new System.Drawing.Point(185, 21);
            this.lblPhienAm.Name = "lblPhienAm";
            this.lblPhienAm.Size = new System.Drawing.Size(136, 21);
            this.lblPhienAm.TabIndex = 0;
            this.lblPhienAm.Text = " /kəmˈpoʊ.nənt/";
            // 
            // Form_Alert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(374, 94);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblPhienAm);
            this.Controls.Add(this.lblNghia);
            this.Controls.Add(this.lblTuVung);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Alert";
            this.Text = "Form_Alert";
            this.Load += new System.EventHandler(this.Form_Alert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTuVung;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label lblNghia;
        private System.Windows.Forms.Label lblPhienAm;
    }
}