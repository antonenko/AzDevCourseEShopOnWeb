using Microsoft.eShopWeb.ApplicationCore.Entities;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class DeliveryOrderService: IDeliveryOrderService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly DeliveryOrderSettings _deliveryOrderSettings;


        public DeliveryOrderService(
            IHttpClientFactory httpClientFactory,
            IOptions<DeliveryOrderSettings> options)
        {
            _httpClientFactory = httpClientFactory;
            _deliveryOrderSettings = options.Value;
        }

        public async Task Send(DeliveryOrderDetails order)
        {
            var json = JsonConvert.SerializeObject(order);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            
            var url = _deliveryOrderSettings.Uri;

            await client.PostAsync(url, data);
        }
    }
}
