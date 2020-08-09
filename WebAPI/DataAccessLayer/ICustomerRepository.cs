using DataAccessLayer.Models;
using EntityLayer.CustomerDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICustomerRepository
    {
        Task<bool> CustomerExists(string email);
        Task<CustomerProfileDto> GetProfileDetails(string email);
        Task<CustomerForLoginDto>  Login(string email, string password);
        Task<CustomerForRegisterDto> RegisterCustomer(CustomerForRegisterDto user, string password);
    }
}
