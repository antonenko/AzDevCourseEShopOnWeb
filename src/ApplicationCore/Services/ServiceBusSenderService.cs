using Azure.Messaging.ServiceBus;
using Microsoft.eShopWeb.ApplicationCore.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Services
{
    public class ServiceBusSenderService : IServiceBusSenderService
    {
        private readonly ServiceBusSettings _serviceBusSettings;

        public ServiceBusSenderService(IOptions<ServiceBusSettings> serviceBusSettings)
        {
            _serviceBusSettings = serviceBusSettings.Value;
        }

        public async Task SendMessage(string message)
        {
            var client = new ServiceBusClient(_serviceBusSettings.ServiceBusConnectionString);
            var sender = client.CreateSender(_serviceBusSettings.TopicName);

            using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

            if (!messageBatch.TryAddMessage(new ServiceBusMessage(message)))
            {
                throw new Exception($"The message is too large to fit in the batch.");
            }

            try
            {
                await sender.SendMessagesAsync(messageBatch);
            }
            finally
            {
                await sender.DisposeAsync();
                await client.DisposeAsync();
            }
        }
    }
}