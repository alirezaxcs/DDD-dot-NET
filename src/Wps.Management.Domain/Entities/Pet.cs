using Wps.Management.Domain;
using Wps.Management.Domain.ValueObjects;
using Wps.SharedKernel;

public class Pet : Entity<Guid>
{
    
    public string Name { get; init; }
    public int Age { get; set; }
    public string Color { get; set; }
    public Weight Weight { get; private set; }
    public WeightClass WeightClass { get; private set; }

    public SexOfPet SexOfPet { get; init; }
    public BreedId BreedId { get; init; }
    public Pet(Guid id,
        string name,
       
        int age,
        string color,
        SexOfPet sexOfPet,BreedId breedId) : base(id)
    {
        BreedId = breedId;
        Name = name;
       
        Age = age;
        Color = color;
        SexOfPet = sexOfPet;
    }
    public void SetWeight(Weight weight, IBreedService breedService)
    {
        Weight = weight;
        SetWeightClass(breedService);
    }

    private void SetWeightClass(IBreedService breedService)
    {
        var desiredBreed = breedService.GetBreed(BreedId.Value);
        var (from, to) = this.SexOfPet switch
        {
            SexOfPet.Male=>(desiredBreed.MaleIdealRange.From,desiredBreed.MaleIdealRange.To),
            SexOfPet.Female => (desiredBreed.FemaleIdealRange.From, desiredBreed.FemaleIdealRange.To),
            _=>throw new NotImplementedException()
        };
        WeightClass = Weight.Value switch
        {
            _ when Weight.Value <from => WeightClass.Under,
            _ when Weight.Value > to => WeightClass.Over,
            _ => WeightClass.Ideal

        };
    }
}
public enum SexOfPet
{
    Male,
    Female
}
public enum WeightClass
{
    Unkown,
    Ideal,
    Under,
    Over
}