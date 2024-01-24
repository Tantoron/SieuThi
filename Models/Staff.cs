using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SieuThi.Models
{
    public class Staff
    {
        public Staff() 
        {
            SalesReports = new HashSet<SalesReport>();
            SalesManagements = new HashSet<SalesManagement>();
        }
        [Key]
        [Display(Name = "Mã nhân viên")]
        public int Manv { get; set; }
        [Required]
        [Display(Name = "Tên nhân viên")]
        public string Tennv { get; set; }
        [Display(Name = "Lương")]
        public int? Luong { get; set; }
        [Display(Name = "Ca")]
        public string Ca { get; set; }
        [Display(Name = "Mô tả công việc")]
        public string MotaCV { get; set; }
        [Display(Name = "Doanh thu")]
        public virtual ICollection<SalesReport> SalesReports { get; set; }
        [Display(Name = "Hóa đơn")]
        public virtual ICollection<SalesManagement> SalesManagements { get; set; }

    }
}
