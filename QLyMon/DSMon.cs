using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _KTPM_QuanLyCafe.Mon
{
    public class DSMon
    {
        private List<Mon> dsMon = new List<Mon>();

        public List<Mon> DsMon
        {
            get { return dsMon; }
            set { dsMon = value; }
        }

        public void ThemMon(Mon m)
        {
            this.dsMon.Add(m);
        }

        public void XoaMon(Mon m)
        {
            this.dsMon.Remove(m);
        }

        public void XoaMon(int maMon)
        {
            this.dsMon.Remove(this.TimMon(maMon));
        }

        public Mon TimMon(int maMon)
        {
            foreach (Mon m in this.dsMon)
            {
                if (m.MaMon == maMon)
                    return m;
            }
            return null;
        }

        public void SapXep()
        {
            this.dsMon.Sort((m1, m2) => m1.SoSanh(m2));
        }

        public bool KiemTraTenMonTrung(string tenMon)
        {
            foreach (Mon m in this.dsMon)
            {
                if (tenMon == m.TenMon)
                    return true;
            }
            return false;
        }

        public int ThemMon(string tenMon, float giaBan, string ghiChu)
        {
            try
            {
                if (!this.KiemTraTenMonTrung(tenMon))
                {
                    int count = 111;
                    foreach (Mon m in this.DsMon)
                    {
                        if (m.MaMon == 0)
                            continue;
                        if (count < m.MaMon)
                        {
                            break;
                        }
                        count++;
                    }
                    this.DsMon.Add(new Mon(count, tenMon, giaBan, ghiChu));
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

        public void CapNhat(int maMon, string tenMon, float giaBan, string ghiChu)
        {
            if (tenMon != "")
                this.TimMon(maMon).TenMon = tenMon;
            if (giaBan != 0)
                this.TimMon(maMon).GiaBan = giaBan;
            if (ghiChu != "")
                this.TimMon(maMon).GhiChu = ghiChu;
        }

        public DSMon DsMonYeuCau(string kw)
        {
            DSMon kq = new DSMon();
            try
            {
                int maMon = int.Parse(kw);
                bool rong = true;
                foreach (Mon m in dsMon)
                {
                    if (m.MaMon.ToString().Contains(maMon.ToString()))
                    {
                        kq.ThemMon(m);
                        rong = false;
                    } 
                    if(kq.TimMon(m.MaMon) == null)
                        if(m.GiaBan == float.Parse(maMon.ToString()))
                        {
                            kq.ThemMon(m);
                            rong = false;
                        }     
                }
                if (rong)
                {
                    string loi = "Error";
                    int so = int.Parse(loi);
                }
            }
            catch (Exception e)
            {
                try
                {
                    string tenMon = kw;
                    foreach (Mon m in dsMon)
                    {
                        if (m.TenMon.ToLower().Contains(tenMon.ToLower()))
                            kq.ThemMon(m);
                    }
                }
                catch (Exception exception)
                {
                    
                }
            }
            return kq;
        }

        public DataTable TaoDataTableAo()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaMon", typeof(Int32));
            dt.Columns.Add("TenMon", typeof(string));
            dt.Columns.Add("GiaBan", typeof(decimal));
            dt.Columns.Add("GhiChu", typeof(string));

            foreach (Mon m in this.dsMon)
            {
                dt.Rows.Add(m.MaMon, m.TenMon, m.GiaBan, m.GhiChu);
            }

            return dt;
        }

        public void TaiDuLieu()
        {
            DataTable dt = Program.GetDataMon();
            foreach (DataRow dr in dt.Rows)
            {
                Mon m = new Mon();

                m.MaMon = int.Parse(dr["MaMon"].ToString());
                m.TenMon = dr["TenMon"].ToString();
                m.GiaBan = float.Parse(dr["GiaBan"].ToString());
                m.GhiChu = dr["GhiChu"].ToString();

                this.ThemMon(m);
            }
        }

        public void LuuDuLieu()
        {
            Program.SQLQueryExec("delete from Database_Cafe.dbo.Mon");
            foreach (Mon m in this.dsMon)
            {
                int maMon = m.MaMon;
                string tenMon = m.TenMon;
                float giaBan = m.GiaBan;
                string ghiChu = m.GhiChu;
                
                string lenh = string.Format("Insert into Database_Cafe.dbo.Mon values({0},N'{1}',{2},N'{3}')",
                    maMon, tenMon, giaBan, ghiChu);
                Program.SQLQueryExec(lenh);
            }
        }
    }
}
