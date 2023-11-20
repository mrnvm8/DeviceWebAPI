using DeviceWebAPI.Shared.Model;

namespace DeviceWebAPI.Contracts.Response
{
    public class DeviceResponseDTO
    {
        public Guid Id { get; set; }
        public DeviceType DeviceType { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int YearOfManufacture { get; set; }
        public string? OperatingSystem { get; set; }
    }
}
