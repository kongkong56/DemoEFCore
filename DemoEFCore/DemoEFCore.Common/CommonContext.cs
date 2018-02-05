using DemoEFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoEFCore.Repository
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class CommonContext : DbContext
    {
        public CommonContext(DbContextOptions<CommonContext> options)
           : base(options)
        { }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<VehicleSeries> VehicleSeries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasOne(d => d.VehicleSeries)
                .WithMany(p => p.Vehicles)
                .HasForeignKey(d => d.SeriesId)
                .HasConstraintName("FK_Vehicle_VehicleSeries");
        }
    }
}
