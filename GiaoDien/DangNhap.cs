﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _KTPM_QuanLyCafe.NhanVien;
using _KTPM_QuanLyCafe.QuanTri;


namespace _KTPM_QuanLyCafe
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dg = MessageBox.Show("Thoát chương trình?", "Thoát", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        public string KiemTraTaiKhoan(string tenTaiKhoan, string matKhau)
        {
            try
            {
                SqlConnection connect = new SqlConnection(Program.sqlConnection);
                connect.Open();

                SqlCommand cmd = new SqlCommand("Select * from NguoiDung", connect);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["TenDangNhap"].ToString() == "admin")
                    {
                        if (tenTaiKhoan == dr["TenDangNhap"].ToString())
                        {
                            if (matKhau == dr["MatKhau"].ToString())
                            {
                                connect.Close();
                                Form fQuanTri = new MenuQuanTri();
                                fQuanTri.Show();
                                this.Hide();
                                return "Admin";
                            }
                            else
                            {
                                MessageBox.Show("Sai mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                connect.Close();
                                matKhau = "";
                                return "Sai mat khau tai khoan Admin";
                            }
                        }
                    }
                    else
                    {
                        if (tenTaiKhoan == dr["TenDangNhap"].ToString())
                        {
                            if (matKhau == dr["MatKhau"].ToString())
                            {
                                connect.Close();
                                Form fHoaDon = new QuanLyHoaDon(tenTaiKhoan);
                                fHoaDon.Show();
                                this.Hide();
                                return "ThuNgan";
                            }
                            else
                            {
                                MessageBox.Show("Sai mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                matKhau = "";
                                connect.Close();
                                return "Sai mat khau tai khoan Thu ngan";
                            }
                        }
                    }
                }
                MessageBox.Show("Sai tên đăng nhập!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                connect.Close();
                return "Sai ten dang nhap";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return e.Message;
            }
        }

        public int KiemTraDangNhap()
        {
            try
            {
                string tenTaiKhoan = txtTenDangNhap.Text;
                string matKhau = txtMatKhau.Text;

                KiemTraTaiKhoan(tenTaiKhoan, matKhau);
                txtTenDangNhap.Text = "";
                txtMatKhau.Text = "";
                txtTenDangNhap.Focus();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            KiemTraDangNhap();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                KiemTraDangNhap();
            }
        }

    }
}

