
namespace DictionaryAppForIT.Forms
{
    partial class frmThongBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongBao));
            this.uC_ThongBao1 = new DictionaryAppForIT.UserControls.ThongBao.UC_TB_NoiDung();
            this.uC_ThongBao2 = new DictionaryAppForIT.UserControls.ThongBao.UC_TB_NoiDung();
            this.pnThongBao = new Guna.UI2.WinForms.Guna2Panel();
            this.pnNen = new Guna.UI2.WinForms.Guna2Panel();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCloseMini = new Guna.UI2.WinForms.Guna2Button();
            this.btnCloseMax = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnThongBao.SuspendLayout();
            this.pnNen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // uC_ThongBao1
            // 
            this.uC_ThongBao1.Location = new System.Drawing.Point(0, 0);
            this.uC_ThongBao1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_ThongBao1.Name = "uC_ThongBao1";
            this.uC_ThongBao1.NoiDung = "Bạn vừa thêm 1 từ mới";
            this.uC_ThongBao1.Size = new System.Drawing.Size(197, 50);
            this.uC_ThongBao1.TabIndex = 0;
            this.uC_ThongBao1.ThoiGian = "10 phút trước";
            // 
            // uC_ThongBao2
            // 
            this.uC_ThongBao2.Location = new System.Drawing.Point(0, 50);
            this.uC_ThongBao2.Margin = new System.Windows.Forms.Padding(0);
            this.uC_ThongBao2.Name = "uC_ThongBao2";
            this.uC_ThongBao2.NoiDung = "Bạn vừa thêm 1 từ mới";
            this.uC_ThongBao2.Size = new System.Drawing.Size(197, 50);
            this.uC_ThongBao2.TabIndex = 1;
            this.uC_ThongBao2.ThoiGian = "10 phút trước";
            // 
            // pnThongBao
            // 
            this.pnThongBao.BackColor = System.Drawing.Color.Transparent;
            this.pnThongBao.BorderColor = System.Drawing.Color.Tomato;
            this.pnThongBao.Controls.Add(this.pnNen);
            this.pnThongBao.Controls.Add(this.guna2PictureBox1);
            this.pnThongBao.Location = new System.Drawing.Point(5, 33);
            this.pnThongBao.Name = "pnThongBao";
            this.pnThongBao.ShadowDecoration.Parent = this.pnThongBao;
            this.pnThongBao.Size = new System.Drawing.Size(279, 274);
            this.pnThongBao.TabIndex = 34;
            this.pnThongBao.UseTransparentBackground = true;
            // 
            // pnNen
            // 
            this.pnNen.BackColor = System.Drawing.Color.Transparent;
            this.pnNen.BorderColor = System.Drawing.Color.Tomato;
            this.pnNen.BorderRadius = 10;
            this.pnNen.BorderThickness = 2;
            this.pnNen.Controls.Add(this.flpContent);
            this.pnNen.Controls.Add(this.btnCloseMini);
            this.pnNen.Controls.Add(this.btnCloseMax);
            this.pnNen.Controls.Add(this.label3);
            this.pnNen.Controls.Add(this.guna2PictureBox3);
            this.pnNen.Controls.Add(this.guna2PictureBox2);
            this.pnNen.FillColor = System.Drawing.Color.White;
            this.pnNen.Location = new System.Drawing.Point(12, 12);
            this.pnNen.Name = "pnNen";
            this.pnNen.ShadowDecoration.BorderRadius = 20;
            this.pnNen.ShadowDecoration.Color = System.Drawing.Color.Gray;
            this.pnNen.ShadowDecoration.Depth = 20;
            this.pnNen.ShadowDecoration.Parent = this.pnNen;
            this.pnNen.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.pnNen.Size = new System.Drawing.Size(218, 252);
            this.pnNen.TabIndex = 3;
            // 
            // flpContent
            // 
            this.flpContent.AutoScroll = true;
            this.flpContent.Location = new System.Drawing.Point(11, 42);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(221, 200);
            this.flpContent.TabIndex = 1;
            // 
            // btnCloseMini
            // 
            this.btnCloseMini.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseMini.CheckedState.Parent = this.btnCloseMini;
            this.btnCloseMini.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseMini.CustomImages.Parent = this.btnCloseMini;
            this.btnCloseMini.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseMini.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCloseMini.ForeColor = System.Drawing.Color.White;
            this.btnCloseMini.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseMini.HoverState.Parent = this.btnCloseMini;
            this.btnCloseMini.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseMini.Image")));
            this.btnCloseMini.ImageSize = new System.Drawing.Size(22, 22);
            this.btnCloseMini.Location = new System.Drawing.Point(192, 8);
            this.btnCloseMini.Name = "btnCloseMini";
            this.btnCloseMini.PressedDepth = 0;
            this.btnCloseMini.ShadowDecoration.Parent = this.btnCloseMini;
            this.btnCloseMini.Size = new System.Drawing.Size(18, 19);
            this.btnCloseMini.TabIndex = 19;
            this.btnCloseMini.UseTransparentBackground = true;
            this.btnCloseMini.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCloseMax
            // 
            this.btnCloseMax.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseMax.CheckedState.Parent = this.btnCloseMax;
            this.btnCloseMax.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCloseMax.CustomImages.Parent = this.btnCloseMax;
            this.btnCloseMax.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseMax.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCloseMax.ForeColor = System.Drawing.Color.White;
            this.btnCloseMax.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnCloseMax.HoverState.Parent = this.btnCloseMax;
            this.btnCloseMax.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseMax.Image")));
            this.btnCloseMax.ImageSize = new System.Drawing.Size(22, 22);
            this.btnCloseMax.Location = new System.Drawing.Point(207, 8);
            this.btnCloseMax.Name = "btnCloseMax";
            this.btnCloseMax.PressedDepth = 0;
            this.btnCloseMax.ShadowDecoration.Parent = this.btnCloseMax;
            this.btnCloseMax.Size = new System.Drawing.Size(18, 19);
            this.btnCloseMax.TabIndex = 19;
            this.btnCloseMax.UseTransparentBackground = true;
            this.btnCloseMax.Visible = false;
            this.btnCloseMax.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Salmon;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thông báo";
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.FillColor = System.Drawing.Color.Salmon;
            this.guna2PictureBox3.Location = new System.Drawing.Point(0, 21);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.ShadowDecoration.Parent = this.guna2PictureBox3;
            this.guna2PictureBox3.Size = new System.Drawing.Size(218, 14);
            this.guna2PictureBox3.TabIndex = 0;
            this.guna2PictureBox3.TabStop = false;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BorderRadius = 10;
            this.guna2PictureBox2.FillColor = System.Drawing.Color.Salmon;
            this.guna2PictureBox2.Location = new System.Drawing.Point(0, 0);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.ShadowDecoration.Parent = this.guna2PictureBox2;
            this.guna2PictureBox2.Size = new System.Drawing.Size(218, 35);
            this.guna2PictureBox2.TabIndex = 0;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.Location = new System.Drawing.Point(24, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.ShadowDecoration.Parent = this.guna2PictureBox1;
            this.guna2PictureBox1.Size = new System.Drawing.Size(101, 30);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 4;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // frmThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1072, 608);
            this.Controls.Add(this.pnThongBao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ThongTinTaiKhoan";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pnThongBao.ResumeLayout(false);
            this.pnNen.ResumeLayout(false);
            this.pnNen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UserControls.ThongBao.UC_TB_NoiDung uC_ThongBao1;
        private UserControls.ThongBao.UC_TB_NoiDung uC_ThongBao2;
        private Guna.UI2.WinForms.Guna2Panel pnThongBao;
        private Guna.UI2.WinForms.Guna2Panel pnNen;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private Guna.UI2.WinForms.Guna2Button btnCloseMini;
        private Guna.UI2.WinForms.Guna2Button btnCloseMax;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}