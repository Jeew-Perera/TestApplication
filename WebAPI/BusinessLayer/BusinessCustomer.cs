using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BusinessCustomer : IBusinessCustomer
    {
        private IDACustomer _iDACustomer;

        public BusinessCustomer(IDACustomer iDACustomer)
        {
            _iDACustomer = iDACustomer;
        }

        public Task<Object> RegisterCustomer(Customer customer)
        {
            return _iDACustomer.RegisterCustomer(customer);
        }
    }
}
