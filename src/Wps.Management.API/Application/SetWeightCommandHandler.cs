
using Microsoft.EntityFrameworkCore;
using Wps.Management.API.Infrastructor;
using Wps.Management.Domain;

namespace Wps.Management.API.Application
{
    public class SetWeightCommandHandler(ManagementDbcontext dbcontext,IBreedService breedService): ICommandHandler<SetWeightCommand>
    {
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await dbcontext.Pets.FindAsync(command.Id);
            pet.SetWeight(command.Weight, breedService);
            await dbcontext.SaveChangesAsync();
        }
    }
}
