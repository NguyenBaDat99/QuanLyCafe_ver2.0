using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _KTPM_QuanLyCafe.Ban
{
    public class DSBan
    { 
        private List<Ban> dsBan = new List<Ban>();

        public List<Ban> DsBan
        {
            get { return dsBan; }
            set { dsBan = value; }
        }


        public void ThemBan(Ban b)
        {
            this.DsBan.Add(b);
        }

        public void XoaBan(Ban b)
        {
            this.DsBan.Remove(b);
        }

        public void XoaBan(int maBan)
        {
            this.dsBan.Remove(this.TimBan(maBan));
        }

        public Ban TimBan(int maBan)
        {
            foreach (Ban b in this.DsBan)
            {
                if (b.MaBan == maBan)
                    return b;
            }
            return null;
        }

        public void SapXep()
        {
            this.DsBan.Sort((b1, b2) => b1.SoSanh(b2));
        }

        public int ThemBan(int sucChua)
        {
            try
            {
                if (Ban.KiemTraSucChua(sucChua))
                {
                    int count = 111;
                    foreach (Ban b in this.DsBan)
                    {
                        if (b.MaBan == 0)
                            continue;
                        if (count < b.MaBan)
                        {
                            break;
                        }
                        count++;
                    }
                    this.DsBan.Add(new Ban(count, sucChua));
                    return 1;
                }
                return 0;
            }
            catch (Exception e)
            {
                throw e;
                return 0;
            }
        }

        public void CapNhatSucChua(int maBan, int sucChua)
        {
            this.TimBan(maBan).SucChua = sucChua;
        }

        public bool KiemTraTinhTrangBan(int maBan)
        {
            try
            {
                if (this.TimBan(maBan).TinhTrang == true)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public DSBan DsBanTrong()
        {
            DSBan kq = new DSBan();
            foreach (Ban b in this.dsBan)
            {
                if (b.TinhTrang == true)
                    kq.ThemBan(b);
            }
            return kq;
        }

        public DSBan DsBanDat()
        {
            DSBan kq = new DSBan();
            foreach (Ban b in this.dsBan)
            {
                if (b.TinhTrang == false)
                    kq.ThemBan(b);
            }
            return kq;
        }

        public DSBan DsBanYeuCau(string kw)
        {
            DSBan kq = new DSBan();
            try
            {
                int maBan = int.Parse(kw);
                foreach (Ban b in dsBan)
                {
                    if (b.MaBan.ToString().Contains(maBan.ToString()))
                        kq.ThemBan(b);
                    if (kq.TimBan(b.MaBan) == null)
                        if (b.SucChua == maBan)
                            kq.ThemBan(b);
                }
            }
            catch (Exception e)
            {

            }
            return kq;
        }

        public DataTable TaoDataTableAo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaBan", typeof(Int32));
            dt.Columns.Add("SucChua", typeof(Int32));
            dt.Columns.Add("TinhTrang", typeof(bool));

            foreach (Ban b in this.dsBan)
            {
                dt.Rows.Add(b.MaBan, b.SucChua, b.TinhTrang);
            }

            return dt;
        }

        public void TaiDuLieu()
        {
            DataTable dt = Program.GetDataBan();
            foreach (DataRow dr in dt.Rows)
            {
                Ban b = new Ban();

                b.MaBan = int.Parse(dr["MaBan"].ToString());
                b.SucChua = int.Parse(dr["SucChua"].ToString());
                b.TinhTrang = bool.Parse(dr["TinhTrang"].ToString());

                this.ThemBan(b);
            }
        }

        public void LuuDuLieu()
        {
            Program.SQLQueryExec("delete from Database_Cafe.dbo.Ban");
            foreach (Ban b in this.DsBan)
            {
                int maBan = b.MaBan;
                int sucChua = b.SucChua;
                bool tinhTrang = b.TinhTrang;
                string lenh = string.Format("Insert into Database_Cafe.dbo.Ban values({0},{1},'{2}')", maBan, sucChua, tinhTrang);
                Program.SQLQueryExec(lenh);
            }
        }
    }
}
