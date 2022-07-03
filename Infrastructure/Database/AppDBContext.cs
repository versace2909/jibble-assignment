using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = base.ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Property(nameof(BaseModel.UpdatedAt)).CurrentValue = DateTime.UtcNow;
                        entry.Property(nameof(BaseModel.UpdatedBy)).CurrentValue = "ADMIN";
                        break;
                    case EntityState.Added:
                        entry.Property(nameof(BaseModel.CreatedAt)).CurrentValue = DateTime.UtcNow;
                        entry.Property(nameof(BaseModel.CreatedBy)).CurrentValue = "ADMIN";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}