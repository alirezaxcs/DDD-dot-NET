using Wps.Management.Domain;

public class Pet : Entity<Guid>
{
    
    public string Name { get; init; }
    public Weight Weight { get; init; }
    public Pet(Guid id, string name, Weight weight) : base(id)
    {
        Name = name;
        Weight = weight;
    }
}
public record Weight
{
    public decimal Value { get; set; }
    public Weight(decimal value)
    {
        if(value<0)
            throw new ArgumentException("invalid weight!");
        
        Value=value; 
    }
}
public record PetInfo(string Name,string Color,Breed breed);

public class Breed : Entity<Guid>
{
    public Breed(Guid id) : base(id)
    {
    }
}