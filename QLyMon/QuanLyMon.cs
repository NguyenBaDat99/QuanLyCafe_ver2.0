using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using _KTPM_QuanLyCafe.Mon;

namespace _KTPM_QuanLyCafe.QuanTri
{
    public partial class QuanLyMon : Form
    {

        public QuanLyMon()
        {
            InitializeComponent();
        }

        DSMon dsMon = new DSMon();

        private void QuanLyMon_Load(object sender, EventArgs e)
        {
            dsMon.TaiDuLieu();
            dagvMon.DataSource = dsMon.TaoDataTableAo();
        }

        private void QuanLyMon_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Form fMenuQuanTri = new MenuQuanTri();
            fMenuQuanTri.Show();
            this.Hide();
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtTenMon_TextChanged(object sender, EventArgs e)
        {
            char[] aSC = txtGiaBan.Text.ToCharArray();
            foreach (char c in aSC)
            {
                if (!Char.IsNumber(c))
                {
                    txtGiaBan.Text = "";
                    break;
                }
            }
            KiemTraBtnThemMon();
        }

        private void txtTenMonCS_TextChanged(object sender, EventArgs e)
        {
            char[] aSC = txtGiaBanCS.Text.ToCharArray();
            foreach (char c in aSC)
            {
                if (!Char.IsNumber(c))
                {
                    txtGiaBanCS.Text = "";
                    break;
                }
            }
            KiemTraBtnCapNhat();
        }

        private void QuanLyMon_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 820)
                this.Width = 820;
            if (this.Height < 450)
                this.Height = 450;
        }

        public void RefreshData()
        {
            dsMon.LuuDuLieu();
            dagvMon.DataSource = dsMon.TaoDataTableAo();
            maMonChon = 0;
        }

        public void RefreshTextBox()
        {
            txtTenMon.Text = "";
            txtGhiChu.Text = "";

            txtTenMonCS.Text = "";
            txtGhiChuCS.Text = "";
        }

        public void KiemTraBtnThemMon()
        {
            if (txtTenMon.Text != "" && txtGiaBan.Text != "" && !dsMon.KiemTraTenMonTrung(txtTenMon.Text))
                btnThemMon.Enabled = true;
            else btnThemMon.Enabled = false;
        }

        public void KiemTraBtnXoa()
        {
            if (maMonChon != 0)
                btnXoaMon.Enabled = true;
            else
                btnXoaMon.Enabled = false;
        }

        public void KiemTraBtnCapNhat()
        {
            if (maMonChon != 0 && !dsMon.KiemTraTenMonTrung(txtTenMonCS.Text))
            {
                if (txtTenMonCS.Text != "" || txtGiaBanCS.Text != "" || txtGhiChuCS.Text != "")
                    btnCapNhat.Enabled = true;
                else btnCapNhat.Enabled = false;
            }
            else btnCapNhat.Enabled = false;
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            dsMon.ThemMon(txtTenMon.Text, float.Parse(txtGiaBan.Text), txtGhiChu.Text);
            dsMon.SapXep();
            RefreshData();
            RefreshTextBox();
            btnThemMon.Enabled = false;
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            dsMon.XoaMon(maMonChon);
            RefreshData();
            btnXoaMon.Enabled = false;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tenMon = txtTenMonCS.Text;
            string ghiChu = txtGhiChuCS.Text;
            float giaBan = 0;
            if (txtGiaBanCS.Text != "")
                giaBan = float.Parse(txtGiaBanCS.Text);

            dsMon.CapNhat(maMonChon, tenMon, giaBan, ghiChu);
            RefreshData();
            btnCapNhat.Enabled = false;
            RefreshTextBox();
        }

        private void txtTimMon_TextChanged(object sender, EventArgs e)
        {
            if (txtTimMon.Text != "")
                dagvMon.DataSource = dsMon.DsMonYeuCau(txtTimMon.Text).TaoDataTableAo();
            else
                dagvMon.DataSource = dsMon.TaoDataTableAo();
        }

        private int maMonChon = 0;
        private DataGridViewRow drMonChon = null;
        private void dagvMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                drMonChon = this.dagvMon.Rows[e.RowIndex];
                maMonChon = int.Parse(drMonChon.Cells[0].Value.ToString());
                KiemTraBtnXoa();
                KiemTraBtnCapNhat();
            }
        }

    }
}
