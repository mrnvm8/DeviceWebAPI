using DeviceWebAPI.Contracts.Requests;
using DeviceWebAPI.Contracts.Response;

namespace DeviceWebAPI.Application.Services.DeviceService
{
    public interface IDeviceService
    {
       IEnumerable<DeviceResponseDTO> GetAllDevices();
       DeviceResponseDTO? GetDeviceById(Guid id);
       Guid AddDevice(DeviceCreateRequestDTO deviceCreateRequest);
       bool UpdateDevice(Guid id, DeviceUpdateRequestDTO updatedDeviceRequest);
       bool DeleteDevice(Guid id);
    }
}
