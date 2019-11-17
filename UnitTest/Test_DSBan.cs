using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _KTPM_QuanLyCafe;
using _KTPM_QuanLyCafe.Ban;

namespace UnitTest
{
    [TestClass]
    public class Test_DSBan
    {
        private _KTPM_QuanLyCafe.Ban.DSBan fDSBan;

        [TestInitialize]
        public void SetUp()
        {
            fDSBan = new DSBan();
        }

        // Test Hàm TimBan
        [TestMethod]
        public void TimBan_Thay()
        {
            Ban b1 = new Ban(111, 15);
            Ban b2 = new Ban(112, 15);
            Ban b3 = new Ban(113, 15);

            DSBan dsB = new DSBan();
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            Ban excepted = b1;
            Ban actual = dsB.TimBan(b1.MaBan);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void TimBan_NhapMaBanDuongKhongTonTai()
        {
            Ban b1 = new Ban(111, 15);
            Ban b2 = new Ban(112, 15);
            Ban b3 = new Ban(113, 15);

            DSBan dsB = new DSBan();
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            Ban excepted = null;
            Ban actual = dsB.TimBan(114);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void TimBan_NhapMaBanAm()
        {
            Ban b1 = new Ban(111, 15);
            Ban b2 = new Ban(112, 15);
            Ban b3 = new Ban(113, 15);

            DSBan dsB = new DSBan();
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            Ban excepted = null;
            Ban actual = dsB.TimBan(-113);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void ThemBan_NhapQuaGioiHanSucChua21()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10);
            Ban b2 = new Ban(112, 15);
            Ban b3 = new Ban(113, 11);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            int excepted = 0;
            int actual = dsB.ThemBan(21);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void ThemBan_NhapQuaGioiHanSucChua0()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10);
            Ban b2 = new Ban(112, 15);
            Ban b3 = new Ban(113, 11);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            int excepted = 0;
            int actual = dsB.ThemBan(0);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void ThemBan_NhapSucChuaAm()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10);
            Ban b2 = new Ban(112, 15);
            Ban b3 = new Ban(113, 11);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            int excepted = 0;
            int actual = dsB.ThemBan(-2);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void ThemBan_NhapDungSucChua()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10);
            Ban b2 = new Ban(112, 15);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);

            dsB.ThemBan(4);

            Ban excepted = new Ban(113, 4);
            Ban actual = dsB.DsBan[3];
            Assert.AreEqual(excepted.SucChua, actual.SucChua);
        }

        [TestMethod]
        public void ThemBan_MaBanChenGiua()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10);
            Ban b2 = new Ban(112, 15);
            Ban b3 = new Ban(114, 16);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            dsB.ThemBan(4);
            dsB.SapXep();

            Ban excepted = new Ban(113, 4);
            Ban actual = dsB.DsBan[3];

            Assert.AreEqual(excepted.MaBan, actual.MaBan);
        }

        [TestMethod]
        public void ThemBan_MaBanChenDau()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(112, 10);
            Ban b2 = new Ban(113, 15);
            Ban b3 = new Ban(114, 16);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            dsB.ThemBan(4);
            dsB.SapXep();

            Ban excepted = new Ban(111, 4);
            Ban actual = dsB.DsBan[1];

            Assert.AreEqual(excepted.MaBan, actual.MaBan);
        }

        [TestMethod]
        public void ThemBan_MaBanChenCuoi()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10);
            Ban b2 = new Ban(112, 15);
            Ban b3 = new Ban(113, 16);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            dsB.ThemBan(4);
            dsB.SapXep();

            Ban excepted = new Ban(114, 4);
            Ban actual = dsB.DsBan[4];

            Assert.AreEqual(excepted.MaBan, actual.MaBan);
        }

        [TestMethod]
        public void KiemTraTinhTrangBan_BanTrong()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10, true);
            Ban b2 = new Ban(112, 15, false);
            Ban b3 = new Ban(113, 16);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            dsB.ThemBan(4);
            dsB.SapXep();

            bool excepted = true;
            bool actual = dsB.KiemTraTinhTrangBan(111);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void KiemTraTinhTrangBan_BanDat()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10, true);
            Ban b2 = new Ban(112, 15, false);
            Ban b3 = new Ban(113, 16);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            dsB.ThemBan(4);
            dsB.SapXep();

            bool excepted = false;
            bool actual = dsB.KiemTraTinhTrangBan(112);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void KiemTraTinhTrangBan_MaBanKhongCo()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10, true);
            Ban b2 = new Ban(112, 15, false);
            Ban b3 = new Ban(113, 16);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);

            dsB.ThemBan(4);
            dsB.SapXep();

            bool excepted = false;
            bool actual = dsB.KiemTraTinhTrangBan(112);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void DsBanTrong_LayDungDSBanTrong()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10, true);
            Ban b2 = new Ban(112, 15, false);
            Ban b3 = new Ban(113, 16, true);
            Ban b4 = new Ban(114, 6, false);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);
            dsB.ThemBan(b4);

            bool excepted = true;
            bool actual = true;
            foreach (Ban b in dsB.DsBanTrong().DsBan)
                if (b.TinhTrang == false)
                {
                    actual = false;
                    break;
                }

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void DsBanDat_LayDungDSBanDat()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10, true);
            Ban b2 = new Ban(112, 15, false);
            Ban b3 = new Ban(113, 16, true);
            Ban b4 = new Ban(114, 6, false);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);
            dsB.ThemBan(b4);

            bool excepted = true;
            bool actual = true;
            foreach (Ban b in dsB.DsBanDat().DsBan)
                if (b.TinhTrang == true)
                {
                    actual = false;
                    break;
                }

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void DsBanYeuCau_TimTheoDungMa()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10, true);
            Ban b2 = new Ban(112, 15, false);
            Ban b3 = new Ban(113, 16, true);
            Ban b4 = new Ban(114, 6, false);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);
            dsB.ThemBan(b4);

            DSBan dsA = dsB.DsBanYeuCau("113");
            bool excepted = true;
            bool actual = false;
            foreach(Ban b in dsA.DsBan)
                if (b.MaBan == 113)
                {
                    actual = true;
                    break;
                }

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void DsBanYeuCau_TimTheoDungSucChua()
        {
            Ban b0 = new Ban(0, 0);
            Ban b1 = new Ban(111, 10, true);
            Ban b2 = new Ban(112, 15, false);
            Ban b3 = new Ban(113, 10, true);
            Ban b4 = new Ban(114, 6, false);

            DSBan dsB = new DSBan();

            dsB.ThemBan(b0);
            dsB.ThemBan(b1);
            dsB.ThemBan(b2);
            dsB.ThemBan(b3);
            dsB.ThemBan(b4);

            DSBan dsA = dsB.DsBanYeuCau("10");
            bool excepted = true;
            bool actual = false;
            foreach (Ban b in dsA.DsBan)
            {
                if (b.SucChua != 10)
                {
                    actual = false;
                    break;
                }
                actual = true;
            }

            Assert.AreEqual(excepted, actual);
        }
    }
}
