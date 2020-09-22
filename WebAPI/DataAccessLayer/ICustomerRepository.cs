using EntityLayer.CustomerDto;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICustomerRepository
    {
        Task<bool> CustomerExists(string email);
        Task<CustomerProfileDto> GetProfileDetails(string email);
        Task<CustomerForLoginDto> Login(string email, string password);
        Task<CustomerForRegisterDto> RegisterCustomer(CustomerForRegisterDto customerForRegisterDto, string password);
    }
}
