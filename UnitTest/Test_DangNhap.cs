using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _KTPM_QuanLyCafe;
namespace Test_QuanLyCafe
{
    [TestClass]
    public class Test_DangNhap
    {
        private _KTPM_QuanLyCafe.DangNhap fDangNhap;

        [TestInitialize]
        public void SetUp()
        {
            fDangNhap = new DangNhap();
        }

        // Test Tài Khoản Thu Ngân

        [TestMethod]
        public void Test_ThuNgan1()
        {
            Assert.AreEqual("ThuNgan", fDangNhap.KiemTraTaiKhoan("thungan1", "thungan1"));
        }

        [TestMethod]
        public void Test_ThuNgan2()
        {
            Assert.AreEqual("Sai mat khau tai khoan Thu ngan", fDangNhap.KiemTraTaiKhoan("thungan1", "thungan"));
        }

        [TestMethod]
        public void Test_ThuNgan3()
        {
            Assert.AreEqual("Sai ten dang nhap", fDangNhap.KiemTraTaiKhoan("thungan", "thungan1"));
        }

        // Test Tài Khoản Quản Trị

        [TestMethod]
        public void Test_QuanTri1()
        {
            Assert.AreEqual("Admin", fDangNhap.KiemTraTaiKhoan("admin", "admin1"));
        }

        [TestMethod]
        public void Test_QuanTri2()
        {
            Assert.AreEqual("Sai mat khau tai khoan Admin", fDangNhap.KiemTraTaiKhoan("admin", "admin"));
        }

        [TestMethod]
        public void Test_QuanTri3()
        {
            Assert.AreEqual("Sai ten dang nhap", fDangNhap.KiemTraTaiKhoan("admin1", "admin1"));
        }
    }
}
