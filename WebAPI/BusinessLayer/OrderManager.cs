using DataAccessLayer.UnitOfWork;
using EntityLayer.OrderDto;
using System;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _iUnitOfWork;
        //private readonly IConfiguration _iConfiguration;

        public OrderManager(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
            //_iConfiguration = iConfiguration;
        }

        public async Task<OrderDto> SaveOrder(OrderDto orderDto)
        {
            try
            {
                await _iUnitOfWork.OrderRepository.SaveOrder(orderDto);
                await _iUnitOfWork.Commit();
                return null;
            }
            catch (Exception ex)
            {
                _iUnitOfWork.Rollback();
                return null;
            }


        }
    }
}
