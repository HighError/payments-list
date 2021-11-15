using System.Threading.Tasks;

namespace PaymentsList.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
