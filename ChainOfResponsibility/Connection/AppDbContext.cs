using ChainOfResponsibilty.Models;
using Microsoft.EntityFrameworkCore;


namespace ChainOfResponsibilty.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=ChainOfResponsibilityExample;integrated security=true;TrustServerCertificate=True;");//Database ilə əlaqə

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.Balance)
                      .HasColumnType("decimal(18,2)")
                      .IsRequired();
                entity.HasMany(e => e.Transactions).WithOne(e => e.BankAccount).HasForeignKey(x=>x.UserId);
            });
            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasOne(e => e.BankAccount).WithMany(e => e.Transactions).HasForeignKey(x => x.UserId);
            });



        }
    }
}
