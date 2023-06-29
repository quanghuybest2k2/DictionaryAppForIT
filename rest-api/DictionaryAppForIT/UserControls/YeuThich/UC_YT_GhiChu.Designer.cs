
namespace DictionaryAppForIT.UserControls.YeuThich
{
    partial class UC_YT_GhiChu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_YT_GhiChu));
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblIndex = new System.Windows.Forms.Label();
            this.statusStripSoKyTuNhap = new System.Windows.Forms.StatusStrip();
            this.tsslSoKyTuNhap = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtGhiChu = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnXoaGhiChu = new Guna.UI2.WinForms.Guna2Button();
            this.btnChinhSuaGhiChu = new Guna.UI2.WinForms.Guna2Button();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnGhiChu = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            this.statusStripSoKyTuNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.BorderColor = System.Drawing.Color.Silver;
            this.guna2Panel1.BorderRadius = 20;
            this.guna2Panel1.BorderThickness = 2;
            this.guna2Panel1.Controls.Add(this.guna2Panel2);
            this.guna2Panel1.Controls.Add(this.txtGhiChu);
            this.guna2Panel1.Controls.Add(this.btnXoaGhiChu);
            this.guna2Panel1.Controls.Add(this.btnChinhSuaGhiChu);
            this.guna2Panel1.Controls.Add(this.btnClose);
            this.guna2Panel1.Controls.Add(this.btnGhiChu);
            this.guna2Panel1.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.White;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 20;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.guna2Panel1.Size = new System.Drawing.Size(268, 151);
            this.guna2Panel1.TabIndex = 11;
            this.bunifuToolTip1.SetToolTip(this.guna2Panel1, "");
            this.bunifuToolTip1.SetToolTipIcon(this.guna2Panel1, null);
            this.bunifuToolTip1.SetToolTipTitle(this.guna2Panel1, "");
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.lblIndex);
            this.guna2Panel2.Controls.Add(this.statusStripSoKyTuNhap);
            this.guna2Panel2.Location = new System.Drawing.Point(25, 118);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(208, 22);
            this.guna2Panel2.TabIndex = 21;
            this.bunifuToolTip1.SetToolTip(this.guna2Panel2, "");
            this.bunifuToolTip1.SetToolTipIcon(this.guna2Panel2, null);
            this.bunifuToolTip1.SetToolTipTitle(this.guna2Panel2, "");
            this.guna2Panel2.UseTransparentBackground = true;
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(160, 9);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(15, 13);
            this.lblIndex.TabIndex = 24;
            this.lblIndex.Text = "id";
            this.bunifuToolTip1.SetToolTip(this.lblIndex, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblIndex, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblIndex, "");
            this.lblIndex.Visible = false;
            // 
            // statusStripSoKyTuNhap
            // 
            this.statusStripSoKyTuNhap.BackColor = System.Drawing.Color.White;
            this.statusStripSoKyTuNhap.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSoKyTuNhap});
            this.statusStripSoKyTuNhap.Location = new System.Drawing.Point(0, 0);
            this.statusStripSoKyTuNhap.Name = "statusStripSoKyTuNhap";
            this.statusStripSoKyTuNhap.Size = new System.Drawing.Size(208, 22);
            this.statusStripSoKyTuNhap.TabIndex = 22;
            this.statusStripSoKyTuNhap.Text = "Số ký tự nhập";
            this.bunifuToolTip1.SetToolTip(this.statusStripSoKyTuNhap, "");
            this.bunifuToolTip1.SetToolTipIcon(this.statusStripSoKyTuNhap, null);
            this.bunifuToolTip1.SetToolTipTitle(this.statusStripSoKyTuNhap, "");
            // 
            // tsslSoKyTuNhap
            // 
            this.tsslSoKyTuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.tsslSoKyTuNhap.Name = "tsslSoKyTuNhap";
            this.tsslSoKyTuNhap.Size = new System.Drawing.Size(79, 17);
            this.tsslSoKyTuNhap.Text = "Số ký tự nhập";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtGhiChu.BorderRadius = 20;
            this.txtGhiChu.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGhiChu.DefaultText = "";
            this.txtGhiChu.DisabledState.BorderColor = System.Drawing.Color.White;
            this.txtGhiChu.DisabledState.FillColor = System.Drawing.Color.White;
            this.txtGhiChu.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGhiChu.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGhiChu.Enabled = false;
            this.txtGhiChu.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGhiChu.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGhiChu.Location = new System.Drawing.Point(16, 52);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.PasswordChar = '\0';
            this.txtGhiChu.PlaceholderText = "";
            this.txtGhiChu.SelectedText = "";
            this.txtGhiChu.Size = new System.Drawing.Size(232, 63);
            this.txtGhiChu.TabIndex = 19;
            this.bunifuToolTip1.SetToolTip(this.txtGhiChu, "");
            this.bunifuToolTip1.SetToolTipIcon(this.txtGhiChu, null);
            this.bunifuToolTip1.SetToolTipTitle(this.txtGhiChu, "");
            this.txtGhiChu.TextChanged += new System.EventHandler(this.txtGhiChu_TextChanged);
            this.txtGhiChu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGhiChu_KeyDown);
            // 
            // btnXoaGhiChu
            // 
            this.btnXoaGhiChu.BorderRadius = 15;
            this.btnXoaGhiChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaGhiChu.FillColor = System.Drawing.Color.Empty;
            this.btnXoaGhiChu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnXoaGhiChu.ForeColor = System.Drawing.Color.White;
            this.btnXoaGhiChu.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnXoaGhiChu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaGhiChu.Image")));
            this.btnXoaGhiChu.ImageSize = new System.Drawing.Size(15, 15);
            this.btnXoaGhiChu.Location = new System.Drawing.Point(200, 19);
            this.btnXoaGhiChu.Name = "btnXoaGhiChu";
            this.btnXoaGhiChu.PressedDepth = 0;
            this.btnXoaGhiChu.Size = new System.Drawing.Size(29, 22);
            this.btnXoaGhiChu.TabIndex = 18;
            this.bunifuToolTip1.SetToolTip(this.btnXoaGhiChu, "Xóa ghi chú");
            this.bunifuToolTip1.SetToolTipIcon(this.btnXoaGhiChu, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnXoaGhiChu, "");
            this.btnXoaGhiChu.UseTransparentBackground = true;
            this.btnXoaGhiChu.Click += new System.EventHandler(this.btnXoaGhiChu_Click);
            // 
            // btnChinhSuaGhiChu
            // 
            this.btnChinhSuaGhiChu.BorderRadius = 15;
            this.btnChinhSuaGhiChu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChinhSuaGhiChu.FillColor = System.Drawing.Color.Empty;
            this.btnChinhSuaGhiChu.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnChinhSuaGhiChu.ForeColor = System.Drawing.Color.White;
            this.btnChinhSuaGhiChu.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnChinhSuaGhiChu.Image = ((System.Drawing.Image)(resources.GetObject("btnChinhSuaGhiChu.Image")));
            this.btnChinhSuaGhiChu.ImageSize = new System.Drawing.Size(15, 15);
            this.btnChinhSuaGhiChu.Location = new System.Drawing.Point(174, 19);
            this.btnChinhSuaGhiChu.Name = "btnChinhSuaGhiChu";
            this.btnChinhSuaGhiChu.PressedDepth = 0;
            this.btnChinhSuaGhiChu.Size = new System.Drawing.Size(26, 22);
            this.btnChinhSuaGhiChu.TabIndex = 18;
            this.bunifuToolTip1.SetToolTip(this.btnChinhSuaGhiChu, "Sửa ghi chú");
            this.bunifuToolTip1.SetToolTipIcon(this.btnChinhSuaGhiChu, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnChinhSuaGhiChu, "");
            this.btnChinhSuaGhiChu.UseTransparentBackground = true;
            this.btnChinhSuaGhiChu.Click += new System.EventHandler(this.btnChinhSuaGhiChu_Click);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 15;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FillColor = System.Drawing.Color.Empty;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageSize = new System.Drawing.Size(22, 22);
            this.btnClose.Location = new System.Drawing.Point(228, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedDepth = 0;
            this.btnClose.Size = new System.Drawing.Size(29, 22);
            this.btnClose.TabIndex = 18;
            this.bunifuToolTip1.SetToolTip(this.btnClose, "Ẩn ghi chú");
            this.bunifuToolTip1.SetToolTipIcon(this.btnClose, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnClose, "");
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGhiChu
            // 
            this.btnGhiChu.BorderRadius = 15;
            this.btnGhiChu.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGhiChu.FillColor = System.Drawing.Color.Tomato;
            this.btnGhiChu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGhiChu.ForeColor = System.Drawing.Color.White;
            this.btnGhiChu.HoverState.FillColor = System.Drawing.Color.Tomato;
            this.btnGhiChu.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnGhiChu.Image = ((System.Drawing.Image)(resources.GetObject("btnGhiChu.Image")));
            this.btnGhiChu.ImageSize = new System.Drawing.Size(12, 12);
            this.btnGhiChu.Location = new System.Drawing.Point(16, 17);
            this.btnGhiChu.Name = "btnGhiChu";
            this.btnGhiChu.PressedDepth = 0;
            this.btnGhiChu.Size = new System.Drawing.Size(87, 30);
            this.btnGhiChu.TabIndex = 18;
            this.btnGhiChu.Text = "Ghi chú";
            this.bunifuToolTip1.SetToolTip(this.btnGhiChu, "");
            this.bunifuToolTip1.SetToolTipIcon(this.btnGhiChu, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnGhiChu, "");
            this.btnGhiChu.UseTransparentBackground = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Tomato;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(-42, 17);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(112, 30);
            this.guna2PictureBox1.TabIndex = 22;
            this.guna2PictureBox1.TabStop = false;
            this.bunifuToolTip1.SetToolTip(this.guna2PictureBox1, "");
            this.bunifuToolTip1.SetToolTipIcon(this.guna2PictureBox1, null);
            this.bunifuToolTip1.SetToolTipTitle(this.guna2PictureBox1, "");
            // 
            // bunifuToolTip1
            // 
            this.bunifuToolTip1.Active = true;
            this.bunifuToolTip1.AlignTextWithTitle = false;
            this.bunifuToolTip1.AllowAutoClose = false;
            this.bunifuToolTip1.AllowFading = true;
            this.bunifuToolTip1.AutoCloseDuration = 5000;
            this.bunifuToolTip1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuToolTip1.BorderColor = System.Drawing.Color.DarkGray;
            this.bunifuToolTip1.ClickToShowDisplayControl = false;
            this.bunifuToolTip1.ConvertNewlinesToBreakTags = true;
            this.bunifuToolTip1.DisplayControl = null;
            this.bunifuToolTip1.EntryAnimationSpeed = 350;
            this.bunifuToolTip1.ExitAnimationSpeed = 200;
            this.bunifuToolTip1.GenerateAutoCloseDuration = false;
            this.bunifuToolTip1.IconMargin = 6;
            this.bunifuToolTip1.InitialDelay = 0;
            this.bunifuToolTip1.Name = "bunifuToolTip1";
            this.bunifuToolTip1.Opacity = 1D;
            this.bunifuToolTip1.OverrideToolTipTitles = false;
            this.bunifuToolTip1.Padding = new System.Windows.Forms.Padding(10);
            this.bunifuToolTip1.ReshowDelay = 100;
            this.bunifuToolTip1.ShowAlways = true;
            this.bunifuToolTip1.ShowBorders = true;
            this.bunifuToolTip1.ShowIcons = true;
            this.bunifuToolTip1.ShowShadows = true;
            this.bunifuToolTip1.Tag = null;
            this.bunifuToolTip1.TextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.bunifuToolTip1.TextForeColor = System.Drawing.Color.DimGray;
            this.bunifuToolTip1.TextMargin = 2;
            this.bunifuToolTip1.TitleFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.bunifuToolTip1.TitleForeColor = System.Drawing.Color.Black;
            this.bunifuToolTip1.ToolTipPosition = new System.Drawing.Point(0, 0);
            this.bunifuToolTip1.ToolTipTitle = null;
            // 
            // UC_YT_GhiChu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UC_YT_GhiChu";
            this.Size = new System.Drawing.Size(268, 169);
            this.bunifuToolTip1.SetToolTip(this, "");
            this.bunifuToolTip1.SetToolTipIcon(this, null);
            this.bunifuToolTip1.SetToolTipTitle(this, "");
            this.Load += new System.EventHandler(this.UC_YT_GhiChu_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.statusStripSoKyTuNhap.ResumeLayout(false);
            this.statusStripSoKyTuNhap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnGhiChu;
        private Guna.UI2.WinForms.Guna2TextBox txtGhiChu;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.StatusStrip statusStripSoKyTuNhap;
        private System.Windows.Forms.ToolStripStatusLabel tsslSoKyTuNhap;
        private Guna.UI2.WinForms.Guna2Button btnXoaGhiChu;
        private Guna.UI2.WinForms.Guna2Button btnChinhSuaGhiChu;
        private System.Windows.Forms.Label lblIndex;
        private Bunifu.UI.WinForms.BunifuToolTip bunifuToolTip1;
    }
}
