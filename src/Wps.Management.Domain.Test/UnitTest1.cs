namespace Wps.Management.Domain.Test;

public class UnitTest1
{
    [Fact]
    public void Pet_Equal()
    {
        var guid=Guid.NewGuid();
            var pet1=new Pet(guid,"alec",new Weight(1.2m));
            var pet2=new Pet(guid,"alec",new Weight(1.2m));
            Assert.True(pet1==pet2);
    }
    
    [Fact]
    public void Pet_Not_Equal()
    {
            var pet1=new Pet(Guid.NewGuid(),"alec",new Weight(1.2m));
            var pet2=new Pet(Guid.NewGuid(),"alec",new Weight(1.2m));
            Assert.True(!(pet1==pet2));
    }
        [Fact]
    public void weight_equal()
    {
            var w1=new Weight(1.2m);
            var w2=new Weight(1.2m);
            Assert.True((w1==w2));
    }
          [Fact]
    public void weight_Not_equal()
    {
            var w1=new Weight(1.2m);
            var w2=new Weight(3.1m);
            Assert.True((w1!=w2));
    }
}
