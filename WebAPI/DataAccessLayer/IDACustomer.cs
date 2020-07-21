using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IDACustomer
    {
        public Task<Object> RegisterCustomer(Customer customer);
    }
}
