namespace Wps.Management.API.Application
{
    public record CreatePetCommand(Guid Id ,
        string Name,
        int Age,
        string Color,
        SexOfPet SexOfPet,
        Guid BreedId);
    
}
