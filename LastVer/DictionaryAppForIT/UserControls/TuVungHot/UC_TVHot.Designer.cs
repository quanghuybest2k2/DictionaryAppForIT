
namespace DictionaryAppForIT.UserControls.TuVungHot
{
    partial class UC_TVHot
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.flpContent = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label25 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 26;
            this.guna2Elipse1.TargetControl = this;
            // 
            // flpContent
            // 
            this.flpContent.Location = new System.Drawing.Point(43, 83);
            this.flpContent.Name = "flpContent";
            this.flpContent.Size = new System.Drawing.Size(808, 440);
            this.flpContent.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Location = new System.Drawing.Point(43, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(808, 49);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(120)))));
            this.panel3.Location = new System.Drawing.Point(9, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 27);
            this.panel3.TabIndex = 31;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Gray;
            this.label25.Location = new System.Drawing.Point(25, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(379, 28);
            this.label25.TabIndex = 30;
            this.label25.Text = "Top những từ được tìm kiếm nhiều nhất";
            // 
            // UC_TVHot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpContent);
            this.Name = "UC_TVHot";
            this.Size = new System.Drawing.Size(882, 553);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.FlowLayoutPanel flpContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label25;
    }
}
