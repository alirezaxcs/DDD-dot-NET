using Wps.Management.Domain;
using Wps.Management.Domain.Entities;

namespace Wps.Management.API.Infrastructor
{
    public class BreedService : IBreedService
    {
        public List<Breed> Breeds { get; set; } = new() { 
        new Breed(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa9"),new WeightRage(3m,7m),new WeightRage(2.5m,6m),"Pitbull"),
        new Breed(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa8"),new WeightRage(3m,7m),new WeightRage(2.5m,6m),"Trier")

        };
        public Breed? GetBreed(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentException();
            var breed = Breeds.Find(m => m.Id == guid);
            return breed ?? throw new AggregateException();

        }
    }
}
