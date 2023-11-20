using DeviceWebAPI.Contracts.Requests;
using DeviceWebAPI.Contracts.Response;
using DeviceWebAPI.Shared.Model;

namespace DeviceWebAPI.Application.Mapping
{
    public static class DeviceContractMapping
    {
        public static Device MapToDevice(this DeviceCreateRequestDTO request)
        {
            return new Device
            {
                DeviceType = request.DeviceType,
                Brand = request.Brand,
                Model = request.Model,
                YearOfManufacture = request.YearOfManufacture,
                OperatingSystem = request.OperatingSystem
            };
        }

        public static DeviceResponseDTO MapToDeviceResponseDTO(this Device device)
        {
            return new DeviceResponseDTO 
            {
                Id = device.Id,
                DeviceType = device.DeviceType,
                Brand = device.Brand,
                Model = device.Model,
                YearOfManufacture = device.YearOfManufacture,
                OperatingSystem = device.OperatingSystem
            };
        }

        public static Device MapToDevice(this DeviceUpdateRequestDTO request, Guid Id)
        {
            return new Device
            {
                Id = Id,
                DeviceType = (DeviceType)request.DeviceType!,
                Brand = request.Brand,
                Model = request.Model,
                YearOfManufacture = (int)request.YearOfManufacture!,
                OperatingSystem = request.OperatingSystem
            };
        }
    }
}
