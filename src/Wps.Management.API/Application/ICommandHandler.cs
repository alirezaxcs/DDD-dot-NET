namespace Wps.Management.API.Application
{
    public interface ICommandHandler<T> where T : class
    {
         Task Handle(T Command);
    }
}
