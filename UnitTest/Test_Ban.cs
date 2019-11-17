using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _KTPM_QuanLyCafe;
using _KTPM_QuanLyCafe.Ban;

namespace UnitTest
{
    [TestClass]
    public class Test_Ban
    {
        private _KTPM_QuanLyCafe.Ban.Ban fBan;

        [TestInitialize]
        public void SetUp()
        {
            fBan = new Ban();
        }

        // Test Hàm SoSanh
        [TestMethod]
        public void Test_SoSanh_BangNhau()
        {
            Ban b1 = new Ban(111, 15);
            Ban b2 = new Ban(111, 16);
            int excepted = 0;
            int actual = b1.SoSanh(b2);
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Test_SoSanh_LonHon()
        {
            Ban b1 = new Ban(112, 15);
            Ban b2 = new Ban(111, 16);
            int excepted = 1;
            int actual = b1.SoSanh(b2);
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void Test_SoSanh_Nhohon()
        {
            Ban b1 = new Ban(111, 15);
            Ban b2 = new Ban(112, 16);
            int excepted = -1;
            int actual = b1.SoSanh(b2);
            Assert.AreEqual(excepted, actual);
        }

        // Test Hàm KiemTraSucChua

        [TestMethod]
        public void Test_KiemTraSucChua_Dung()
        {
            Assert.IsTrue(Ban.KiemTraSucChua(1));
        }

        [TestMethod]
        public void Test_KiemTraSucChua_Sai()
        {
            Assert.IsFalse(Ban.KiemTraSucChua(21));
        }
    }
}
