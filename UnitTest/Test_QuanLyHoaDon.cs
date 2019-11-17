using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _KTPM_QuanLyCafe;

namespace Testing.UnitTests
{
    [TestClass]
    public class Test_QuanLyHoaDon
    {
        private _KTPM_QuanLyCafe.NhanVien.QuanLyHoaDon fQuanLyHD;
        
        [TestInitialize]
        public void SetUp()
        {
            string who = "admin";
            fQuanLyHD = new _KTPM_QuanLyCafe.NhanVien.QuanLyHoaDon(who);
        }

        // Test KiemTraTinhTrangBan
        [TestMethod]
        public void Test_KiemTraTinhTrangBan()
        {
            Assert.IsTrue(fQuanLyHD.KiemTraTinhTrangBan(112));
        }

        [TestMethod]
        public void Test_KiemTraTinhTrangBan1()
        {
            Assert.IsFalse(fQuanLyHD.KiemTraTinhTrangBan(111));
        }

        // Test TaoMoiVaLuuHoaDon 
        // Cho người dùng chọn
        //[TestMethod]
        //public void Test_TaoMoiVaLuuHoaDon()
        //{
        //    DateTime dt = DateTime.Now;
        //    Assert.AreEqual(1, fQuanLyHD.TaoMoiVaLuuHoaDon(dt, -200));
        //}

        // Test KiemTraHoaDonDaThanhToan
        [TestMethod]
        public void Test_KiemTraHoaDonDaThanhToan()
        {
            Assert.IsTrue(fQuanLyHD.KiemTraHoaDonDaThanhToan(1));
        }

        [TestMethod]
        public void Test_KiemTraHoaDonDaThanhToan1()
        {
            Assert.IsFalse(fQuanLyHD.KiemTraHoaDonDaThanhToan(53));
        }

        //// Test ChuyenBan
        // Cho người dùng chọn
        //[TestMethod]
        //public void Test_ChuyenBan()
        //{
        //    Assert.AreEqual(1, fQuanLyHD.ChuyenBan(122,2,121));
        //}

        // Test KiemTraMonDaTonTai
        [TestMethod]
        public void Test_KiemTraMonDaTonTai()
        {
            Assert.IsTrue(fQuanLyHD.KiemTraMonDaTonTai(2, 111));
        }

        [TestMethod]
        public void Test_KiemTraMonDaTonTai1()
        {
            Assert.IsFalse(fQuanLyHD.KiemTraMonDaTonTai(2, 121));
        }

        //// Test CapNhatTongTienHoaDon
        
        //[TestMethod]
        //public void Test_CapNhatTongTienHoaDon()
        //{
        //    Assert.AreEqual(1, fQuanLyHD.CapNhatTongTienHoaDon(2, 30));
        //}

        //[TestMethod]
        //public void Test_CapNhatTongTienHoaDon1()
        //{
        //    Assert.AreEqual(0, fQuanLyHD.CapNhatTongTienHoaDon(2, 30));
        //}
    }
}
