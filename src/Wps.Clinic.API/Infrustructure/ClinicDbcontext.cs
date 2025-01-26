using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Wps.Clinic.Domain;
using Wps.Clinic.Domain.ValueObject;

namespace Wps.Clinic.API.Infrustructure
{
    public class ClinicDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Consultant> Consultations { get; set; }
        public DbSet<VitalSigns> VitalSigns { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Consultant>(consultation =>
            {
                consultation.HasKey(x => x.Id);

                consultation.Property(p => p.PatientId)
                    .HasConversion(v => v.Value, v => new PatientId(v));

                consultation.OwnsOne(p => p.Diagnosis);
                consultation.OwnsOne(p => p.Treatment);
                consultation.OwnsOne(p => p.CurrentWeight);
                consultation.HasMany(c => c.AdministeredDrugs)
                   .WithOne()
                   .HasForeignKey(m => m.Id);

                consultation.HasMany(c => c.VitalSignsReading)
                    .WithOne()
                    .HasForeignKey(m => m.ConsultantId);

            });
        }
    }
}
