
namespace DictionaryAppForIT.UserControls.MiniGame
{
    partial class UC_MG_BtnDieuHuong
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
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnNen = new Guna.UI2.WinForms.Guna2Panel();
            this.lblSo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.pnNen.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Tomato;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(37, 10);
            this.guna2PictureBox1.TabIndex = 9;
            this.guna2PictureBox1.TabStop = false;
            // 
            // pnNen
            // 
            this.pnNen.BorderColor = System.Drawing.Color.Tomato;
            this.pnNen.BorderRadius = 10;
            this.pnNen.BorderThickness = 2;
            this.pnNen.Controls.Add(this.lblSo);
            this.pnNen.FillColor = System.Drawing.Color.White;
            this.pnNen.Location = new System.Drawing.Point(3, 3);
            this.pnNen.Name = "pnNen";
            this.pnNen.Padding = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.pnNen.Size = new System.Drawing.Size(37, 36);
            this.pnNen.TabIndex = 8;
            // 
            // lblSo
            // 
            this.lblSo.BackColor = System.Drawing.Color.Transparent;
            this.lblSo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSo.ForeColor = System.Drawing.Color.DimGray;
            this.lblSo.Location = new System.Drawing.Point(3, 6);
            this.lblSo.Name = "lblSo";
            this.lblSo.Size = new System.Drawing.Size(31, 27);
            this.lblSo.TabIndex = 0;
            this.lblSo.Text = "01";
            this.lblSo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_MG_BtnDieuHuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.pnNen);
            this.Name = "UC_MG_BtnDieuHuong";
            this.Size = new System.Drawing.Size(43, 41);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.pnNen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel pnNen;
        private System.Windows.Forms.Label lblSo;
    }
}
