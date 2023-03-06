using Commcare.Integration.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Commcare.Integration
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public virtual void EnsureSeeded()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AppDetail> AppDetails { get; set; }
        public DbSet<FormData> FormDatas { get; set; }
        public DbSet<FormDetail> FormDetails { get; set; }
        public DbSet<FormField> FormFields { get; set; }
    }
}
