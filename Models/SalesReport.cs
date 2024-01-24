using System;
using System.ComponentModel.DataAnnotations;

namespace SieuThi.Models
{
    public class SalesReport
    {
        [Key]
        [Display(Name = "Mã báo cáo")]
        public int MaBaoCao { get; set; }
        [Required]
        [Display(Name = "Ngày")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Ngay {  get; set; }
        [Display(Name = "Doanh Thu")]
        public int? DoanhThu { get; set; }
        [Display(Name = "Mã nhân viên")]
        public virtual Staff Manv_FK { get; set; }
    }
}
