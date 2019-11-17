using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using _KTPM_QuanLyCafe;
using _KTPM_QuanLyCafe.QuanTri;

namespace _KTPM_QuanLyCafe.NhanVien
{
    public partial class QuanLyHoaDon : Form
    {
        public QuanLyHoaDon(string who)
        {
            InitializeComponent();
            if (who.Contains("thungan"))
            {
                btnQuayLai.Visible = false;
                lbIDThuNgan.Text = "ID Thu ngân: " + who + " | " + DateTime.Now.ToString();
                btnThongKe.Visible = false;
            }
            else
            {
                lbIDThuNgan.Visible = false;
                btnQuayLai.Visible = true;
                btnThongKe.Visible = true;
            }
        }

        private SqlConnection connect = new SqlConnection(Program.sqlConnection);
        DataTable dtChiTietHoaDon = Program.GetDataChiTietHoaDon();
        DataTable dtHoaDon = Program.GetDataHoaDon();
        DataTable dtBan = Program.GetDataBan();
        DataTable dtMon = Program.GetDataMon();

        private void QuanLyHoaDon_Load(object sender, EventArgs e)
        {
            //Load dữ liệu
            dagvHoaDon.DataSource = dtHoaDon;
            foreach (DataRow dr in dtBan.Rows)
            {
                if (Boolean.Parse(dr["TinhTrang"].ToString()) == true)
                    cbxMaBan.Items.Add(dr["MaBan"]);
            }
            cbxMaBan.Text = cbxMaBan.Items[0].ToString();

            cbxDSMon.DataSource = dtMon;
            cbxDSMon.DisplayMember = "TenMon";
            cbxDSMon.ValueMember = "MaMon";

            cbxXemDSHoaDon.Text = cbxXemDSHoaDon.Items[0].ToString();

            grbThongKe.Visible = false;

            dtpTu.MaxDate = DateTime.Now;
            dtpDen.MaxDate = DateTime.Now;
            dtpDen.MinDate = dtpTu.Value.Date;
        }

        public void RefreshData()
        {
            dtHoaDon = Program.GetDataHoaDon();
            dtBan = Program.GetDataBan();
            dtMon = Program.GetDataMon();

            KiemTraBtnChuyenBan();
            KiemTraBtnThanhToan();
            KiemTraBtnThemMon();

            dtChiTietHoaDon.Clear();
            dagvChiTietHoaDon.DataSource = dtChiTietHoaDon;

            LocHoaDon();

            cbxMaBan.Items.Clear();
            foreach (DataRow dr in dtBan.Rows)
            {
                if (Boolean.Parse(dr["TinhTrang"].ToString()) == true)
                    cbxMaBan.Items.Add(dr["MaBan"]);
            }
            cbxMaBan.Text = cbxMaBan.Items[0].ToString();
        }

