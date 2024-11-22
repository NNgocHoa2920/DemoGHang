using Microsoft.EntityFrameworkCore;

namespace DemoGHang.Models
{
    public class GHDbContex :DbContext
    {
        public GHDbContex()
        {
            
        }

        public GHDbContex(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<GHCT> GHCTs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NGUYEN_NGOC_HOA\\HOANN; Database=GH_TUTOR;Trusted_Connection= True;" +
"TrustServerCertificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CONFIG FULENT API CHO ACCOUNT
            modelBuilder.Entity<Account>().HasKey(x => x.AccId);
            modelBuilder.Entity<Account>().HasOne(x => x.GioHang).WithOne(x => x.Account)
                .HasForeignKey<GioHang>(x => x.AccountId);

            //config cho sanpham
            modelBuilder.Entity<SanPham>().HasKey(x => x.SanPhamId);
            ///config cho gh
            modelBuilder.Entity<GioHang>().HasKey(x => x.GioHangId);

            modelBuilder.Entity<GioHang>().HasOne(x => x.Account).WithOne(x => x.GioHang)
                .HasForeignKey<GioHang>(x => x.AccountId);
            //config ghct
            modelBuilder.Entity<GHCT>().HasKey(x => x.ID); ;
            modelBuilder.Entity<GHCT>().HasOne(x => x.GioHang).WithMany(x => x.GHCTs)
                .HasForeignKey(x => x.GioHangId);
            modelBuilder.Entity<GHCT>().HasOne(x => x.SanPham).WithMany(x => x.GHCTs)
                .HasForeignKey(x => x.SanPhamId);

        }
    }
}
