using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Wps.Management.API.Infrastructor
{
    public class ManagementDbcontext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<Pet> Pets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pet>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Pet>().Property(p => p.BreedId)
                .HasConversion(v => v.Value, v => BreedId.Create(v));

            modelBuilder.Entity<Pet>().OwnsOne(p => p.Weight);


        }

    }
    public static class ManagementDbcontextExtention
    {
        public static void EnsureDatabaseCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbc = scope.ServiceProvider.GetService<ManagementDbcontext>();
            dbc.Database.EnsureCreated();
            dbc.Database.CloseConnection();
        }
    }
}