        public bool KiemTraTinhTrangBan(int maBan)
        {
            foreach (DataRow dr in dtBan.Rows)
            {
                if (int.Parse(dr["MaBan"].ToString()) == maBan)
                {
                    if (Boolean.Parse(dr["TinhTrang"].ToString()) == true)
                        return true;
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
        
        public int ThemHoaDon()
        {
            try
            {
                DateTime date = DateTime.Now;
                int maBan = int.Parse(cbxMaBan.SelectedItem.ToString());

                TaoMoiVaLuuHoaDon(date, maBan);

                btnThemHoaDon.Enabled = false;
                RefreshData();

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        public int TaoMoiVaLuuHoaDon(DateTime date, int maBan)
        {
            try
            {
                int maHD = 0;
                //Tao ma Hoa Don moi 
                int lastNum = dtHoaDon.Rows.Count;
                if (lastNum == 0)
                    maHD = 1;
                else
                    maHD = int.Parse(dtHoaDon.Rows[lastNum - 1]["MaHoaDon"].ToString()) + 1;

                string lenh = "INSERT INTO HoaDon VALUES({0}, {1}, '{2}', '{3}', {4})";
                string sql = string.Format(lenh, maHD, maBan, date.ToString(), date.ToString(), 0);
                Program.SQLQueryExec(sql);
                Program.CapNhatBanDat(maBan);
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            ThemHoaDon();
        }

        private void cbxMaBan_SelectedValueChanged(object sender, EventArgs e)
        {
            int maBan = int.Parse(cbxMaBan.SelectedItem.ToString());
            if (!KiemTraTinhTrangBan(maBan))
            {
                btnThemHoaDon.Enabled = false;
            }
            else
            {
                btnThemHoaDon.Enabled = true;
            }
        }

        public bool KiemTraHoaDonDaThanhToan(int maHoaDon)
        {
            foreach (DataRow dr in dtHoaDon.Rows)
            {
                if (int.Parse(dr["MaHoaDon"].ToString()) == maHoaDon)
                {
                    if (DateTime.Compare(DateTime.Parse(dr["NgayTaoHoaDon"].ToString()), DateTime.Parse(dr["NgayGioThanhToan"].ToString()))
                        == 0)
                        return false;
                    else
                        return true;
                }
            }
            return true;
        }

        public int ThanhToanHoaDon(int maHoaDon, int maBan)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn thanh toán hóa đơn " + maHoaDonChon.ToString(), "Thanh toán",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DateTime date = DateTime.Now;

                    ThanhToanVaLuuHoaDon(maHoaDon, date);

                    Program.CapNhatBanTrong(maBan);
                    btnThanhToan.Enabled = false;
                    RefreshData();

                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        public int ThanhToanVaLuuHoaDon(int maHoaDon, DateTime date)
        {
            try
            {
                connect.Open();

                string lenh = "UPDATE HoaDon SET NgayGioThanhToan='{0}' WHERE MaHoaDon={1}";
                string sql = string.Format(lenh, date.ToString(), maHoaDon.ToString());
                SqlCommand sqlC = new SqlCommand(sql, connect);
                sqlC.ExecuteNonQuery();

                connect.Close();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
           ThanhToanHoaDon(maHoaDonChon, maBanChon);
        }

        public void KiemTraBtnThanhToan()
        {
            if (maHoaDonChon == 0)
            {
                btnThanhToan.Enabled = false;
            }
            if (maHoaDonChon != 0 && !KiemTraHoaDonDaThanhToan(maHoaDonChon))
            {
                btnThanhToan.Enabled = true;
            }
            else
            {
                btnThanhToan.Enabled = false;
            }
        }

        public void KiemTraBtnChuyenBan()
        {
            if (maHoaDonChon == 0)
            {
                btnChuyenBan.Enabled = false;
            }
            if (!KiemTraHoaDonDaThanhToan(maHoaDonChon) &&
                KiemTraTinhTrangBan(int.Parse(cbxMaBan.SelectedItem.ToString())))
            {
                btnChuyenBan.Enabled = true;
            }
            else
            {
                btnChuyenBan.Enabled = false;
            }
        }

        private int maHoaDonChon = 0;
        private int maBanChon = 0;
        //Lấy mã hóa đơn và mã bàn được chọn trong dagvHoaDon khi click vào từng ô
        private void dagvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow drHoaDon = this.dagvHoaDon.Rows[e.RowIndex];
                maHoaDonChon = int.Parse(drHoaDon.Cells[0].Value.ToString());
                maBanChon = int.Parse(drHoaDon.Cells[1].Value.ToString());

                KiemTraBtnThanhToan();

                KiemTraBtnChuyenBan();

                KiemTraBtnThemMon();

                HienThiCTHoaDon();
            }
        }

        public int ChuyenBan(int maBanMoi, int maHoaDon, int maBanCu)
        {
            try
            {
                if (MessageBox.Show("Chuyển bàn hóa đơn " + maHoaDon.ToString() +
                                    " từ bàn " + maBanCu.ToString() + " -> " + maBanMoi.ToString() + "?",
                        "Chuyển bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Program.SQLQueryExec("UPDATE HoaDon SET MaBan=" + maBanMoi.ToString() +
                                         " WHERE MaHoaDon=" + maHoaDon);
                    Program.CapNhatBanDat(maBanMoi);
                    Program.CapNhatBanTrong(maBanCu);
                    
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            int maBan = int.Parse(cbxMaBan.SelectedItem.ToString());

            ChuyenBan(maBan, maHoaDonChon, maBanChon);

            btnChuyenBan.Enabled = false;
            RefreshData();
        }

        private void QuanLyHoaDon_FormClosing(object sender, FormClosingEventArgs e)
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

        //Lọc chữ và ký tự
        private void txtSoLuongMon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void KiemTraBtnThemMon()
        {
            if (maHoaDonChon == 0)
            {
                btnThemMon.Enabled = false;
            }
            if (txtSoLuongMon.Text != "" && !KiemTraHoaDonDaThanhToan(maHoaDonChon))
            {
                btnThemMon.Enabled = true;
            }
            else
            {
                btnThemMon.Enabled = false;
            }
        }

        private void txtSoLuongMon_TextChanged(object sender, EventArgs e)
        {
            char[] aSC = txtSoLuongMon.Text.ToCharArray();
            foreach (char c in aSC)
            {
                if (!Char.IsNumber(c))
                {
                    txtSoLuongMon.Text = "";
                    break;
                }
            }
            KiemTraBtnThemMon();
        }

        //Hàm hiển thị bảng ChiTietHoaDon vao dagvChiTietHoaDon
        public int HienThiCTHoaDon()
        {
            try
            {
                dtChiTietHoaDon = Program.GetDataChiTietHoaDon();
                string dk = "MaHoaDon=" + maHoaDonChon;
                DataRow[] rows = dtChiTietHoaDon.Select(dk);
                DataTable dtCTHD = new DataTable();
                dtCTHD.Columns.Add("MaMon", typeof(Int32));
                dtCTHD.Columns.Add("TenMon", typeof(string));
                dtCTHD.Columns.Add("GiaBan", typeof(decimal));
                dtCTHD.Columns.Add("SoLuong", typeof(Int32));
                dtCTHD.Columns.Add("DonGia", typeof(decimal));
                dtCTHD.Columns.Add("GhiChu", typeof(string));

                foreach (DataRow dr in rows)
                {
                    dtCTHD.ImportRow(dr);
                }
                dagvChiTietHoaDon.DataSource = dtCTHD;

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        //XỬ LÝ CHỨC NĂNG THÊM MÓN VÀO HÓA ĐƠN
        public int ThemMon(int maHoaDon)
        {
            try
            {
                //Lấy các giá trị cần thiết để tạo một CTHĐ mới

                //Mã món
                int maMon = int.Parse(dtMon.Rows[cbxDSMon.SelectedIndex]["MaMon"].ToString());

                //Số lượng
                int soLuong = -1;
                try
                {
                    soLuong = int.Parse(txtSoLuongMon.Text);
                    if (soLuong == 0)
                    {
                        txtSoLuongMon.Text = "";
                        MessageBox.Show("Số lượng món phải > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return 0;
                    }
                }
                catch (FormatException e)
                {
                    MessageBox.Show("Lỗi định dạng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 0;
                }
                
                //Giá bán và đơn giá
                float giaBan = float.Parse(dtMon.Rows[cbxDSMon.SelectedIndex]["GiaBan"].ToString()); //Lấy giá bán
                float donGia = giaBan * soLuong; // Lấy đơn giá

                //Ghi chú
                string ghiChu = "";
                if (txtGhiChu.Text != "Ghi chú")
                    ghiChu = txtGhiChu.Text; //Lấy ghi chú của món

                //Nếu món đã có trong CTHD tại maHoaDon: Cập nhật lại số lượng món đó và đơn giá
                if (KiemTraMonDaTonTai(maHoaDon, maMon))
                {
                    CapNhatMonCuCTHD(maHoaDon, maMon, soLuong, donGia, ghiChu);
                }
                //Nếu món chưa có trong CTHD tại maHoaDon: Tạo mới một CTHD
                else
                {
                    string tenMon = dtMon.Rows[cbxDSMon.SelectedIndex]["TenMon"].ToString(); //Lấy tên món

                    ThemMonMoiCTHD(maHoaDon, maMon, tenMon, giaBan, soLuong, donGia, ghiChu);
                }

                //Refresh các thông tin sau khi thêm món
                txtGhiChu.Text = "";
                txtSoLuongMon.Text = "";
                btnThemMon.Enabled = false;
                CapNhatTongTienHoaDon(maHoaDon, donGia);

                //Tải lại dữ liệu bảng chi tiết hóa đơn
                dtChiTietHoaDon = Program.GetDataChiTietHoaDon();
                dtHoaDon = Program.GetDataHoaDon();
                LocHoaDon();
                HienThiCTHoaDon();

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        public int CapNhatMonCuCTHD(int maHoaDon, int maMon, int soLuong, double donGia, string ghiChu)
        {
            try
            {
                string sqlKTMon = string.Format("exec dbo.ThemMonVaoChiTietHoaDon {0},{1},{2},{3}, N'{4}'", maHoaDon, maMon, soLuong, donGia, ghiChu);
                SqlConnection connect = new SqlConnection(Program.sqlConnection);
                connect.Open();
                SqlCommand sqlC = new SqlCommand(sqlKTMon, connect);
                sqlC.ExecuteNonQuery();
                connect.Close();

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        public int ThemMonMoiCTHD(int maHoaDon, int maMon, string tenMon, double giaBan, 
            int soLuong, double donGia, string ghiChu)
        {
            try
            {
                string lenh = "INSERT INTO ChiTietHoaDon VALUES({0}, {1}, N'{2}', {3}, {4}, {5}, N'{6}')";
                string sql = string.Format(lenh, maHoaDon, maMon, tenMon, giaBan, soLuong, donGia, ghiChu);
                Program.SQLQueryExec(sql);

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            ThemMon(maHoaDonChon);   
        }

        //Hàm kiểm tra món đã có tại chi tiết hóa đơn chưa
        public bool KiemTraMonDaTonTai(int maHoaDon, int maMon)
        {
            foreach (DataRow dr in dtChiTietHoaDon.Rows)
            {
                if (int.Parse(dr["MaHoaDon"].ToString()) == maHoaDon)
                {
                    if (int.Parse(dr["MaMon"].ToString()) == maMon)
                        return true;
                }
            }
            return false;
        }
        //Hàm cập nhật tổng tiền của HĐ tại maHoaDon
        public int CapNhatTongTienHoaDon(int maHoaDon, float donGia)
        {
            try
            {
                float tongTien = donGia;
                tongTien += float.Parse(dtHoaDon.Rows[maHoaDon - 1]["TongTien"].ToString());
                Program.SQLQueryExec("UPDATE HoaDon SET TongTien=" + tongTien.ToString() + " WHERE MaHoaDon=" + maHoaDon);

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        //Hàm hiển thị các hóa đơn theo điều kiện nhận vào từ cbxXemDSHoaDon
        public int LocHoaDon()
        {
            try
            {
                switch (cbxXemDSHoaDon.SelectedItem.ToString())
                {
                    case "Tất cả hóa đơn":
                        {
                            dagvHoaDon.DataSource = dtHoaDon;
                        };
                        break;
                    case "Hóa đơn chưa thanh toán":
                        {
                            //Tạo câu lệnh điều kiện
                            string dk = "NgayTaoHoaDon = NgayGioThanhToan";
                            //Lọc các hóa đơn theo điều kiện
                            //Lưu các hóa đơn vừa lọc vài mảng DataRow
                            DataRow[] rows = dtHoaDon.Select(dk);
                            //Tạo DataTable tạm thời giống với dtHoaDon
                            DataTable dtHD = new DataTable();
                            dtHD.Columns.Add("MaHoaDon", typeof(Int32));
                            dtHD.Columns.Add("MaBan", typeof(Int32));
                            dtHD.Columns.Add("NgayTaoHoaDon", typeof(DateTime));
                            dtHD.Columns.Add("NgayGioThanhToan", typeof(DateTime));
                            dtHD.Columns.Add("TongTien", typeof(decimal));

                            foreach (DataRow dr in rows)
                            {
                                //Đem các giá trị từ mảng DataRow vào DataTable tạm thời vừa tạo
                                dtHD.ImportRow(dr);
                            }
                            dagvHoaDon.DataSource = dtHD; //Gán vào dagvHoaDon
                        };
                        break;
                    case "Hóa đơn đã thanh toán":
                        {
                            string dk = "NgayTaoHoaDon<>NgayGioThanhToan";
                            DataRow[] rows = dtHoaDon.Select(dk);
                            DataTable dtHD = new DataTable();
                            dtHD.Columns.Add("MaHoaDon", typeof(Int32));
                            dtHD.Columns.Add("MaBan", typeof(Int32));
                            dtHD.Columns.Add("NgayTaoHoaDon", typeof(DateTime));
                            dtHD.Columns.Add("NgayGioThanhToan", typeof(DateTime));
                            dtHD.Columns.Add("TongTien", typeof(decimal));

                            foreach (DataRow dr in rows)
                            {
                                dtHD.ImportRow(dr);
                            }
                            dagvHoaDon.DataSource = dtHD;
                        };
                        break;
                }

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }

        //Xem danh sách các hóa đơn theo điều kiện nhận vô từ cbxXemDSHoaDon
        private void cbxXemDSHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            maHoaDonChon = 0;
            RefreshData();
        }

        //Bỏ phần chữ "Ghi chú" khi người dùng click vào txtGhiChu
        private void txtGhiChu_Click(object sender, EventArgs e)
        {
            txtGhiChu.Text = "";
        }

        //Định kích thước bé nhất from có thể co được
        private void QuanLyHoaDon_SizeChanged(object sender, EventArgs e)
        {
            if (this.Width < 820)
                this.Width = 820;
            if (this.Height < 550)
                this.Height = 550;
        }
        
        //XỬ LÝ CHỨC NĂNG THỐNG KÊ
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (btnThongKe.Text == "Thống kê")
            {
                //Tắt các chức năng của phần đặt bàn
                btnThongKe.Text = "Đặt bàn";
                grbChonMaBan.Visible = false;
                grbChonMon.Visible = false;
                btnThanhToan.Visible = false;
                lbXemDSHoaDon.Visible = false;
                cbxXemDSHoaDon.Visible = false;

                //Lọc chọn các hóa đơn đã thanh toán để thống kê
                cbxXemDSHoaDon.Text = cbxXemDSHoaDon.Items[2].ToString();
                RefreshData();
                
                grbThongKe.Visible = true;
            }
            else
            {
                btnThongKe.Text = "Thống kê";
                grbChonMaBan.Visible = true;
                grbChonMon.Visible = true;
                btnThanhToan.Visible = true;
                lbXemDSHoaDon.Visible = true;
                cbxXemDSHoaDon.Visible = true;

                RefreshData();
                grbThongKe.Visible = false;
            }
        }
        //Hàm hiển thị các HĐ trong khoảng thời gian người dùng chọn
        public int LayHDTrongKhoang()
        {
            try
            {
                //Tạo câu lệnh sql (Dùng Proc đã tạo bên sql server)
                string tuNgay = dtpTu.Value.ToShortDateString();
                string denNgay = dtpDen.Value.ToShortDateString();
                string sql = "exec ProcXuatHDTrongKhoangThoiGian '" +
                             tuNgay.ToString() + " 0:00:0 AM','" +
                             denNgay.ToString() + " 23:59:59 PM'";

                SqlConnection connect = new SqlConnection(Program.sqlConnection);
                connect.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, connect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                connect.Close();

                dagvHoaDon.DataSource = dt; //Gán dữ liệu vừa load và dagvHoaDon

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }
        //Hàm tính tổng doanh thu
        public decimal TinhTongDoanhThu()
        {
            try
            {
                decimal doanhThu = 0;
                foreach (DataGridViewRow dr in dagvHoaDon.Rows)
                {
                    doanhThu += decimal.Parse(dr.Cells["TongTien"].Value.ToString());
                }
                return doanhThu;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return -1;
            }
        }
        //Hàm về các lệnh cần làm khi có sự thay đổi ở dtpTu và dtpDen
        public int ThongKe()
        {
            try
            {
                //Định số ngày bé nhất có thể chọn cho dtpDen
                dtpDen.MinDate = dtpTu.Value;
                //Tính tổng số ngày trong khoảng dtpTu đến dtpDen
                TimeSpan soNgay = dtpDen.Value - dtpTu.Value;
                lbSoNgay.Text = (soNgay.Days + 1).ToString();
                //Hiển thị ngày trong khoảng đã chọn
                LayHDTrongKhoang();
                //Tính số hóa đơn có trong khoảng ngày đã chọn
                lbSoHoaDon.Text = dagvHoaDon.Rows.Count.ToString();
                //Gán tổng doanh thu
                lbDoanhThu.Text = string.Format("{0:n} VNĐ", TinhTongDoanhThu().ToString());

                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Thông báo", MessageBoxButtons.OK);
                return 0;
            }
        }
        private void dtpTu_ValueChanged(object sender, EventArgs e)
        {
            ThongKe();
        }
        private void dtpDen_ValueChanged(object sender, EventArgs e)
        {
            ThongKe();
        }
    }
}
