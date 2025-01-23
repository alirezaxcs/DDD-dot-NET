using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wps.Management.Domain.Entities;

namespace Wps.Management.Domain
{
    public interface IBreedService
    {
        Breed? GetBreed(Guid guid);
    }
    public class FakeBreedService : IBreedService
    {
        private readonly List<Breed> Breeds=
            new List<Breed>() {new Breed(Guid.NewGuid()
            ,new WeightRage(1.2m,3.5m),
            new WeightRage(2.2m,4.2m),"Duberman") ,
            new Breed(Guid.NewGuid()
            ,new WeightRage(1.2m,3.5m),
            new WeightRage(2.2m,4.2m),"Pitboll") };

        public Breed? GetBreed(Guid guid)
        {
            if (guid == Guid.Empty)
                throw new ArgumentException("BreedId Empty");
            return Breeds.Find(b => b.Id == guid) ?? throw new  ArgumentException("breed not found");
        }
        public List<Breed> GetBreeds() 
        {
            return Breeds.ToList();
        }
    }
}
