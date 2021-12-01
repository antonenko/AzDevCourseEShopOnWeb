using System.Threading.Tasks;

namespace Microsoft.eShopWeb.ApplicationCore.Interfaces
{
    public interface IServiceBusSenderService
    {
        Task SendMessage(string message);
    }
}
