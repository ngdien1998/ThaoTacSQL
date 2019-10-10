using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ThaoTacSQL.Models.DataModels;

namespace ThaoTacSQL.Models.ViewModels
{
    public class DonHangViewModel : DonHang
    {
        public string TenKhachHang { get; set; }
    }
}