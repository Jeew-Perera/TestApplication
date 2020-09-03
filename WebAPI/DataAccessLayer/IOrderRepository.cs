using EntityLayer.OrderDto;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface IOrderRepository
    {
        Task<OrderDto> SaveOrder(OrderDto orderDto);
    }
}
