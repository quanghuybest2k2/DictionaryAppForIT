﻿
namespace DictionaryAppForIT.UserControls.YeuThich
{
    partial class UC_YeuThich
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_YeuThich));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSoMucYeuThich = new System.Windows.Forms.Label();
            this.txtTimKiemYeuThich = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSapXepYeuThich = new Guna.UI2.WinForms.Guna2Button();
            this.btnXoaMucYeuThich = new Guna.UI2.WinForms.Guna2Button();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.bunifuToolTip1 = new Bunifu.UI.WinForms.BunifuToolTip(this.components);
            this.cbbLoaiTimKiem = new Guna.UI2.WinForms.Guna2ComboBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 26;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbbLoaiTimKiem);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblSoMucYeuThich);
            this.panel2.Controls.Add(this.txtTimKiemYeuThich);
            this.panel2.Controls.Add(this.btnSapXepYeuThich);
            this.panel2.Controls.Add(this.btnXoaMucYeuThich);
            this.panel2.Controls.Add(this.flpContent);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(882, 553);
            this.panel2.TabIndex = 1;
            this.bunifuToolTip1.SetToolTip(this.panel2, "");
            this.bunifuToolTip1.SetToolTipIcon(this.panel2, null);
            this.bunifuToolTip1.SetToolTipTitle(this.panel2, "");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(65, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 19);
            this.label2.TabIndex = 35;
            this.label2.Text = "Mục yêu thích";
            this.bunifuToolTip1.SetToolTip(this.label2, "");
            this.bunifuToolTip1.SetToolTipIcon(this.label2, null);
            this.bunifuToolTip1.SetToolTipTitle(this.label2, "");
            // 
            // lblSoMucYeuThich
            // 
            this.lblSoMucYeuThich.AutoSize = true;
            this.lblSoMucYeuThich.Font = new System.Drawing.Font("Segoe UI Black", 16F, System.Drawing.FontStyle.Bold);
            this.lblSoMucYeuThich.ForeColor = System.Drawing.Color.Salmon;
            this.lblSoMucYeuThich.Location = new System.Drawing.Point(25, 25);
            this.lblSoMucYeuThich.Name = "lblSoMucYeuThich";
            this.lblSoMucYeuThich.Size = new System.Drawing.Size(26, 30);
            this.lblSoMucYeuThich.TabIndex = 36;
            this.lblSoMucYeuThich.Text = "0";
            this.bunifuToolTip1.SetToolTip(this.lblSoMucYeuThich, "");
            this.bunifuToolTip1.SetToolTipIcon(this.lblSoMucYeuThich, null);
            this.bunifuToolTip1.SetToolTipTitle(this.lblSoMucYeuThich, "");
            // 
            // txtTimKiemYeuThich
            // 
            this.txtTimKiemYeuThich.BackColor = System.Drawing.Color.Transparent;
            this.txtTimKiemYeuThich.BorderRadius = 15;
            this.txtTimKiemYeuThich.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemYeuThich.DefaultText = "";
            this.txtTimKiemYeuThich.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiemYeuThich.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiemYeuThich.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemYeuThich.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemYeuThich.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemYeuThich.FocusedState.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiemYeuThich.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiemYeuThich.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemYeuThich.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtTimKiemYeuThich.IconLeft")));
            this.txtTimKiemYeuThich.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.txtTimKiemYeuThich.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtTimKiemYeuThich.IconLeftSize = new System.Drawing.Size(18, 18);
            this.txtTimKiemYeuThich.Location = new System.Drawing.Point(183, 24);
            this.txtTimKiemYeuThich.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTimKiemYeuThich.Name = "txtTimKiemYeuThich";
            this.txtTimKiemYeuThich.PasswordChar = '\0';
            this.txtTimKiemYeuThich.PlaceholderText = "Tìm kiếm Từ Vựng...";
            this.txtTimKiemYeuThich.SelectedText = "";
            this.txtTimKiemYeuThich.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.txtTimKiemYeuThich.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(50);
            this.txtTimKiemYeuThich.Size = new System.Drawing.Size(475, 35);
            this.txtTimKiemYeuThich.TabIndex = 30;
            this.txtTimKiemYeuThich.TextOffset = new System.Drawing.Point(5, 0);
            this.bunifuToolTip1.SetToolTip(this.txtTimKiemYeuThich, "");
            this.bunifuToolTip1.SetToolTipIcon(this.txtTimKiemYeuThich, null);
            this.bunifuToolTip1.SetToolTipTitle(this.txtTimKiemYeuThich, "");
            this.txtTimKiemYeuThich.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiemYeuThich_KeyDown);
            // 
            // btnSapXepYeuThich
            // 
            this.btnSapXepYeuThich.BackColor = System.Drawing.Color.Transparent;
            this.btnSapXepYeuThich.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.btnSapXepYeuThich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSapXepYeuThich.FillColor = System.Drawing.Color.Transparent;
            this.btnSapXepYeuThich.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSapXepYeuThich.ForeColor = System.Drawing.Color.Gray;
            this.btnSapXepYeuThich.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnSapXepYeuThich.Image = ((System.Drawing.Image)(resources.GetObject("btnSapXepYeuThich.Image")));
            this.btnSapXepYeuThich.ImageSize = new System.Drawing.Size(25, 25);
            this.btnSapXepYeuThich.Location = new System.Drawing.Point(797, 27);
            this.btnSapXepYeuThich.Name = "btnSapXepYeuThich";
            this.btnSapXepYeuThich.PressedDepth = 0;
            this.btnSapXepYeuThich.Size = new System.Drawing.Size(35, 30);
            this.btnSapXepYeuThich.TabIndex = 34;
            this.btnSapXepYeuThich.TextOffset = new System.Drawing.Point(3, 0);
            this.bunifuToolTip1.SetToolTip(this.btnSapXepYeuThich, "Sắp xếp [A - Z]");
            this.bunifuToolTip1.SetToolTipIcon(this.btnSapXepYeuThich, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnSapXepYeuThich, "");
            this.btnSapXepYeuThich.UseTransparentBackground = true;
            this.btnSapXepYeuThich.Click += new System.EventHandler(this.btnSapXepYeuThich_Click);
            // 
            // btnXoaMucYeuThich
            // 
            this.btnXoaMucYeuThich.BackColor = System.Drawing.Color.Transparent;
            this.btnXoaMucYeuThich.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.btnXoaMucYeuThich.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaMucYeuThich.FillColor = System.Drawing.Color.Transparent;
            this.btnXoaMucYeuThich.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMucYeuThich.ForeColor = System.Drawing.Color.Gray;
            this.btnXoaMucYeuThich.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnXoaMucYeuThich.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaMucYeuThich.Image")));
            this.btnXoaMucYeuThich.ImageSize = new System.Drawing.Size(22, 22);
            this.btnXoaMucYeuThich.Location = new System.Drawing.Point(829, 25);
            this.btnXoaMucYeuThich.Name = "btnXoaMucYeuThich";
            this.btnXoaMucYeuThich.PressedDepth = 0;
            this.btnXoaMucYeuThich.Size = new System.Drawing.Size(35, 30);
            this.btnXoaMucYeuThich.TabIndex = 29;
            this.btnXoaMucYeuThich.TextOffset = new System.Drawing.Point(3, 0);
            this.bunifuToolTip1.SetToolTip(this.btnXoaMucYeuThich, "Xóa mục yêu thích");
            this.bunifuToolTip1.SetToolTipIcon(this.btnXoaMucYeuThich, null);
            this.bunifuToolTip1.SetToolTipTitle(this.btnXoaMucYeuThich, "");
            this.btnXoaMucYeuThich.UseTransparentBackground = true;
            this.btnXoaMucYeuThich.Click += new System.EventHandler(this.btnXoaMucYeuThich_Click);
            // 
            // flpContent
            // 
            this.flpContent.AutoScroll = true;
            this.flpContent.Location = new System.Drawing.Point(3, 83);
            this.flpContent.Name = "flpContent";
            this.flpContent.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.flpContent.Size = new System.Drawing.Size(873, 449);
            this.flpContent.TabIndex = 0;
            this.bunifuToolTip1.SetToolTip(this.flpContent, "");
            this.bunifuToolTip1.SetToolTipIcon(this.flpContent, null);
            this.bunifuToolTip1.SetToolTipTitle(this.flpContent, "");
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
            // cbbLoaiTimKiem
            // 
            this.cbbLoaiTimKiem.BackColor = System.Drawing.Color.Transparent;
            this.cbbLoaiTimKiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbLoaiTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbLoaiTimKiem.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbLoaiTimKiem.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbLoaiTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbLoaiTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbLoaiTimKiem.ItemHeight = 30;
            this.cbbLoaiTimKiem.Items.AddRange(new object[] {
            "Từ vựng",
            "Văn bản"});
            this.cbbLoaiTimKiem.Location = new System.Drawing.Point(665, 24);
            this.cbbLoaiTimKiem.Name = "cbbLoaiTimKiem";
            this.cbbLoaiTimKiem.Size = new System.Drawing.Size(126, 36);
            this.cbbLoaiTimKiem.TabIndex = 37;
            this.bunifuToolTip1.SetToolTip(this.cbbLoaiTimKiem, "");
            this.bunifuToolTip1.SetToolTipIcon(this.cbbLoaiTimKiem, null);
            this.bunifuToolTip1.SetToolTipTitle(this.cbbLoaiTimKiem, "");
            this.cbbLoaiTimKiem.SelectedIndexChanged += new System.EventHandler(this.cbbLoaiTimKiem_SelectedIndexChanged);
            // 
            // UC_YeuThich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Name = "UC_YeuThich";
            this.Size = new System.Drawing.Size(882, 553);
            this.bunifuToolTip1.SetToolTip(this, "");
            this.bunifuToolTip1.SetToolTipIcon(this, null);
            this.bunifuToolTip1.SetToolTipTitle(this, "");
            this.Load += new System.EventHandler(this.UC_YeuThich_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private Guna.UI2.WinForms.Guna2Button btnXoaMucYeuThich;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemYeuThich;
        private Guna.UI2.WinForms.Guna2Button btnSapXepYeuThich;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSoMucYeuThich;
        private Bunifu.UI.WinForms.BunifuToolTip bunifuToolTip1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbLoaiTimKiem;
    }
}
