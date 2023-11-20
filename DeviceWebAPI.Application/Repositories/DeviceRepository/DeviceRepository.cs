using DeviceWebAPI.Shared.Model;

namespace DeviceWebAPI.Application.Repositories.DeviceRepository
{
    public class DeviceRepository : IDeviceRepository
    {
        // In-memory storage for devices
        private static List<Device> _devices = new List<Device>();

        // Constructor responsible for initializing the list with sample data.
        public DeviceRepository()
        {
            // Add 5 sample records
            _devices.Add(new Device
            {
                Id = Guid.NewGuid(),
                DeviceType = DeviceType.Laptop,
                Brand = "ExampleBrand1",
                Model = "ExampleModel1",
                YearOfManufacture = 2020,
                OperatingSystem = "Windows 10"
            });

            _devices.Add(new Device
            {
                Id = Guid.NewGuid(),
                DeviceType = DeviceType.Smartphone,
                Brand = "ExampleBrand2",
                Model = "ExampleModel2",
                YearOfManufacture = 2021,
                OperatingSystem = "Android"
            });

            _devices.Add(new Device
            {
                Id = Guid.NewGuid(),
                DeviceType = DeviceType.Tablet,
                Brand = "ExampleBrand3",
                Model = "ExampleModel3",
                YearOfManufacture = 2019,
                OperatingSystem = "iOS"
            });

            _devices.Add(new Device
            {
                Id = Guid.NewGuid(),
                DeviceType = DeviceType.Desktop,
                Brand = "ExampleBrand4",
                Model = "ExampleModel4",
                YearOfManufacture = 2018,
                OperatingSystem = "Windows 10"
            });

            _devices.Add(new Device
            {
                Id = Guid.NewGuid(),
                DeviceType = DeviceType.Smartwatch,
                Brand = "ExampleBrand5",
                Model = "ExampleModel5",
                YearOfManufacture = 2022,
                OperatingSystem = "Proprietary"
            });
        }

        // Retrieve all devices
        public IEnumerable<Device> GetAllDevices() => _devices;

        // Retrieve a device by its unique identifier (Id)
        public Device? GetDeviceById(Guid id) => _devices.FirstOrDefault(d => d.Id == id);

        // Add a new device
        public void AddDevice(Device device)
        {
            // Assign a new GUID as the device ID
            device.Id = Guid.NewGuid();
            // Add the device to the in-memory storage
            _devices.Add(device);
        }

        // Update a device (if needed)
        public void UpdateDevice(Device updatedDevice)
        {
            //first check if the to be updated device exist.
            var existingDevice = _devices.FirstOrDefault(d => d.Id == updatedDevice.Id);
            //if it exist update it
            if (existingDevice != null)
            {
                // Update fields based on the updated device
                existingDevice.DeviceType = updatedDevice.DeviceType;
                existingDevice.Brand = updatedDevice.Brand;
                existingDevice.Model = updatedDevice.Model;
                existingDevice.YearOfManufacture = updatedDevice.YearOfManufacture;
                existingDevice.OperatingSystem = updatedDevice.OperatingSystem;
            }
            // Update logic (if needed)
        }

        // Delete a device
        public void DeleteDevice(Device device)
        {
            // Remove the device from the in-memory storage
            _devices.Remove(device);
        }
    }
}
