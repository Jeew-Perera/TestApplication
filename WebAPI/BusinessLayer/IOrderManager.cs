using EntityLayer.OrderDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IOrderManager
    {
        Task<OrderDto> SaveOrder(OrderDto orderDto);
        Task<IEnumerable<GetOrderDto>> GetAllOrderDetails(int cusId);
    }
}
