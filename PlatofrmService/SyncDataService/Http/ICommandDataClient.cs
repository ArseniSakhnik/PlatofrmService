using System.Threading.Tasks;
using PlatofrmService.Dtos;

namespace PlatofrmService.SyncDataService.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto plat);
    }
}