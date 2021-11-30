using Microsoft.eShopWeb.ApplicationCore.Entities;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IDeliveryOrderService
    {
        Task Send(DeliveryOrderDetails order);
    }
}
