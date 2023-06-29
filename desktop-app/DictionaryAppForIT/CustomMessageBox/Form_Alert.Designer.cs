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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblNghia = new System.Windows.Forms.Label();
            this.lblPhienAm = new System.Windows.Forms.Label();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTuVung = new System.Windows.Forms.Label();
            this.pbCat = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbAvt = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblNghia
            // 
            this.lblNghia.AutoSize = true;
            this.lblNghia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNghia.ForeColor = System.Drawing.Color.White;
            this.lblNghia.Location = new System.Drawing.Point(114, 48);
            this.lblNghia.Name = "lblNghia";
            this.lblNghia.Size = new System.Drawing.Size(120, 15);
            this.lblNghia.TabIndex = 0;
            this.lblNghia.Text = "Thành phần, bộ phận";
            // 
            // lblPhienAm
            // 
            this.lblPhienAm.AutoSize = true;
            this.lblPhienAm.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPhienAm.ForeColor = System.Drawing.Color.White;
            this.lblPhienAm.Location = new System.Drawing.Point(79, 0);
            this.lblPhienAm.Margin = new System.Windows.Forms.Padding(0);
            this.lblPhienAm.Name = "lblPhienAm";
            this.lblPhienAm.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.lblPhienAm.Size = new System.Drawing.Size(84, 21);
            this.lblPhienAm.TabIndex = 0;
            this.lblPhienAm.Text = " /kəmˈpoʊ.nənt/";
            this.lblPhienAm.UseCompatibleTextRendering = true;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 26;
            this.guna2Elipse1.TargetControl = this;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblTuVung);
            this.flowLayoutPanel1.Controls.Add(this.lblPhienAm);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(114, 24);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(280, 29);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // lblTuVung
            // 
            this.lblTuVung.AutoSize = true;
            this.lblTuVung.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTuVung.ForeColor = System.Drawing.Color.White;
            this.lblTuVung.Location = new System.Drawing.Point(0, 0);
            this.lblTuVung.Margin = new System.Windows.Forms.Padding(0);
            this.lblTuVung.Name = "lblTuVung";
            this.lblTuVung.Size = new System.Drawing.Size(79, 23);
            this.lblTuVung.TabIndex = 1;
            this.lblTuVung.Text = "Application";
            this.lblTuVung.UseCompatibleTextRendering = true;
            // 
            // pbCat
            // 
            this.pbCat.BackColor = System.Drawing.Color.Transparent;
            this.pbCat.ImageRotate = 0F;
            this.pbCat.Location = new System.Drawing.Point(9, 6);
            this.pbCat.Name = "pbCat";
            this.pbCat.Size = new System.Drawing.Size(80, 76);
            this.pbCat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCat.TabIndex = 44;
            this.pbCat.TabStop = false;
            this.pbCat.UseTransparentBackground = true;
            // 
            // pbAvt
            // 
            this.pbAvt.BackColor = System.Drawing.Color.Transparent;
            this.pbAvt.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbAvt.ImageRotate = 0F;
            this.pbAvt.Location = new System.Drawing.Point(0, 0);
            this.pbAvt.Name = "pbAvt";
            this.pbAvt.Size = new System.Drawing.Size(96, 88);
            this.pbAvt.TabIndex = 42;
            this.pbAvt.TabStop = false;
            this.pbAvt.UseTransparentBackground = true;
            // 
            // pbClose
            // 
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(291, 6);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(24, 30);
            this.pbClose.TabIndex = 3;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // Form_Alert
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(325, 88);
            this.Controls.Add(this.pbCat);
            this.Controls.Add(this.pbAvt);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.lblNghia);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Alert";
            this.Text = "Form_Alert";
            this.Load += new System.EventHandler(this.Form_Alert_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAvt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbClose;
        private System.Windows.Forms.Label lblNghia;
        private System.Windows.Forms.Label lblPhienAm;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblTuVung;
        private Guna.UI2.WinForms.Guna2PictureBox pbAvt;
        private Guna.UI2.WinForms.Guna2PictureBox pbCat;
    }
}