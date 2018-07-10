using System.Threading.Tasks;

namespace PGLaw.Domain.Core.Interfaces.DomainServices
{
    public interface IDomainServicesFull<T> : IDomainServicesReadAll<T>, IDomainServiceWrite<T>
    {
    }
}
