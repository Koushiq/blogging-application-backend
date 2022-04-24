using System.Threading.Tasks;

namespace WebApplication2.Services
{
    public interface IUserService
    {
        Task<Customer> GetCustomer(string username, string password);
    }
}
