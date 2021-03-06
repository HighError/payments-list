using Microsoft.EntityFrameworkCore;
using PaymentsList.DataAccess.Interfaces;
using PaymentsList.Domain;
using System.Threading.Tasks;

namespace PaymentsList.DataAccess
{
    public class PaymentListDBContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public PaymentListDBContext(DbContextOptions<PaymentListDBContext> options) : base(options) {}

        public async Task CommitAsync()
        {
            await this.SaveChangesAsync(cancellationToken: default);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasMany(x => x.Groups)
                    .WithMany(u => u.User);
                b.HasIndex(x => x.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Group>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasMany(x => x.User)
                    .WithMany(u => u.Groups);
                b.HasIndex(x => x.Name)
                    .IsUnique();
            });
        }
    }
}
