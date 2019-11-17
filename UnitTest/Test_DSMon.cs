using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _KTPM_QuanLyCafe.Mon;

namespace UnitTest
{
    [TestClass]
    public class Test_DSMon
    {
        private _KTPM_QuanLyCafe.Mon.DSMon fDSMon;

        [TestInitialize]
        public void SetUp()
        {
            fDSMon = new DSMon();
            Mon m1 = new Mon(111, "Cafe", 15, "");
            Mon m2 = new Mon(112, "Cafe sữa", 17, "");
            Mon m3 = new Mon(113, "Bạc xỉu", 20, "");
            Mon m4 = new Mon(114, "Lipton", 20, "");
            Mon m5 = new Mon(115, "Nước ngọt", 17, "");

            fDSMon.ThemMon(m1);
            fDSMon.ThemMon(m2);
            fDSMon.ThemMon(m3);
            fDSMon.ThemMon(m4);
            fDSMon.ThemMon(m5);
        }

        [TestMethod]
        public void TimMon_TimThay()
        {
            Mon m3 = new Mon(113, "Bạc xỉu", 20, "");
            int excepted = m3.MaMon;
            int actual = fDSMon.TimMon(113).MaMon;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void TimMon_NhapMaMonDuongKhongTonTai()
        {
            Mon excepted = null;
            Mon actual = fDSMon.TimMon(118);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void TimMon_NhapMaMonAm()
        {
            Mon excepted = null;
            Mon actual = fDSMon.TimMon(-118);

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void KiemTraTenMonTrung_NhapTenTrung()
        {
            bool excepted = true;
            bool actual = fDSMon.KiemTraTenMonTrung("Cafe");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void KiemTraTenMonTrung_NhapTenKhongTrung()
        {
            bool excepted = false;
            bool actual = fDSMon.KiemTraTenMonTrung("Soda");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void ThemMon_ThemMonBiTrungTen()
        {
            int excepted = 0;
            int actual = fDSMon.ThemMon("Cafe", 15, "");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void ThemMon_ThemMonThanhCong()
        {
            int excepted = 1;
            int actual = fDSMon.ThemMon("Soda", 15, "");

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void CapNhat_CapNhatTenMon()
        {
            string excepted = "Soda";
            fDSMon.CapNhat(114, "Soda", 0, "");
            string actual = fDSMon.DsMon[3].TenMon;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void CapNhat_CapNhatGiaMon()
        {
            float excepted = 17;
            fDSMon.CapNhat(114, "", 17, "");
            float actual = fDSMon.DsMon[3].GiaBan;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void CapNhat_CapNhatGhiChuMon()
        {
            string excepted = "Đá/Nóng";
            fDSMon.CapNhat(114, "", 0, "Đá/Nóng");
            string actual = fDSMon.DsMon[3].GhiChu;

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void DsMonYeuCau_TimDungMaMon()
        {
            DSMon dsTemp = fDSMon.DsMonYeuCau(114.ToString());
            bool excepted = true;
            bool actual = false;
            foreach(Mon m in dsTemp.DsMon)
                if (m.MaMon == 114)
                {
                    actual = true;
                    break;
                }

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void DsMonYeuCau_TimDungTenMon()
        {
            DSMon dsTemp = fDSMon.DsMonYeuCau("CAFE Sữa");
            bool excepted = true;
            bool actual = false;
            foreach (Mon m in dsTemp.DsMon)
                if (m.TenMon == "Cafe sữa")
                {
                    actual = true;
                    break;
                }

            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void DsMonYeuCau_TimDungTheoGiaBan()
        {
            DSMon dsTemp = fDSMon.DsMonYeuCau("20");
            bool excepted = true;
            bool actual = false;
            foreach (Mon m in dsTemp.DsMon)
            {
                if (m.GiaBan != 20)
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
