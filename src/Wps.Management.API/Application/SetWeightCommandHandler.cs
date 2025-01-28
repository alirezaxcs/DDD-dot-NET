
using Microsoft.EntityFrameworkCore;
using Wps.Management.API.Infrastructor;
using Wps.Management.Domain;
using Wps.Management.Domain.Events;

namespace Wps.Management.API.Application
{
    public class SetWeightCommandHandler: ICommandHandler<SetWeightCommand>
    {
        private IBreedService breedService;
        private ManagementDbcontext dbcontext;

        public SetWeightCommandHandler(ManagementDbcontext ddbcontext, IBreedService bbreedService)
        {
            dbcontext = ddbcontext;
            breedService = bbreedService;
            DomainEvents.PetWeightUpdated.Subscrie((petWeightUpdated) =>
            {
                //subscription
            });
        }
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await dbcontext.Pets.FindAsync(command.Id);
            pet.SetWeight(command.Weight, breedService);
            await dbcontext.SaveChangesAsync();
        }
    }
}
