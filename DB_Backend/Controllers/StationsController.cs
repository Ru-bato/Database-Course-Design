using DB_Backend.DB_BackendBLL;
using Microsoft.AspNetCore.Mvc;
using DB_Backend.DB_BackendModel;

namespace DB_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class StationsController : Controller
    {
        // GET api/stations
        [HttpGet]
        public IActionResult GetStationsNames()
        {
            var names = StationsManager.GetStationsNames();
            return Ok(names);
        }

        // POST api/stations
        [HttpPost]
        public IActionResult SearchStationByKW([FromBody] CitySearchModel model)
        {
            if (!string.IsNullOrEmpty(model.Query))
            {
                var names = StationsManager.SearchStationsByKW(model.Query);
                return Ok(names);
            }

            return Ok(null);
        }

    }
}
