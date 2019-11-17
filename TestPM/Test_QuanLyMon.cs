using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _KTPM_QuanLyCafe;

namespace Test_QuanLyCafe
{
    [TestClass]
    public class Test_QuanLyMon
    {
        private _KTPM_QuanLyCafe.QuanTri.QuanLyMon fQuanLyMon;

        [TestMethod]
        public void Test_TaoMoiVaLuuMon()
        {
            Assert.AreEqual(0, fQuanLyMon.TaoMoiVaLuuMon("Cafe",-1,"")); //@@
        }

        [TestMethod]
        public void Test_XoaMon()
        {
            Assert.AreEqual(0, fQuanLyMon.XoaMon(-1)); //@@
        }

        [TestMethod]
        public void Test_CapNhatVaLuuMon()
        {
            Assert.AreEqual(0, fQuanLyMon.CapNhatVaLuuMon("Cafe",-1,"",-1)); //@@
        }
    }
}
