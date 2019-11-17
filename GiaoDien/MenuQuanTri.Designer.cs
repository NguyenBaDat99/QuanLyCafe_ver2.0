namespace _KTPM_QuanLyCafe.QuanTri
{
    partial class MenuQuanTri
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuQuanTri));
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuanLyBan = new System.Windows.Forms.Button();
            this.btnQuanLyMon = new System.Windows.Forms.Button();
            this.btnQuanLyHoaDon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SandyBrown;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(330, 59);
            this.label1.TabIndex = 0;
            this.label1.Text = "CHỨC NĂNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuanLyBan
            // 
            this.btnQuanLyBan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyBan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyBan.FlatAppearance.BorderSize = 0;
            this.btnQuanLyBan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.btnQuanLyBan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnQuanLyBan.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnQuanLyBan.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyBan.Location = new System.Drawing.Point(0, 59);
            this.btnQuanLyBan.Name = "btnQuanLyBan";
            this.btnQuanLyBan.Size = new System.Drawing.Size(330, 52);
            this.btnQuanLyBan.TabIndex = 0;
            this.btnQuanLyBan.Text = "Quản lý Bàn";
            this.btnQuanLyBan.UseVisualStyleBackColor = true;
            this.btnQuanLyBan.Click += new System.EventHandler(this.btnQuanLyBan_Click);
            // 
            // btnQuanLyMon
            // 
            this.btnQuanLyMon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyMon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyMon.FlatAppearance.BorderSize = 0;
            this.btnQuanLyMon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.btnQuanLyMon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnQuanLyMon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnQuanLyMon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyMon.Location = new System.Drawing.Point(0, 111);
            this.btnQuanLyMon.Name = "btnQuanLyMon";
            this.btnQuanLyMon.Size = new System.Drawing.Size(330, 52);
            this.btnQuanLyMon.TabIndex = 1;
            this.btnQuanLyMon.Text = "Quản lý Món";
            this.btnQuanLyMon.UseVisualStyleBackColor = true;
            this.btnQuanLyMon.Click += new System.EventHandler(this.btnQuanLyMon_Click);
            // 
            // btnQuanLyHoaDon
            // 
            this.btnQuanLyHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuanLyHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQuanLyHoaDon.FlatAppearance.BorderSize = 0;
            this.btnQuanLyHoaDon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.btnQuanLyHoaDon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnQuanLyHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnQuanLyHoaDon.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyHoaDon.Location = new System.Drawing.Point(0, 163);
            this.btnQuanLyHoaDon.Name = "btnQuanLyHoaDon";
            this.btnQuanLyHoaDon.Size = new System.Drawing.Size(330, 52);
            this.btnQuanLyHoaDon.TabIndex = 2;
            this.btnQuanLyHoaDon.Text = "Quản lý Hóa đơn";
            this.btnQuanLyHoaDon.UseVisualStyleBackColor = true;
            this.btnQuanLyHoaDon.Click += new System.EventHandler(this.btnQuanLyHoaDon_Click);
            // 
            // MenuQuanTri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 216);
            this.Controls.Add(this.btnQuanLyHoaDon);
            this.Controls.Add(this.btnQuanLyMon);
            this.Controls.Add(this.btnQuanLyBan);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuQuanTri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Quản Trị";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuQuanTri_FormClosing);
            this.Load += new System.EventHandler(this.MenuQuanTri_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnQuanLyBan;
        private System.Windows.Forms.Button btnQuanLyMon;
        private System.Windows.Forms.Button btnQuanLyHoaDon;

    }
}