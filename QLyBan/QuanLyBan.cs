using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using _KTPM_QuanLyCafe.Ban;

namespace _KTPM_QuanLyCafe.QuanTri
{
    public partial class QuanLyBan : Form
    {
        public QuanLyBan()
        {
            InitializeComponent();
        }

        DSBan dsBan = new DSBan();
        DSBan dsBanHienTai = new DSBan();

        private void QuanLyBan_Load(object sender, EventArgs e)
        {
            dsBan.TaiDuLieu();
            dsBanHienTai = dsBan;
            dagvBan.DataSource = dsBan.TaoDataTableAo();
            cbxDSBan.Text = cbxDSBan.Items[0].ToString();
        }

        private void QuanLyBan_FormClosing(object sender, FormClosingEventArgs e)
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

        private void QuanLyBan_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 820)
                this.Width = 820;
            if (this.Height < 450)
                this.Height = 450;
        }

        private void txtSucChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        
        private int maBanChon = 0;
        private void dagvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = this.dagvBan.Rows[e.RowIndex];
                maBanChon = int.Parse(dr.Cells[0].Value.ToString());
                KiemTraBtnXoa();
                KiemTraBtnCapNhat();
            }
        }

        private void txtSucChua_TextChanged(object sender, EventArgs e)
        {
            char[] aSC = txtSucChua.Text.ToCharArray();
            foreach (char c in aSC)
            {
                if (!Char.IsNumber(c))
                {
                    txtSucChua.Text = "";
                    break;
                }
            }
            KiemTraBtnThemBan();
        }

        private void txtSucChuaCS_TextChanged(object sender, EventArgs e)
        {
            char[] aSC = txtSucChuaCS.Text.ToCharArray();
            foreach (char c in aSC)
            {
                if (!Char.IsNumber(c))
                {
                    txtSucChuaCS.Text = "";
                    break;
                }
            }
            KiemTraBtnCapNhat();
        }

        public void KiemTraBtnThemBan()
        {
            if (txtSucChua.Text != "")
                if (Ban.Ban.KiemTraSucChua(int.Parse(txtSucChua.Text)))
                    btnThemBan.Enabled = true;
                else
                    btnThemBan.Enabled = false;
            else
                btnThemBan.Enabled = false;
        }

        public void KiemTraBtnCapNhat()
        {
            if (maBanChon != 0 && txtSucChuaCS.Text != "")
                if (Ban.Ban.KiemTraSucChua(int.Parse(txtSucChuaCS.Text)) && dsBan.KiemTraTinhTrangBan(maBanChon))
                    btnCapNhat.Enabled = true;
                else
                    btnCapNhat.Enabled = false;
            else
                btnCapNhat.Enabled = false;
        }

        public void KiemTraBtnXoa()
        {
            if (dsBan.KiemTraTinhTrangBan(maBanChon) && maBanChon != 0)
            {
                btnXoaBan.Enabled = true;
            }
            else
            {
                btnXoaBan.Enabled = false;
            }
        }

        public void RefreshData()
        {
            dsBan.LuuDuLieu();
            LocBan();
            maBanChon = 0;
            KiemTraBtnCapNhat();
            KiemTraBtnXoa();
        }

        public void LocBan()
        {
            switch (cbxDSBan.SelectedItem.ToString())
            {
                case "Tất cả bàn":
                {
                    dsBanHienTai = dsBan;
                    dagvBan.DataSource = dsBanHienTai.TaoDataTableAo();

                }
                    break;
                case "Bàn trống":
                {
                    dsBanHienTai = dsBan.DsBanTrong();
                    dagvBan.DataSource = dsBanHienTai.TaoDataTableAo();
                }
                    break;
                case "Bàn đang đặt":
                {
                    dsBanHienTai = dsBan.DsBanDat();
                    dagvBan.DataSource = dsBanHienTai.TaoDataTableAo();
                }
                    break;
            }
        }

        private void btnThemBan_Click(object sender, EventArgs e)
        {
            dsBan.ThemBan(int.Parse(txtSucChua.Text));
            dsBan.SapXep();
            RefreshData();
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            dsBan.XoaBan(maBanChon);
            RefreshData();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            dsBan.CapNhatSucChua(maBanChon, int.Parse(txtSucChuaCS.Text));
            RefreshData();
        }

        private void cbxDSBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocBan();
            txtTimBan.Text = "";
            btnCapNhat.Enabled = false;
            btnXoaBan.Enabled = false;
            maBanChon = 0;
        }

        private void txtTimBan_TextChanged(object sender, EventArgs e)
        {
            char[] aSC = txtTimBan.Text.ToCharArray();
            foreach (char c in aSC)
            {
                if (!Char.IsNumber(c))
                {
                    txtTimBan.Text = "";
                    break;
                }
            }
            if (txtTimBan.Text != "")
                dagvBan.DataSource = dsBanHienTai.DsBanYeuCau(txtTimBan.Text).TaoDataTableAo();
            else
                dagvBan.DataSource = dsBanHienTai.TaoDataTableAo();
        }
    }
}
