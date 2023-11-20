using DeviceWebAPI.Shared.Model;

namespace DeviceWebAPI.Application.Repositories.DeviceRepository
{
    public interface IDeviceRepository
    {
        //NB": if this was interacting with a database.
        //I could have made the method to Task.,
        //But since am saving this to a list this will do.
        IEnumerable<Device> GetAllDevices();
        Device? GetDeviceById(Guid id);
        void AddDevice(Device device);
        void UpdateDevice(Device updatedDevice);
        void DeleteDevice(Device device);
    }
}
