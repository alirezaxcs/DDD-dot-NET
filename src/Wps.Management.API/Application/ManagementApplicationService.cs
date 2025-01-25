using Wps.Management.API.Infrastructor;
using Wps.Management.Domain;

namespace Wps.Management.API.Application
{
    public class ManagementApplicationService(IBreedService breedService, ManagementDbcontext dbcontext)
    {

        public async Task Handle(CreatePetCommand command)
        {
            var breedId = new BreedId(command.BreedId,breedService);
            var newPet = new Pet(command.Id,
                 command.Name,
                 command.Age,
                 command.Color,
                 command.SexOfPet,
                 breedId);
           await dbcontext.Pets.AddAsync(newPet);
            await dbcontext.SaveChangesAsync();
        }
   
    }
}
