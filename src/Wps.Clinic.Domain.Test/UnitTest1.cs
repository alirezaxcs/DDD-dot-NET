using Wps.Clinic.Domain.ValueObject;

namespace Wps.Clinic.Domain.Test
{
    public class UnitTest1
    {
        [Fact]
        public void status_is_open()
        {
            var cons = new Consultant(Guid.NewGuid());
            Assert.True(cons.ConsultationStatus == ConsultationStatus.Open);
        }
        [Fact]
        public void consultation_null_end()
        {
            var cons = new Consultant(Guid.NewGuid());

            Assert.True(cons.EndAt == null);
        }
        [Fact]
        public void consultation_cant_close_if_missingdata()
        {
            var cons = new Consultant(Guid.NewGuid());

            Assert.Throws<InvalidOperationException>(cons.End);
        }

        [Fact]
        public void consultation_close()
        {
            var cons = new Consultant(Guid.NewGuid());
            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.End();
            Assert.True(cons.ConsultationStatus == ConsultationStatus.Close);

        }
        [Fact]
        public void consultation_cant_change_if_close()
        {

            var cons = new Consultant(Guid.NewGuid());
            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.End();

            Assert.Throws<InvalidOperationException>(() => cons.SetWeight(12.2m));
        }
        [Fact]
        public void consultation_cant_change_if_close2()
        {

            var cons = new Consultant(Guid.NewGuid());
            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.End();

            Assert.Throws<InvalidOperationException>(() => cons.SetTreatmen("try"));
        }
        [Fact]
        public void consultation_cant_change_if_close3()
        {

            var cons = new Consultant(Guid.NewGuid());
            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.End();

            Assert.Throws<InvalidOperationException>(() => cons.SetDiagnosis("try"));

        }
        [Fact]
        public void consultation_administer_drug()
        {

            var cons = new Consultant(Guid.NewGuid());
            var drg = new DrugId(Guid.NewGuid());

            cons.SetTreatmen("treat");
            cons.SetDiagnosis("diag");
            cons.SetWeight(12.2m);
            cons.AdministerDrug(drg, new Dose(3.5m, UnitofMeasure.ml));


            Assert.True(cons.AdministeredDrugs.Count == 1 && cons.AdministeredDrugs.First().DrugId == drg);

        }
    }
}
