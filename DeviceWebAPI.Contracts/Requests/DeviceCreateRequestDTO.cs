using DeviceWebAPI.Shared.Model;
using System.ComponentModel.DataAnnotations;

namespace DeviceWebAPI.Contracts.Requests
{
    public class DeviceCreateRequestDTO
    {
        [Required, Display(Name = "Device Type")]
        public DeviceType DeviceType { get; set; }
        [Required(ErrorMessage = "Device Brand is required")]
        public string Brand { get; set; } = string.Empty;
        [Required(ErrorMessage = "Device Model is required")]
        public string Model { get; set; } = string.Empty;
        [Required(ErrorMessage = "YearOfManufacture is required"),]
        public int YearOfManufacture { get; set; }
        [Required(ErrorMessage = "OperatingSystem is required")]
        public string OperatingSystem { get; set; } = string.Empty;
    }
}
