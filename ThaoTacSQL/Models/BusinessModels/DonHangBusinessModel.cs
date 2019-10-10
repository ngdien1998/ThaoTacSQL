using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ThaoTacSQL.Models.DataModels;
using ThaoTacSQL.Models.ViewModels;

namespace ThaoTacSQL.Models.BusinessModels
{
    public class DonHangBusinessModel : BaseBusinessModel
    {
        public bool ThemDonHang(DonHang donHang)
        {
            try
            {
                // Proc
                var query = "EXEC ThemDonHang @maDonHang, @thoiGian, @khoiLuongGiat, @maKhachHang, @giaoTanNoi, @diaChiGiaoHang, @giaTien, @tienThem, @tongTien, @daThanhToan";
                var type = CommandType.Text;
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@maDonHang", SqlDbType.VarChar, 50) { Value = donHang.MaDonHang },
                    new SqlParameter("@thoiGian", SqlDbType.DateTime) { Value = donHang.ThoiGian },
                    new SqlParameter("@khoiLuongGiat", SqlDbType.Float) { Value = donHang.KhoiLuongGiat },
                    new SqlParameter("@maKhachHang", SqlDbType.VarChar, 50) { Value = donHang.MaKhachHang },
                    new SqlParameter("@giaoTanNoi", SqlDbType.Bit) { Value = donHang.GiaoTanNoi },
                    new SqlParameter("@diaChiGiaoHang", SqlDbType.NVarChar, 500) { Value = donHang.DiaChiGiaoHang },
                    new SqlParameter("@giaTien", SqlDbType.Float) { Value = donHang.GiaTien },
                    new SqlParameter("@tienThem", SqlDbType.Float) { Value = donHang.TienThem },
                    new SqlParameter("@tongTien", SqlDbType.Float) { Value = donHang.TongTien },
                    new SqlParameter("@daThanhToan", SqlDbType.Bit) { Value = donHang.DaThanhToan }
                };

                var success = ExecuteNonQuery(query, type, parameters);
                return success > 0;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<DonHangViewModel> LayTatCaDonHang()
        {
            try
            {
                // View
                string query = "SELECT * FROM LayTatCaDonHang"; 
                var type = CommandType.Text;
                
                var dtbDonHang = ExecuteQuery(query, type); // Ko có parameter

                var dsDonHang = new List<DonHangViewModel>();
                foreach (DataRow row in dtbDonHang.Rows)
                {
                    var donHang = new DonHangViewModel
                    {
                        MaDonHang = (string)row["MaDonHang"],
                        ThoiGian = (DateTime)row["ThoiGian"],
                        KhoiLuongGiat = (double)row["KhoiLuongGiat"],
                        TenKhachHang = (string)row["TenKhachHang"],
                        GiaoTanNoi = (bool)row["GiaoTanNoi"],
                        DiaChiGiaoHang = (string)row["DiaChiGiaoHang"],
                        GiaTien = (double)row["GiaTien"],
                        TienThem = (double)row["TienThem"],
                        TongTien = (double)row["TongTien"],
                        DaThanhToan = (bool)row["ThanhToan"]
                    };
                    dsDonHang.Add(donHang);
                }

                return dsDonHang;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<DonHangViewModel> LayDonHangTheoNgay(DateTime ngay)
        {
            try
            {
                // Func
                string query = "SELECT * FROM dbo.LayDonHangTheoNgay(@ngay)";
                var type = CommandType.Text;
                var paramaters = new SqlParameter[]
                {
                    new SqlParameter("@ngay", SqlDbType.DateTime) { Value = ngay }
                };

                var dtbDonHang = ExecuteQuery(query, type, paramaters);

                var dsDonHang = new List<DonHangViewModel>();
                foreach (DataRow row in dtbDonHang.Rows)
                {
                    var donHang = new DonHangViewModel
                    {
                        MaDonHang = (string)row["MaDonHang"],
                        ThoiGian = (DateTime)row["ThoiGian"],
                        KhoiLuongGiat = (double)row["KhoiLuongGiat"],
                        TenKhachHang = (string)row["TenKhachHang"],
                        GiaoTanNoi = (bool)row["GiaoTanNoi"],
                        DiaChiGiaoHang = (string)row["DiaChiGiaoHang"],
                        GiaTien = (double)row["GiaTien"],
                        TienThem = (double)row["TienThem"],
                        TongTien = (double)row["TongTien"],
                        DaThanhToan = (bool)row["ThanhToan"]
                    };
                    dsDonHang.Add(donHang);
                }

                return dsDonHang;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}