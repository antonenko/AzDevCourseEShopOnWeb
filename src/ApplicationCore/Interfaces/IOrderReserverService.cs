using Microsoft.eShopWeb.ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IOrderReserverService
    {
        Task Reserve(IEnumerable<ReservedOrderDetails> orders);
    }
}
