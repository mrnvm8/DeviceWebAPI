namespace DeviceWebAPI.Shared.Model
{
    public class Device
    {
        public Guid Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int YearOfManufacture { get; set; }
        public string OperatingSystem { get; set; } = string.Empty;
        public DeviceType DeviceType { get; set; }
    }
}