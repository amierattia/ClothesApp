using ClothesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothesApp.Db
{
    public class DBContext :DbContext
    {

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<MissingItem> MissingItems { get; set; }
        public DbSet<Return> Returns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sale>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserID);

            modelBuilder.Entity<Sale>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(s => s.ProductID);

            modelBuilder.Entity<Order>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(o => o.UserID);

            modelBuilder.Entity<Inventory>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(i => i.ProductID);

            modelBuilder.Entity<MissingItem>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(m => m.ProductID);

            modelBuilder.Entity<Return>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(r => r.UserID);

            modelBuilder.Entity<Return>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(r => r.ProductID);
        }
    }
}
