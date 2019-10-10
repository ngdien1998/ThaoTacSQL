using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThaoTacSQL.Models.BusinessModels;
using ThaoTacSQL.Models.DataModels;

namespace ThaoTacSQL.Controllers
{
    public class DonHangController : Controller
    {
        private readonly DonHangBusinessModel donHangBusinessModel = new DonHangBusinessModel();
        private readonly KhachHangBusinessModel khachHangBusinessModel = new KhachHangBusinessModel();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                var dsDonHang = donHangBusinessModel.LayTatCaDonHang();
                return View(dsDonHang);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult DonHangTheoNgay(DateTime? ngay)
        {
            if (ngay == null)
            {
                return View("Index");
            }

            ViewBag.Ngay = ngay;
            try
            {
                var dsDonHangTheoNgay = donHangBusinessModel.LayDonHangTheoNgay(ngay.Value);
                return View("Index", dsDonHangTheoNgay);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpGet]
        public ActionResult ThemDonHang()
        {
            try
            {
                var dsKhachHang = khachHangBusinessModel.LayTatCaKhachHang();
                ViewBag.DanhSachKhachHang = dsKhachHang;
                
                return View();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        [HttpPost]
        public ActionResult ThemDonHang(DonHang donHang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Thêm một số trường thiếu
                    donHang.MaDonHang = Guid.NewGuid().ToString();
                    donHang.ThoiGian = DateTime.Now;
                    donHang.TongTien = donHang.KhoiLuongGiat * donHang.GiaTien + donHang.TienThem;

                    donHangBusinessModel.ThemDonHang(donHang);
                    return RedirectToAction("Index");
                }

                var dsKhachHang = khachHangBusinessModel.LayTatCaKhachHang();
                ViewBag.DanhSachKhachHang = dsKhachHang;
                return View(donHang);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View("~/Views/Shared/Error.cshtml");
            }
        }
    }
}