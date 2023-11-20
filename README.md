Welcome to the documentation for DeviceWebAPI. This API provides endpoints for managing devices. 
It supports operations such as retrieving a list of devices, adding a new device, updating device information, and deleting a device.
This Project is a 60% skeleton ASP.NET Web API. It does the CRUD operation. and Its store the Information on the in-merory storage(C# List).

**Requirement for Running the Project**
- Visual Studio 2022
- dotNet 6.0

**The base URL for all API endpoints is:**
https://localhost:7284/api/devices

**Endpoints**
1. Get all devices

**Endpoint:**
GET /api/devices

**Description:**
Retrieve a list of all devices.

**Endpoint:**
GET /api/devices/{id}

**Description:**
Retrieve a specific device by its unique identifier.

**Endpoint:**
POST /api/devices

**Description:**
create a device 

**Endpoint:**
PUT /api/devices/{id}

**Description:**
Updating a device 

**Endpoint:**
DELETE /api/devices/{id}

**Description:**
Delete a device.

**NB: The application does not  cater for any form of persistence.**

