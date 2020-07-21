using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IBusinessCustomer
    {
        Task<Object> RegisterCustomer(Customer customer);
    }
}
