using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ThaoTacSQL.Models.DataModels;

namespace ThaoTacSQL.Models.BusinessModels
{
    public class KhachHangBusinessModel : BaseBusinessModel
    {
        public List<KhachHang> LayTatCaKhachHang()
        {
            try
            {
                // View
                string query = "SELECT * FROM LayTatCaKhachHang";
                var type = CommandType.Text;

                var dtbKhachHang = ExecuteQuery(query, type); // Ko có parameter
                var dsKhachHang = new List<KhachHang>();
                foreach (DataRow row in dtbKhachHang.Rows)
                {
                    var khachHang = new KhachHang
                    {
                        MaKhachHang = (string)row["MaKhachHang"],
                        TenKhachHang = (string)row["TenKhachHang"],
                        DienThoai = row["DienThoai"]?.ToString(),
                        DiaChi = row["DiaChi"]?.ToString()
                    };
                    dsKhachHang.Add(khachHang);
                }

                return dsKhachHang;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}