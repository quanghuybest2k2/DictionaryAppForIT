
namespace DictionaryAppForIT.UserControls.MiniGame
{
    partial class UC_StartMiniGame
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
            this.pnStartMiniGame = new Guna.UI2.WinForms.Guna2Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBatDau = new Guna.UI2.WinForms.Guna2Button();
            this.pnStartMiniGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 26;
            this.guna2Elipse1.TargetControl = this;
            // 
            // pnStartMiniGame
            // 
            this.pnStartMiniGame.Controls.Add(this.textBox1);
            this.pnStartMiniGame.Controls.Add(this.btnBatDau);
            this.pnStartMiniGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnStartMiniGame.Location = new System.Drawing.Point(0, 0);
            this.pnStartMiniGame.Name = "pnStartMiniGame";
            this.pnStartMiniGame.Size = new System.Drawing.Size(882, 553);
            this.pnStartMiniGame.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold);
            this.textBox1.ForeColor = System.Drawing.Color.DimGray;
            this.textBox1.Location = new System.Drawing.Point(199, 239);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(475, 53);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "In programming, a ___ is a value that can change, depending on conditions or on i" +
    "nformation passed to the program.";
            // 
            // btnBatDau
            // 
            this.btnBatDau.BorderRadius = 20;
            this.btnBatDau.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBatDau.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBatDau.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBatDau.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBatDau.FillColor = System.Drawing.Color.Orange;
            this.btnBatDau.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(339, 316);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(180, 45);
            this.btnBatDau.TabIndex = 4;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // UC_StartMiniGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnStartMiniGame);
            this.Name = "UC_StartMiniGame";
            this.Size = new System.Drawing.Size(882, 553);
            this.pnStartMiniGame.ResumeLayout(false);
            this.pnStartMiniGame.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2Panel pnStartMiniGame;
        private System.Windows.Forms.TextBox textBox1;
        private Guna.UI2.WinForms.Guna2Button btnBatDau;
    }
}
