using DeviceWebAPI.Application.Mapping;
using DeviceWebAPI.Application.Repositories.DeviceRepository;
using DeviceWebAPI.Contracts.Requests;
using DeviceWebAPI.Contracts.Response;
using DeviceWebAPI.Shared.Model;
using Microsoft.Extensions.Logging;

namespace DeviceWebAPI.Application.Services.DeviceService
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILogger<DeviceService> _logger;

        // Constructor to initialize the service with a DeviceRepository
        public DeviceService(IDeviceRepository deviceRepository, ILogger<DeviceService> logger)
        {
            _deviceRepository = deviceRepository;
            _logger = logger;
        }

        // Add a new device based on the provided DeviceCreateRequestDTO
        public Guid AddDevice(DeviceCreateRequestDTO deviceCreateRequest)
        {
            try
            {
                var device = deviceCreateRequest.MapToDevice();
                _deviceRepository.AddDevice(device);
                return device.Id;
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unexpected error occurred while adding a new device.");
                // Optionally, rethrow the exception if you want it to propagate further
                throw;
            }
        }

        // Delete an existing device by its unique identifier
        public bool DeleteDevice(Guid id)
        {
            try
            {
                var device = _deviceRepository.GetDeviceById(id);
                if (device is null)
                {
                    return false;
                }
                _deviceRepository.DeleteDevice(device);
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, $"An unexpected error occurred while deleting the device with ID: {id}");
                // Optionally, rethrow the exception if you want it to propagate further
                throw;
            }
        }

        // Get a list of all devices and map them to DeviceResponseDTO
        public IEnumerable<DeviceResponseDTO> GetAllDevices()
        {
            try
            {
                var devices = _deviceRepository.GetAllDevices();
                return devices.Select(x => x.MapToDeviceResponseDTO());
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, "An unexpected error occurred while retrieving all devices.");
                // Optionally, rethrow the exception if you want it to propagate further
                throw;
            }
        }

        // Get a device by its unique identifier and
        // map it to DeviceResponseDTO
        public DeviceResponseDTO? GetDeviceById(Guid id)
        {
            try
            {
                var device = _deviceRepository.GetDeviceById(id);
                if (device is null)
                {
                    return null;
                }
                return device.MapToDeviceResponseDTO();
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, $"An unexpected error occurred while retrieving the device with ID: {id}");
                // Optionally, rethrow the exception if you want it to propagate further
                throw;
            }
        }

        // Update an existing device based on the provided DeviceUpdateRequestDTO
        public bool UpdateDevice(Guid id, DeviceUpdateRequestDTO updatedDeviceRequest)
        {

            try
            {
                //checking if any device exist.
                var existingDevice = _deviceRepository.GetDeviceById(id);

                if (existingDevice == null)
                {
                    return false;
                }

                // Update fields based on DeviceUpdateRequestDTO
                var device = updatedDeviceRequest.MapToDevice(id);
                //updating device
                _deviceRepository.UpdateDevice(device);

                return true;
            }
            catch (Exception ex)
            {
                // Log the exception
                _logger.LogError(ex, $"An unexpected error occurred while updating the device with ID: {id}");
                // Optionally, rethrow the exception if you want it to propagate further
                throw;
            }
        }

    }
}
