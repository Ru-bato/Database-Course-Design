using Microsoft.AspNetCore.Mvc;

using DB_Backend.DB_BackendBLL;
using DB_Backend.DB_BackendModel;
using System.Reflection;

namespace DB_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ScreenController : Controller
    {
        // POST api/screen/departure
        [HttpPost("departure")]
        public IActionResult SearchTrainsByDepatureStation([FromBody] QueryTrainModel model)
        {
            if (!string.IsNullOrEmpty(model.query))
            {
                var trains = ScreenManager.SearchTrainsByDepartureStation(model.query);
                return Ok(trains);
            }

            return Ok(null);
        }

        // POST api/screen/arrival
        [HttpPost("arrival")]
        public IActionResult SearchTrainsByArrivalStation([FromBody] QueryTrainModel model)
        {
            if (!string.IsNullOrEmpty(model.query))
            {
                var trains = ScreenManager.SearchTrainsByArrivalStation(model.query);
                return Ok(trains);
            }

            return Ok(null);
        }
    }
}
