using Wps.Management.Domain.Entities;
using Wps.SharedKernel;

namespace Wps.Management.Domain.Test;

public class UnitTest1
{
    [Fact]
    public void Pet_Equal()
    {
        var guid = Guid.NewGuid();
        var fakeBreedService = new FakeBreedService();
        var pet1 = new Pet(guid, "tracker",  12, "red", SexOfPet.Male, new BreedId(fakeBreedService.GetBreeds()[0].Id, fakeBreedService));
        var pet2 = new Pet(guid, "Sammy",  12, "red", SexOfPet.Male, new BreedId(fakeBreedService.GetBreeds()[0].Id, fakeBreedService));

        Assert.True(pet1 == pet2);
    }

    [Fact]
    public void Pet_Not_Equal()
    {
        var guid = Guid.NewGuid();
        var guid2 = Guid.NewGuid();

        var fakeBreedService = new FakeBreedService();
        var pet1 = new Pet(guid, "tracker",  12, "red", SexOfPet.Male, new BreedId(fakeBreedService.GetBreeds()[0].Id, fakeBreedService));
        var pet2 = new Pet(guid2, "Sammy",  12, "red", SexOfPet.Male, new BreedId(fakeBreedService.GetBreeds()[1].Id, fakeBreedService));

        Assert.True(pet1 != pet2);
    }
    [Fact]
    public void weight_equal()
    {
        var w1 = new Weight(1.2m);
        var w2 = new Weight(1.2m);
        Assert.True((w1 == w2));
    }
    [Fact]
    public void weight_Not_equal()
    {
        var w1 = new Weight(1.2m);
        var w2 = new Weight(3.1m);
        Assert.True((w1 != w2));
    }
    [Fact]
    public void weight_Range_equal()
    {
        var w1 = new WeightRage(3.1m, 1.2m);
        var w2 = new WeightRage(3.1m, 1.2m);
        Assert.True((w1 == w2));
    }
    [Fact]
    public void valid_BreedID()
    {

        var fakeBreedService = new FakeBreedService();

        var breedId = new BreedId(fakeBreedService.GetBreeds()[0].Id, fakeBreedService);

        Assert.NotNull(breedId);
    }
    [Fact]
    public void notValid_BreedID()
    {



        Assert.Throws<ArgumentException>(() =>
        {
            var fakeBreedService = new FakeBreedService();
            var breedId = new BreedId(Guid.NewGuid(), fakeBreedService);

        });

    }
    [Fact]
    public void breed_Not_equal()
    {
        var w1 = new Breed(Guid.NewGuid()
            , new WeightRage(1.2m, 3.5m), new WeightRage(2.2m, 4.5m),"triger");

        var w2= new Breed(Guid.NewGuid()
            , new WeightRage(1.2m, 3.5m), new WeightRage(2.2m, 4.5m), "triger");
        Assert.True((w1 != w2) &&
       !w1.Equals(w2));
    }
    [Fact]
    public void breed_Not_equal_null()
    {
        var w1 = new Breed(Guid.NewGuid()
            , new WeightRage(1.2m, 3.5m), new WeightRage(2.2m, 4.5m), "triger");

        Breed w2 = null;
        Assert.True((w1 != w2) &&
       !w1.Equals(w2));
    }
    [Fact]
    public void breed_equal()
    {
        var gid = Guid.NewGuid();
        var w1 = new Breed(gid
            , new WeightRage(1.2m, 3.5m), new WeightRage(2.2m, 4.5m), "triger");

        var w2 = new Breed(gid
            , new WeightRage(1.2m, 3.5m), new WeightRage(2.2m, 4.5m), "triger");
        Assert.True((w1 == w2)&&
        w1 .Equals( w2));

    }
    [Fact]
    public void overWeight()
    {
        var guid = Guid.NewGuid();
       

        var fakeBreedService = new FakeBreedService();
        var pet1 = new Pet(guid, "tracker", 12, "red", SexOfPet.Male, new BreedId(fakeBreedService.GetBreeds()[0].Id, fakeBreedService));
        pet1.SetWeight(new Weight(20m), fakeBreedService);

        Assert.True(pet1.WeightClass== WeightClass.Over);
    }
    [Fact]
    public void underWeight()
    {
        var guid = Guid.NewGuid();


        var fakeBreedService = new FakeBreedService();
        var pet1 = new Pet(guid, "tracker", 12, "red", SexOfPet.Male, new BreedId(fakeBreedService.GetBreeds()[0].Id, fakeBreedService));
        pet1.SetWeight(new Weight(0.2m), fakeBreedService);

        Assert.True(pet1.WeightClass == WeightClass.Under);
    }
    [Fact]
    public void IdealWeight()
    {
        var guid = Guid.NewGuid();


        var fakeBreedService = new FakeBreedService();
        var pet1 = new Pet(guid, "tracker", 12, "red", SexOfPet.Male, new BreedId(fakeBreedService.GetBreeds()[0].Id, fakeBreedService));
        pet1.SetWeight(3.2, fakeBreedService);//using Implicit Operator to pass direct decimal to Weight

        Assert.True(pet1.WeightClass == WeightClass.Ideal);
    }
}
