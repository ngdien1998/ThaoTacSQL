using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThaoTacSQL.Models.DataModels
{
    /// <summary>
    /// Tương ứng bảng đơn hàng dưới database
    /// </summary>
    public class DonHang
    {
        public string MaDonHang { get; set; }
        public DateTime ThoiGian { get; set; }
        public string NguoiTao { get; set; }
        public double KhoiLuongGiat { get; set; }
        public string MaKhachHang { get; set; }
        public bool GiaoTanNoi { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public double GiaTien { get; set; }
        public double TienThem { get; set; }
        public double TongTien { get; set; }
        public bool DaThanhToan { get; set; }
    }
}