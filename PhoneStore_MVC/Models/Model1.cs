namespace PhoneStore_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<tAnh> tAnhs { get; set; }
        public virtual DbSet<tChiTietHDB> tChiTietHDBs { get; set; }
        public virtual DbSet<tChiTietHDN> tChiTietHDNs { get; set; }
        public virtual DbSet<tDanhGia> tDanhGias { get; set; }
        public virtual DbSet<tDienThoai> tDienThoais { get; set; }
        public virtual DbSet<tHoaDonBan> tHoaDonBans { get; set; }
        public virtual DbSet<tHoaDonNhap> tHoaDonNhaps { get; set; }
        public virtual DbSet<tKhachHang> tKhachHangs { get; set; }
        public virtual DbSet<tMaKhuyenMai> tMaKhuyenMais { get; set; }
        public virtual DbSet<tNhanVien> tNhanViens { get; set; }
        public virtual DbSet<tNhaSanXuat> tNhaSanXuats { get; set; }
        public virtual DbSet<tSoLuong> tSoLuongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tChiTietHDB>()
                .Property(e => e.DonGiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tChiTietHDN>()
                .Property(e => e.DonGiaNhap)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tDienThoai>()
                .HasMany(e => e.tAnhs)
                .WithRequired(e => e.tDienThoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tDienThoai>()
                .HasMany(e => e.tChiTietHDBs)
                .WithRequired(e => e.tDienThoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tDienThoai>()
                .HasMany(e => e.tChiTietHDNs)
                .WithRequired(e => e.tDienThoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tDienThoai>()
                .HasMany(e => e.tDanhGias)
                .WithRequired(e => e.tDienThoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tDienThoai>()
                .HasMany(e => e.tSoLuongs)
                .WithRequired(e => e.tDienThoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tHoaDonBan>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tHoaDonBan>()
                .HasMany(e => e.tChiTietHDBs)
                .WithRequired(e => e.tHoaDonBan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tHoaDonNhap>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<tHoaDonNhap>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tHoaDonNhap>()
                .HasMany(e => e.tChiTietHDNs)
                .WithRequired(e => e.tHoaDonNhap)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tKhachHang>()
                .HasMany(e => e.tDanhGias)
                .WithRequired(e => e.tKhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tKhachHang>()
                .HasMany(e => e.tHoaDonBans)
                .WithRequired(e => e.tKhachHang)
                .HasForeignKey(e => e.EmailKH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tNhanVien>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<tNhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<tNhanVien>()
                .HasMany(e => e.tHoaDonNhaps)
                .WithRequired(e => e.tNhanVien)
                .HasForeignKey(e => e.MaNV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tNhaSanXuat>()
                .HasMany(e => e.tDienThoais)
                .WithRequired(e => e.tNhaSanXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tNhaSanXuat>()
                .HasMany(e => e.tHoaDonNhaps)
                .WithRequired(e => e.tNhaSanXuat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tSoLuong>()
                .Property(e => e.DonGiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tSoLuong>()
                .Property(e => e.DonGiaNhap)
                .HasPrecision(19, 4);
        }
    }
}
