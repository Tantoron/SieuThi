using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SieuThi.Models;

namespace SieuThi.Repository
{
    public partial class MartContext : DbContext
    {
        public MartContext() { }
        public MartContext(DbContextOptions<MartContext> options) : base(options) 
        {
        }
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    if (!optionsBuilder.IsConfigured)
                    {
        #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                        optionsBuilder.UseSqlServer("Data Source=LAPTOP-OTNN1RB0\\TANTORON;Initial Catalog=SieuThi;User ID=SieuThi;Password=123;Trust Server Certificate=True");
                   }
                }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SalesManagement> SalesManagements { get; set; }
        public virtual DbSet<SalesReport> SalesReports { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Stored> Storeds { get; set; }
    }
}
