using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace assettag_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetTagController : ControllerBase
    {

        [HttpGet]
        public ActionResult<string> GetAssetTag(string serial)
        {
            var device = GetDeviceBySerial(serial);
            return device.AssetTag;
        }

        public Device GetDeviceBySerial(string serial)
        {
            var devicesJson = System.IO.File.ReadAllText("./data/devices.json");
            var devices = JsonSerializer.Deserialize<List<Device>>(devicesJson);
            return devices.FirstOrDefault(device => device.Serial == serial);
        }

    }
}
