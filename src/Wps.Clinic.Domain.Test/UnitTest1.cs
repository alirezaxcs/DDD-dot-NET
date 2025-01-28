using Wps.Clinic.Domain.ValueObject;

namespace Wps.Clinic.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void status_is_open()
        {
            var cons = new Consultation(Guid.NewGuid());
            Assert.True(cons.ConsultationStatus == ConsultationStatus.Open);
        }
        [Fact]
        public void consultation_null_end()
        {
            var cons = new Consultation(Guid.NewGuid());

            Assert.True(cons.When.End == null);
        }
        [Fact]
        public void consultation_cant_close_if_missingdata()
        {
            var cons = new Consultation(Guid.NewGuid());

            Assert.Throws<InvalidOperationException>(cons.End);
        }

        [Fact]
        public void consultation_close()
        {
            var cons = new Consultation(Guid.NewGuid());
            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.End();
            Assert.True(cons.ConsultationStatus == ConsultationStatus.Close);

        }
        [Fact]
        public void consultation_cant_change_if_close()
        {

            var cons = new Consultation(Guid.NewGuid());
            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.End();

            Assert.Throws<InvalidOperationException>(() => cons.SetWeight(12.2m));
        }
        [Fact]
        public void consultation_cant_change_if_close2()
        {

            var cons = new Consultation(Guid.NewGuid());
            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.End();

            Assert.Throws<InvalidOperationException>(() => cons.SetTreatmen("try"));
        }
        [Fact]
        public void consultation_cant_change_if_close3()
        {

            var cons = new Consultation(Guid.NewGuid());
            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.End();

            Assert.Throws<InvalidOperationException>(() => cons.SetDiagnosis("try"));

        }
        [Fact]
        public void consultation_administer_drug()
        {

            var cons = new Consultation(Guid.NewGuid());
            var drg = new DrugId(Guid.NewGuid());

            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.AdministerDrug(drg, new Dose(3.5m, UnitofMeasure.ml));


            Assert.True(cons.AdministeredDrugs.Count == 1 && cons.AdministeredDrugs.First().DrugId == drg);

        }
        [Fact]
        public void datetime_range_unvalid()
        {
            var dt = DateTime.UtcNow;



            Assert.Throws<InvalidOperationException>(() =>{
                var dr= new DateTimeRange(dt.AddMinutes(10), dt);
            });


        }
        [Fact]
        public void datetime_range_ongoing()
        {
            var dt = DateTime.UtcNow;



            
                var dr = new DateTimeRange(dt.AddMinutes(10));


            Assert.True(dr.Duration=="Ongoing");

        }
        [Fact]
        public void datetime_range_equal()
        {
            var dt = DateTime.UtcNow;




            var dr1 = new DateTimeRange(dt.AddMinutes(-10), dt);
            var dr2 = new DateTimeRange(dt.AddMinutes(-10), dt);


            Assert.True(dr1 == dr2);

        }
    }
}
