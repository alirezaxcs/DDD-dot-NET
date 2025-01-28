using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Wps.Clinic.Domain;
using Wps.Clinic.Domain.ValueObject;

namespace Wps.Clinic.API.Infrustructure
{
    public class ClinicDbContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<ConsultationEventData> Consultations { get; set; }


        #region DbSets


        //public DbSet<Consultant> Consultations { get; set; }
        //public DbSet<VitalSigns> VitalSigns { get; set; }
        //public DbSet<DrugAdministration> DrugAdministrations { get; set; }

        #endregion
        #region OnModelCreating
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<Consultant>(consultation =>
        //    {
        //        consultation.HasKey(x => x.Id);

        //        consultation.Property(p => p.PatientId)
        //            .HasConversion(v => v.Value, v => new PatientId(v));

        //        consultation.OwnsOne(p => p.Diagnosis);
        //        consultation.OwnsOne(p => p.Treatment);
        //        consultation.OwnsOne(p => p.CurrentWeight);
        //        consultation.OwnsOne(p => p.When);

        //        consultation.OwnsMany(c => c.AdministeredDrugs, a =>
        //        {
        //            a.WithOwner().HasForeignKey(p => p.ConsultantId);
        //            a.OwnsOne(b=>b.DrugId);
        //            a.OwnsOne(b => b.Dose);



        //        });


        //        consultation.OwnsMany(c => c.VitalSignsReading, a =>
        //        {
        //            a.WithOwner().HasForeignKey(p => p.ConsultantId);
        //         });


        //    });
        //}
        #endregion
    }
    public static class ClinicDbcontextExtention
    {
        public static void EnsureDatabaseCreated(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var dbc = scope.ServiceProvider.GetService<ClinicDbContext>();
            dbc.Database.EnsureCreated();
            dbc.Database.CloseConnection();
        }
    }
    public record ConsultationEventData(
    Guid Id,
    string AggregateId,
    string EventName,
    string Data,
    string AssemblyQualifiedName);
}
