using EntityLayer.OrderDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IOrderRepository
    {
        Task<OrderDto> SaveOrder(OrderDto orderDto);
        Task<IEnumerable<GetOrderDto>> GetAllOrderDetails(int cusId);
        IEnumerable<GetOrderDto> GetLastOrderDetails(int cusId);

    }
}
