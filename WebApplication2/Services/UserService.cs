using System.Threading.Tasks;
using WebApplication2.Data;
using System.Linq;
using System;

namespace WebApplication2.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<Customer> customerRepository;

        public UserService(IRepository<Customer> customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<Customer> GetCustomer(string username,string password)
        {
            if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException();
            }
            var result = this.customerRepository.GetAll();
            var customer = result.Where(s=>s.Username==username && s.Password==password).FirstOrDefault();

            return await Task.FromResult(customer);
        }
    }
}
