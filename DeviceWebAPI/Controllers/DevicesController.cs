using DeviceWebAPI.Application.Services.DeviceService;
using DeviceWebAPI.Contracts.Requests;
using DeviceWebAPI.Contracts.Response;
using Microsoft.AspNetCore.Mvc;

namespace DeviceWebAPI.Controllers
{
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceService _deviceService;
        private readonly ILogger<DevicesController> _logger;

        // Constructor to inject the DeviceService via dependency injection
        public DevicesController(IDeviceService deviceService, ILogger<DevicesController> logger)
        {
            _deviceService = deviceService;
            _logger = logger;
        }

        // GET api/devices
        [HttpGet(ApiEndpoints.Devices.GetAll)]
        public ActionResult<IEnumerable<DeviceResponseDTO>> GetAll()
        {
            try
            {
                // Attempt to retrieve a list of all devices
                var devices = _deviceService.GetAllDevices();
                return Ok(devices);
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error response
                _logger.LogError(ex, "An unexpected error occurred while retrieving devices.");
                return StatusCode(500, "An unexpected error occurred while retrieving devices.");
            }
        }

        // GET api/devices/{id}
        [HttpGet(ApiEndpoints.Devices.Get)]
        public ActionResult<DeviceResponseDTO> Get(Guid id)
        {
            try
            {
                // Attempt to retrieve a device by its unique identifier
                var device = _deviceService.GetDeviceById(id);

                // Check if the device was not found
                if (device == null)
                {
                    return NotFound();
                }

                return Ok(device);
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error response
                _logger.LogError(ex, "An unexpected error occurred while retrieving devices.");
                return StatusCode(500, "An unexpected error occurred while retrieving the device.");
            }
        }

        // POST api/devices
        [HttpPost(ApiEndpoints.Devices.Create)]
        public ActionResult<Guid> Create([FromBody] DeviceCreateRequestDTO deviceCreateRequest)
        {
            try
            {
                // Attempt to add a new device based on the provided data
                var deviceId = _deviceService.AddDevice(deviceCreateRequest);

                // Return a 201 Created status with the ID of the newly created device
                return CreatedAtAction(nameof(Get), new { id = deviceId }, deviceId);
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error response
                _logger.LogError(ex, "An unexpected error occurred while retrieving devices.");
                return StatusCode(500, "An unexpected error occurred while adding a new device.");
            }
        }

        // PUT api/devices/{id}
        [HttpPut(ApiEndpoints.Devices.Update)]
        public IActionResult Update(Guid id, [FromBody] DeviceUpdateRequestDTO updatedDeviceRequest)
        {
            try
            {
                // Attempt to update an existing device based on the provided data
                var success = _deviceService.UpdateDevice(id, updatedDeviceRequest);

                // If the device was not found, return a 404 Not Found status
                if (!success)
                {
                    return NotFound();
                }

                // Return a 204 No Content status indicating a successful update
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error response
                _logger.LogError(ex, "An unexpected error occurred while retrieving devices.");
                return StatusCode(500, "An unexpected error occurred while updating the device.");
            }
        }

        // DELETE api/devices/{id}
        [HttpDelete(ApiEndpoints.Devices.Delete)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                // Attempt to delete an existing device by its unique identifier
                var success = _deviceService.DeleteDevice(id);

                // If the device was not found, return a 404 Not Found status
                if (!success)
                {
                    return NotFound();
                }

                // Return a 204 No Content status indicating a successful deletion
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception and return a generic error response
                _logger.LogError(ex, "An unexpected error occurred while retrieving devices.");
                return StatusCode(500, "An unexpected error occurred while deleting the device.");
            }
        }
    }
}
