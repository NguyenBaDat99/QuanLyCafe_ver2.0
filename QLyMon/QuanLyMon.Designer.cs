namespace _KTPM_QuanLyCafe.QuanTri
{
    partial class QuanLyMon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyMon));
            this.dagvMon = new System.Windows.Forms.DataGridView();
            this.MaMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoaMon = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTenMonCS = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtGiaBanCS = new System.Windows.Forms.TextBox();
            this.txtGhiChuCS = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.txtTenMon = new System.Windows.Forms.TextBox();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimMon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dagvMon)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dagvMon
            // 
            this.dagvMon.AllowUserToAddRows = false;
            this.dagvMon.AllowUserToDeleteRows = false;
            this.dagvMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dagvMon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMon,
            this.TenMon,
            this.GiaBan,
            this.GhiChu});
            this.dagvMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dagvMon.Location = new System.Drawing.Point(0, 140);
            this.dagvMon.MultiSelect = false;
            this.dagvMon.Name = "dagvMon";
            this.dagvMon.ReadOnly = true;
            this.dagvMon.Size = new System.Drawing.Size(804, 305);
            this.dagvMon.TabIndex = 0;
            this.dagvMon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dagvMon_CellClick);
            // 
            // MaMon
            // 
            this.MaMon.DataPropertyName = "MaMon";
            this.MaMon.HeaderText = "Mã Món";
            this.MaMon.Name = "MaMon";
            this.MaMon.ReadOnly = true;
            // 
            // TenMon
            // 
            this.TenMon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenMon.DataPropertyName = "TenMon";
            this.TenMon.HeaderText = "Tên Món";
            this.TenMon.Name = "TenMon";
            this.TenMon.ReadOnly = true;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // btnXoaMon
            // 
            this.btnXoaMon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaMon.Enabled = false;
            this.btnXoaMon.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown;
            this.btnXoaMon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.btnXoaMon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnXoaMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMon.Location = new System.Drawing.Point(690, 8);
            this.btnXoaMon.Name = "btnXoaMon";
            this.btnXoaMon.Size = new System.Drawing.Size(102, 27);
            this.btnXoaMon.TabIndex = 1;
            this.btnXoaMon.Text = "Xóa món";
            this.btnXoaMon.UseVisualStyleBackColor = true;
            this.btnXoaMon.Click += new System.EventHandler(this.btnXoaMon_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(804, 140);
            this.panel2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCapNhat);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtTenMonCS);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtGiaBanCS);
            this.groupBox2.Controls.Add(this.txtGhiChuCS);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(409, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(383, 131);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sửa món";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên món:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Enabled = false;
            this.btnCapNhat.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown;
            this.btnCapNhat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.btnCapNhat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.Location = new System.Drawing.Point(272, 92);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(105, 27);
            this.btnCapNhat.TabIndex = 3;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ghi chú:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenMonCS
            // 
            this.txtTenMonCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMonCS.Location = new System.Drawing.Point(108, 31);
            this.txtTenMonCS.MaxLength = 30;
            this.txtTenMonCS.Name = "txtTenMonCS";
            this.txtTenMonCS.Size = new System.Drawing.Size(269, 26);
            this.txtTenMonCS.TabIndex = 0;
            this.txtTenMonCS.TextChanged += new System.EventHandler(this.txtTenMonCS_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Giá bán:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGiaBanCS
            // 
            this.txtGiaBanCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBanCS.Location = new System.Drawing.Point(108, 63);
            this.txtGiaBanCS.MaxLength = 10;
            this.txtGiaBanCS.Name = "txtGiaBanCS";
            this.txtGiaBanCS.Size = new System.Drawing.Size(269, 26);
            this.txtGiaBanCS.TabIndex = 1;
            this.txtGiaBanCS.TextChanged += new System.EventHandler(this.txtTenMonCS_TextChanged);
            this.txtGiaBanCS.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaBan_KeyPress);
            // 
            // txtGhiChuCS
            // 
            this.txtGhiChuCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChuCS.Location = new System.Drawing.Point(108, 92);
            this.txtGhiChuCS.MaxLength = 30;
            this.txtGhiChuCS.Name = "txtGhiChuCS";
            this.txtGhiChuCS.Size = new System.Drawing.Size(158, 26);
            this.txtGhiChuCS.TabIndex = 2;
            this.txtGhiChuCS.TextChanged += new System.EventHandler(this.txtTenMonCS_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtGhiChu);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtGiaBan);
            this.groupBox1.Controls.Add(this.txtTenMon);
            this.groupBox1.Controls.Add(this.btnThemMon);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(383, 131);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thêm món";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Ghi chú:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Giá bán:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(104, 92);
            this.txtGhiChu.MaxLength = 30;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(162, 26);
            this.txtGhiChu.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên món:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBan.Location = new System.Drawing.Point(104, 61);
            this.txtGiaBan.MaxLength = 10;
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(273, 26);
            this.txtGiaBan.TabIndex = 1;
            this.txtGiaBan.TextChanged += new System.EventHandler(this.txtTenMon_TextChanged);
            this.txtGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaBan_KeyPress);
            // 
            // txtTenMon
            // 
            this.txtTenMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenMon.Location = new System.Drawing.Point(104, 31);
            this.txtTenMon.MaxLength = 30;
            this.txtTenMon.Name = "txtTenMon";
            this.txtTenMon.Size = new System.Drawing.Size(273, 26);
            this.txtTenMon.TabIndex = 0;
            this.txtTenMon.TextChanged += new System.EventHandler(this.txtTenMon_TextChanged);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Enabled = false;
            this.btnThemMon.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown;
            this.btnThemMon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.btnThemMon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnThemMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMon.Location = new System.Drawing.Point(272, 92);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(105, 27);
            this.btnThemMon.TabIndex = 3;
            this.btnThemMon.Text = "Thêm món";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.FlatAppearance.BorderColor = System.Drawing.Color.SandyBrown;
            this.btnQuayLai.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Coral;
            this.btnQuayLai.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SandyBrown;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnQuayLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuayLai.Location = new System.Drawing.Point(12, 8);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(98, 27);
            this.btnQuayLai.TabIndex = 0;
            this.btnQuayLai.Text = "Quay lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            this.btnQuayLai.Click += new System.EventHandler(this.btnQuayLai_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTimMon);
            this.panel1.Controls.Add(this.btnXoaMon);
            this.panel1.Controls.Add(this.btnQuayLai);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 41);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(227, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tìm món:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTimMon
            // 
            this.txtTimMon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtTimMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimMon.Location = new System.Drawing.Point(318, 8);
            this.txtTimMon.MaxLength = 30;
            this.txtTimMon.Name = "txtTimMon";
            this.txtTimMon.Size = new System.Drawing.Size(273, 26);
            this.txtTimMon.TabIndex = 2;
            this.txtTimMon.TextChanged += new System.EventHandler(this.txtTimMon_TextChanged);
            // 
            // QuanLyMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 486);
            this.Controls.Add(this.dagvMon);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuanLyMon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Món";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuanLyMon_FormClosing);
            this.Load += new System.EventHandler(this.QuanLyMon_Load);
            this.SizeChanged += new System.EventHandler(this.QuanLyMon_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dagvMon)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dagvMon;
        private System.Windows.Forms.Button btnXoaMon;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenMon;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtGhiChuCS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGiaBanCS;
        private System.Windows.Forms.TextBox txtTenMonCS;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTimMon;

    }
}