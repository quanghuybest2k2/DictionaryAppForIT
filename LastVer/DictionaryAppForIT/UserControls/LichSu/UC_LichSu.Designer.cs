﻿
namespace DictionaryAppForIT.UserControls.GanDay
{
    partial class UC_LichSu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_LichSu));
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnXoaDuLieu = new Guna.UI2.WinForms.Guna2Button();
            this.label25 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cbbChonLichSuTK = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTimKiemLS = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 26;
            this.guna2Elipse1.TargetControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpContent);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnXoaDuLieu);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 553);
            this.panel1.TabIndex = 29;
            // 
            // flpContent
            // 
            this.flpContent.AutoScroll = true;
            this.flpContent.Location = new System.Drawing.Point(22, 71);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(640, 450);
            this.flpContent.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))));
            this.panel3.Location = new System.Drawing.Point(25, 24);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 27);
            this.panel3.TabIndex = 29;
            // 
            // btnXoaDuLieu
            // 
            this.btnXoaDuLieu.BackColor = System.Drawing.Color.Transparent;
            this.btnXoaDuLieu.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            this.btnXoaDuLieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaDuLieu.FillColor = System.Drawing.Color.Transparent;
            this.btnXoaDuLieu.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaDuLieu.ForeColor = System.Drawing.Color.Gray;
            this.btnXoaDuLieu.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.btnXoaDuLieu.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaDuLieu.Image")));
            this.btnXoaDuLieu.Location = new System.Drawing.Point(513, 24);
            this.btnXoaDuLieu.Name = "btnXoaDuLieu";
            this.btnXoaDuLieu.PressedDepth = 0;
            this.btnXoaDuLieu.Size = new System.Drawing.Size(106, 30);
            this.btnXoaDuLieu.TabIndex = 28;
            this.btnXoaDuLieu.Text = "Xóa dữ liệu";
            this.btnXoaDuLieu.TextOffset = new System.Drawing.Point(3, 0);
            this.btnXoaDuLieu.UseTransparentBackground = true;
            this.btnXoaDuLieu.Click += new System.EventHandler(this.btnXoaDuLieu_Click);
            this.btnXoaDuLieu.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.btnXoaDuLieu_ControlRemoved);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Gray;
            this.label25.Location = new System.Drawing.Point(41, 22);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 28);
            this.label25.TabIndex = 25;
            this.label25.Text = "Tất cả";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.guna2Panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(672, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 553);
            this.panel2.TabIndex = 30;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.Controls.Add(this.cbbChonLichSuTK);
            this.guna2Panel1.Controls.Add(this.pictureBox1);
            this.guna2Panel1.Controls.Add(this.txtTimKiemLS);
            this.guna2Panel1.Controls.Add(this.guna2Button7);
            this.guna2Panel1.Controls.Add(this.guna2Button6);
            this.guna2Panel1.Controls.Add(this.guna2Button5);
            this.guna2Panel1.Controls.Add(this.guna2Button4);
            this.guna2Panel1.Controls.Add(this.guna2Button3);
            this.guna2Panel1.Controls.Add(this.guna2Button1);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(10, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.ShadowDecoration.BorderRadius = 0;
            this.guna2Panel1.ShadowDecoration.Color = System.Drawing.Color.LightGray;
            this.guna2Panel1.ShadowDecoration.Enabled = true;
            this.guna2Panel1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.guna2Panel1.Size = new System.Drawing.Size(200, 553);
            this.guna2Panel1.TabIndex = 31;
            // 
            // cbbChonLichSuTK
            // 
            this.cbbChonLichSuTK.BackColor = System.Drawing.Color.Transparent;
            this.cbbChonLichSuTK.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.cbbChonLichSuTK.BorderRadius = 16;
            this.cbbChonLichSuTK.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbChonLichSuTK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChonLichSuTK.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbChonLichSuTK.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbChonLichSuTK.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cbbChonLichSuTK.ForeColor = System.Drawing.Color.Gray;
            this.cbbChonLichSuTK.ItemHeight = 30;
            this.cbbChonLichSuTK.Items.AddRange(new object[] {
            "Chọn kiểu tìm",
            "Lịch sử tra từ",
            "Lịch sử dịch"});
            this.cbbChonLichSuTK.Location = new System.Drawing.Point(13, 24);
            this.cbbChonLichSuTK.Name = "cbbChonLichSuTK";
            this.cbbChonLichSuTK.Size = new System.Drawing.Size(174, 36);
            this.cbbChonLichSuTK.TabIndex = 30;
            this.cbbChonLichSuTK.TextOffset = new System.Drawing.Point(10, 0);
            this.cbbChonLichSuTK.SelectedIndexChanged += new System.EventHandler(this.cbbChonLichSuTK_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 401);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // txtTimKiemLS
            // 
            this.txtTimKiemLS.BackColor = System.Drawing.Color.Transparent;
            this.txtTimKiemLS.BorderRadius = 16;
            this.txtTimKiemLS.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTimKiemLS.DefaultText = "";
            this.txtTimKiemLS.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTimKiemLS.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTimKiemLS.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemLS.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTimKiemLS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemLS.FocusedState.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiemLS.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtTimKiemLS.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTimKiemLS.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtTimKiemLS.IconLeft")));
            this.txtTimKiemLS.IconLeftCursor = System.Windows.Forms.Cursors.Hand;
            this.txtTimKiemLS.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.txtTimKiemLS.IconLeftSize = new System.Drawing.Size(15, 15);
            this.txtTimKiemLS.Location = new System.Drawing.Point(13, 74);
            this.txtTimKiemLS.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtTimKiemLS.Name = "txtTimKiemLS";
            this.txtTimKiemLS.PasswordChar = '\0';
            this.txtTimKiemLS.PlaceholderText = "Tìm kiếm";
            this.txtTimKiemLS.SelectedText = "";
            this.txtTimKiemLS.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.txtTimKiemLS.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(50);
            this.txtTimKiemLS.Size = new System.Drawing.Size(174, 36);
            this.txtTimKiemLS.TabIndex = 28;
            this.txtTimKiemLS.TextOffset = new System.Drawing.Point(5, 0);
            this.txtTimKiemLS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiemLS_KeyDown);
            // 
            // guna2Button7
            // 
            this.guna2Button7.BorderRadius = 16;
            this.guna2Button7.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button7.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button7.CheckedState.ForeColor = System.Drawing.Color.White;
            this.guna2Button7.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.guna2Button7.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button7.ForeColor = System.Drawing.Color.DarkGray;
            this.guna2Button7.HoverState.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Button7.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button7.Image")));
            this.guna2Button7.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button7.ImageOffset = new System.Drawing.Point(8, 0);
            this.guna2Button7.ImageSize = new System.Drawing.Size(17, 17);
            this.guna2Button7.Location = new System.Drawing.Point(13, 337);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Size = new System.Drawing.Size(174, 35);
            this.guna2Button7.TabIndex = 3;
            this.guna2Button7.Text = "Cũ hơn";
            this.guna2Button7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button7.TextOffset = new System.Drawing.Point(12, 0);
            // 
            // guna2Button6
            // 
            this.guna2Button6.BorderRadius = 16;
            this.guna2Button6.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button6.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button6.CheckedState.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            this.guna2Button6.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button6.ForeColor = System.Drawing.Color.DarkGray;
            this.guna2Button6.HoverState.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Button6.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button6.Image")));
            this.guna2Button6.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button6.ImageOffset = new System.Drawing.Point(8, 0);
            this.guna2Button6.ImageSize = new System.Drawing.Size(19, 19);
            this.guna2Button6.Location = new System.Drawing.Point(13, 294);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(174, 35);
            this.guna2Button6.TabIndex = 3;
            this.guna2Button6.Text = "Tháng này";
            this.guna2Button6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button6.TextOffset = new System.Drawing.Point(12, 0);
            // 
            // guna2Button5
            // 
            this.guna2Button5.BorderRadius = 16;
            this.guna2Button5.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button5.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button5.CheckedState.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            this.guna2Button5.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button5.ForeColor = System.Drawing.Color.DarkGray;
            this.guna2Button5.HoverState.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Button5.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button5.Image")));
            this.guna2Button5.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button5.ImageOffset = new System.Drawing.Point(8, 0);
            this.guna2Button5.ImageSize = new System.Drawing.Size(19, 19);
            this.guna2Button5.Location = new System.Drawing.Point(13, 251);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(174, 35);
            this.guna2Button5.TabIndex = 3;
            this.guna2Button5.Text = "Tuần này";
            this.guna2Button5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button5.TextOffset = new System.Drawing.Point(12, 0);
            // 
            // guna2Button4
            // 
            this.guna2Button4.BorderRadius = 16;
            this.guna2Button4.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button4.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button4.CheckedState.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            this.guna2Button4.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button4.ForeColor = System.Drawing.Color.DarkGray;
            this.guna2Button4.HoverState.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Button4.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button4.Image")));
            this.guna2Button4.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button4.ImageOffset = new System.Drawing.Point(8, 0);
            this.guna2Button4.ImageSize = new System.Drawing.Size(19, 19);
            this.guna2Button4.Location = new System.Drawing.Point(13, 208);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(174, 35);
            this.guna2Button4.TabIndex = 3;
            this.guna2Button4.Text = "Hôm qua";
            this.guna2Button4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button4.TextOffset = new System.Drawing.Point(12, 0);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 16;
            this.guna2Button3.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button3.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button3.CheckedState.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            this.guna2Button3.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button3.ForeColor = System.Drawing.Color.DarkGray;
            this.guna2Button3.HoverState.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Button3.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button3.Image")));
            this.guna2Button3.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button3.ImageOffset = new System.Drawing.Point(8, 0);
            this.guna2Button3.ImageSize = new System.Drawing.Size(18, 18);
            this.guna2Button3.Location = new System.Drawing.Point(13, 165);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(174, 35);
            this.guna2Button3.TabIndex = 3;
            this.guna2Button3.Text = "Hôm nay";
            this.guna2Button3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button3.TextOffset = new System.Drawing.Point(12, 0);
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 16;
            this.guna2Button1.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.guna2Button1.Checked = true;
            this.guna2Button1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button1.CheckedState.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.CheckedState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.HoverState.ForeColor = System.Drawing.Color.DimGray;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.ImageOffset = new System.Drawing.Point(8, 0);
            this.guna2Button1.ImageSize = new System.Drawing.Size(14, 14);
            this.guna2Button1.Location = new System.Drawing.Point(13, 122);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(174, 35);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Tất cả";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.guna2Button1.TextOffset = new System.Drawing.Point(12, 0);
            // 
            // UC_LichSu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UC_LichSu";
            this.Size = new System.Drawing.Size(882, 553);
            this.Load += new System.EventHandler(this.UC_LichSu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnXoaDuLieu;
        private System.Windows.Forms.Label label25;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiemLS;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2ComboBox cbbChonLichSuTK;
    }
}
