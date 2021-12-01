using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class OrderReserverService : IOrderReserverService
    {
        private readonly IServiceBusSenderService _serviceBusSenderService;

        public OrderReserverService(IServiceBusSenderService serviceBusSenderService)
        {
            _serviceBusSenderService = serviceBusSenderService;
        }

        public async Task Reserve(IEnumerable<ReservedOrderDetails> orders)
        {
            var json = JsonConvert.SerializeObject(orders);
            await _serviceBusSenderService.SendMessage(json);
        }      
    }
}
