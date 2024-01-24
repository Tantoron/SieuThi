using System;
using System.ComponentModel.DataAnnotations;

namespace SieuThi.Models
{
    public class SalesManagement
    {
        [Key]
        [Display(Name = "Mã hóa đơn")]
        public int Mahoadon { get; set; }
        [Required]
        [Display(Name = "Ngày in hóa đơn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngay { get; set; }

        [Display(Name = "Mã nhân viên")]
        public virtual Staff Manv_FK { get; set; }

        [Display(Name = "Trị giá")]
        public int? TriGia { get; set; }
        [Display(Name = "Mã sản phẩm")]

        public virtual Product Masp_FK { get; set; }
        [Display(Name = "Tên sản phẩm")]

        public string Tensp { get; set; }
        [Display(Name = "Số lượng")]
        public string SoLuong { get; set; }

        
    }
}
