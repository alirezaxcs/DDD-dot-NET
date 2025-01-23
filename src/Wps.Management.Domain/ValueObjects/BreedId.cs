using Wps.Management.Domain;

public record BreedId
{
    private readonly IBreedService breedService;

    public Guid Value { get; set; }
    public BreedId(Guid value, IBreedService breedService)
    {
        this.breedService = breedService;
        Validate(value);
        Value = value;

    }

    private void Validate(Guid value)
    {
        if (breedService == null)
            throw new ArgumentNullException("breed service is nul");
        if (breedService.GetBreed(value) == null)
            throw new InvalidOperationException("breed not valid");
    }
}