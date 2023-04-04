using Microsoft.EntityFrameworkCore;


namespace Poliza.Models
{
    public class PolicyContextEntity: DbContext
    {
        public PolicyContextEntity(DbContextOptions<PolicyContextEntity> options)
            : base(options)
        {
        }

        public DbSet<PolicyEntity> PoliciesItems { get; set; } = null!;
        public DbSet<UserEntity> UsersItems { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PolicyEntity>()
                .ToTable("InsurancePolicy")
                .HasKey(p => p.ID);

            modelBuilder.Entity<UserEntity>()
              .ToTable("Users")
              .HasKey(p => p.Id);
        }

    }
}
