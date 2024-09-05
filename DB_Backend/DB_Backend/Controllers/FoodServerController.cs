using DB_Backend.DB_BackendBLL;
using Microsoft.AspNetCore.Mvc;

namespace DB_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
        // GET api/food
        public class FoodServerController : Controller
        {
            // GET api/stations
            [HttpGet]
            public IActionResult GetFoodNames()
            {
                var names = FoodManager.GetFoodNames();
                return Ok(names);
            }
        }
}
