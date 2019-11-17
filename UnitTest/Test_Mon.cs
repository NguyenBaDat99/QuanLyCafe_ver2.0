using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _KTPM_QuanLyCafe.Mon;

namespace UnitTest
{
    [TestClass]
    public class Test_Mon
    {
        private _KTPM_QuanLyCafe.Mon.Mon fMon;

        [TestInitialize]
        public void SetUp()
        {
            fMon = new Mon();
        }

        [TestMethod]
        public void SoSanh_BangNhau()
        {
            Mon b1 = new Mon(111, "Cafe");
            Mon b2 = new Mon(111, "Bạc xỉu");
            int excepted = 0;
            int actual = b1.SoSanh(b2);
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void SoSanh_LonHon()
        {
            Mon b1 = new Mon(111, "Cafe");
            Mon b2 = new Mon(112, "Bạc xỉu");
            int excepted = 1;
            int actual = b2.SoSanh(b1);
            Assert.AreEqual(excepted, actual);
        }

        [TestMethod]
        public void SoSanh_Nhohon()
        {
            Mon b1 = new Mon(112, "Cafe");
            Mon b2 = new Mon(111, "Bạc xỉu");
            int excepted = -1;
            int actual = b2.SoSanh(b1);
            Assert.AreEqual(excepted, actual);
        }
    }
}
