using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace SieuThi.Models
{
    public partial class Product
    {
        public Product() 
        {
            Storeds = new HashSet<Stored>();
            SalesManagements= new HashSet<SalesManagement>();
        }
        [Key]
        [Display(Name="Mã sản phẩm")]
        public int Masp { get; set; }
        [Required]
        [Display(Name = "Tên sản phẩm")]
        public string Tensp { get; set; }
        [Display(Name = "Đơn vị")]
        public string Donvi { get; set; }
        [Display(Name = "Giá Bán")]
        public int? GiaBan { get; set; }
        [Display(Name = "Mô tả")]
        public string Mota { get; set; }
        [Display(Name = "Nhập hàng")]


        public virtual ICollection<Stored> Storeds { get; set; }
        [Display(Name = "Hóa đơn")]
        public virtual ICollection<SalesManagement> SalesManagements { get; set; }
    }
}
