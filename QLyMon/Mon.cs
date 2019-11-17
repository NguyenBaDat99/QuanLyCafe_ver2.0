using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _KTPM_QuanLyCafe.Mon
{
    public class Mon
    {
        private int maMon;
        private string tenMon;
        private float giaBan;
        private string ghiChu;

        public Mon(int maMon, string tenMon, float giaBan, string ghiChu)
        {
            this.MaMon = maMon;
            this.TenMon = tenMon;
            this.GiaBan = giaBan;
            this.GhiChu = ghiChu;
        }

        public Mon()
        {
            this.MaMon = 0;
            this.TenMon = "";
            this.GiaBan = 0;
            this.GhiChu = "";
        }

        public Mon(int maMon, string tenMon)
        {
            this.MaMon = maMon;
            this.TenMon = tenMon;
            this.GiaBan = 0;
            this.GhiChu = "";
        }

        public int SoSanh(Mon m)
        {
            if (this.MaMon == m.MaMon)
                return 0;
            else if (this.MaMon > m.MaMon)
                return 1;
            else
                return -1;
        }

        public int MaMon
        {
            get { return maMon; }
            set { maMon = value; }
        }

        public string TenMon
        {
            get { return tenMon; }
            set { tenMon = value; }
        }

        public float GiaBan
        {
            get { return giaBan; }
            set { giaBan = value; }
        }

        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
    }
}
