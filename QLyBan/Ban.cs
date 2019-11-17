using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _KTPM_QuanLyCafe.Ban
{
    public class Ban
    {
        private int maBan;
        private int sucChua;
        private bool tinhTrang;

        private const int max_sucChua = 20;
        private const int min_sucChua = 1;

        public Ban()
        {
            this.MaBan = 0;
            this.SucChua = 0;
            this.TinhTrang = true;
        }

        public Ban(int maBan, int sucChua)
        {
            this.MaBan = maBan;
            this.SucChua = sucChua;
            this.TinhTrang = true;
        }

        public Ban(int maBan, int sucChua, bool tinhTrang)
        {
            this.MaBan = maBan;
            this.SucChua = sucChua;
            this.TinhTrang = tinhTrang;
        }

        public int SoSanh(Ban b)
        {
            if (this.MaBan == b.MaBan)
                return 0;
            else if(this.MaBan > b.MaBan)
                return 1;
            else
                return -1;
        }

        public static bool KiemTraSucChua(int sucChua)
        {
            if (sucChua < min_sucChua || sucChua > max_sucChua)
                return false;
            else 
                return true;
        }

        public int MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }

        public int SucChua
        {
            get { return sucChua; }
            set { sucChua = value; }
        }

        public bool TinhTrang
        {
            get { return tinhTrang; }
            set { tinhTrang = value; }
        }
    }
}
