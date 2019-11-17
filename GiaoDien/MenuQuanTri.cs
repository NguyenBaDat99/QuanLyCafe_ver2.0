using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _KTPM_QuanLyCafe.NhanVien;

namespace _KTPM_QuanLyCafe.QuanTri
{
    public partial class MenuQuanTri : Form
    {
        public MenuQuanTri()
        {
            InitializeComponent();
        }

        private void MenuQuanTri_Load(object sender, EventArgs e)
        {

        }

        private void MenuQuanTri_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Form fDangNhap = new DangNhap();
                fDangNhap.Show();
                this.Hide();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnQuanLyBan_Click(object sender, EventArgs e)
        {
            Form fQuanLyBan = new QuanLyBan();
            fQuanLyBan.Show();
            this.Hide();
        }

        private void btnQuanLyMon_Click(object sender, EventArgs e)
        {
            Form fQuanLyMon = new QuanLyMon();
            fQuanLyMon.Show();
            this.Hide();
        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {
            Form fQuanLyHoaDon = new QuanLyHoaDon("");
            fQuanLyHoaDon.Show();
            this.Hide();
        }
    }
}
