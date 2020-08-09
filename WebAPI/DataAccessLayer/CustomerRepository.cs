using AutoMapper;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Reflection.Metadata;
using EntityLayer.CustomerDto;

namespace DataAccessLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;

        public CustomerRepository(ShoppingCartContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public async Task<CustomerForRegisterDto> RegisterCustomer(CustomerForRegisterDto customer1, string cusPassword)
        {
            GenerateHashAndSalt(cusPassword, out byte[] hash, out byte[] salt);

            //Customer customer = _iMapper.Map<CustomerForRegisterDto, Customer>(customer1);

            var customer = new Customer
            {
                CustomerName = customer1.CustomerName,
                Email = customer1.Email,
                CustomerAddress = customer1.CustomerAddress
            ,
                Phone = customer1.Phone
            };

            customer.Password = hash;
            customer.Salt = salt;

            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer1;
        }
        private void GenerateHashAndSalt(string cusPassword, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(cusPassword));
            }
        }

        public async Task<bool> CustomerExists(string email)
        {
            if (await _context.Customer.AnyAsync(e => e.Email == email))
                return true;
            return false;
        }

        public async Task<CustomerForLoginDto> Login(string email, string cusPassword)
        {
            var user = await _context.Customer.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

            if (!ValidatePassword(cusPassword, user.Password, user.Salt))
                return null;

            return _iMapper.Map<CustomerForLoginDto>(user);
        }

        private bool ValidatePassword(string cusPassword, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(cusPassword));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<CustomerProfileDto> GetProfileDetails(string email)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Email == email);
            return _iMapper.Map<CustomerProfileDto>(customer);
        }
    }
}
