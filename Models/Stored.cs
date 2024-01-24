using System.ComponentModel.DataAnnotations;

namespace SieuThi.Models
{
    public class Stored
    {
        [Key]
        [Display(Name = "Mã phiếu nhập")]
        public int MaPhieuNhap { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public virtual Product Masp_FK { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public string Tensp { get; set; }
        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }
        [Display(Name = "Giá nhập")]
        public int? GiaNhap { get; set; }
        

    }
}
