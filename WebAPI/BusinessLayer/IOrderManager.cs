using EntityLayer.OrderDto;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IOrderManager
    {
        Task<OrderDto> SaveOrder(OrderDto orderDto);
    }
}
