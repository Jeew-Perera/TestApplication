﻿using EntityLayer.CustomerDto;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICustomerManager
    {
        Task<bool> RegisterCustomer(CustomerForRegisterDto customerForRegisterDto);
        Task<CustomerForLoginDto> Login(string email, string password);
        Task<CustomerProfileDto> GetProfileDetails(string email);
    }
}
