using DeviceWebAPI.Shared.Model;
using System.ComponentModel.DataAnnotations;

namespace DeviceWebAPI.Contracts.Requests
{
    public class DeviceUpdateRequestDTO
    {
        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; } = string.Empty;
        [Required(ErrorMessage = "Model is required")]
        public string Model { get; set; } = string.Empty;
        [Required, Display(Name = "Device Type")]
        public DeviceType? DeviceType { get; set; }
        public int? YearOfManufacture { get; set; }
        public string OperatingSystem { get; set; } = string.Empty;
    }
}
