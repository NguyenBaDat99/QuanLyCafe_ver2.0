using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using _KTPM_QuanLyCafe.NhanVien;
using _KTPM_QuanLyCafe.QuanTri;
using System.Data;
using System.Data.SqlClient;

namespace _KTPM_QuanLyCafe
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DangNhap());
        }

        public static string sqlConnection = @"Data Source=DAT\SQLEXPRESS;Initial Catalog=Database_Cafe;Integrated Security=True";

        public static DataTable GetDataHoaDon()
        {
            SqlConnection connect = new SqlConnection(sqlConnection);
            connect.Open();

            //Khởi tạo đối tượng đọc dữ liệu
            SqlDataAdapter da = new SqlDataAdapter("select * from HoaDon", connect);
            //Khai báo database để chứa dữ liệu
            DataTable dt = new DataTable();
            //Điền dữ liệu vào database
            da.Fill(dt);

            connect.Close();
            return dt;
        }

        public static DataTable GetDataChiTietHoaDon()
        {
            SqlConnection connect = new SqlConnection(sqlConnection);
            connect.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from ChiTietHoaDon", connect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            connect.Close();
            return dt;
        }

        public static DataTable GetDataBan()
        {
            SqlConnection connect = new SqlConnection(sqlConnection);
            connect.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from Ban", connect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            connect.Close();
            return dt;
        }

        public static DataTable GetDataMon()
        {
            SqlConnection connect = new SqlConnection(sqlConnection);
            connect.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from Mon", connect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            connect.Close();
            return dt;
        }

        public static DataTable GetDataNguoiDung()
        {
            SqlConnection connect = new SqlConnection(sqlConnection);
            connect.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from NguoiDung", connect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            connect.Close();
            return dt;
        }

        public static void SQLQueryExec(string lenh)
        {
            SqlConnection connect = new SqlConnection(sqlConnection);
            connect.Open();

            SqlCommand sqlC = new SqlCommand(lenh, connect);
            sqlC.ExecuteNonQuery();

            connect.Close();
        }
        
        public static void CapNhatBanDat(int maBan)
        {
            if (maBan != 0)
            {
                DataTable dt = GetDataBan();
                foreach (DataRow dr in dt.Rows)
                {
                    if (Boolean.Parse(dr["TinhTrang"].ToString()) == false)
                        continue;
                    else if (int.Parse(dr["MaBan"].ToString()) == maBan)
                    {
                        SQLQueryExec("UPDATE Ban SET TinhTrang='false' WHERE MaBan=" + maBan.ToString());
                        return;
                    }
                }
            }
        }

        public static void CapNhatBanTrong(int maBan)
        {
            DataTable dt = GetDataBan();
            foreach (DataRow dr in dt.Rows)
            {
                if (Boolean.Parse(dr["TinhTrang"].ToString()) == true)
                    continue;
                else if (int.Parse(dr["MaBan"].ToString()) == maBan)
                {
                    SQLQueryExec("UPDATE Ban SET TinhTrang='true' WHERE MaBan=" + maBan.ToString());
                    return;
                }
            }
        }

        
    }
}
