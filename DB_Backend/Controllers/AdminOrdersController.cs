using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendModel;

namespace DB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminOrdersController : ControllerBase
    {
        private readonly MyTicketDbContext _dbContext;
        public static string conStr = AccommodateServer.conStr;
        public AdminOrdersController(MyTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetAllOrders")]
        public IActionResult Get()
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                try
                {
                    //var ruleCodes = string.IsNullOrEmpty(cust) ? _dbContext.ORDERLIST
                    //    .ToList() : _dbContext.ORDERLIST.Where(code => code.User_id == cust)
                    //    .ToList();
                    var ruleCodes = from train in _dbContext.TRAIN


                                    select new
                                    {
                                        TrainId = train.Train_id,
                                        DepartureStation = train.Departure_station,
                                        ArrivalStation = train.Arrival_station,
                                        DepartureTime = train.Departure_time,
                                        ArriveTime = train.Arrival_time,
                                        Price= train.Price,
                                        Remaining_tickets = train.Remaining_tickets,
                                    };

                    return Ok(ruleCodes);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpGet("GetOneTrain")]
        public IActionResult GetOne(string t_id)
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                try
                {
                    //var ruleCodes = string.IsNullOrEmpty(cust) ? _dbContext.ORDERLIST
                    //    .ToList() : _dbContext.ORDERLIST.Where(code => code.User_id == cust)
                    //    .ToList();
                    var ruleCodes = from train in _dbContext.TRAIN
                                    where train.Train_id == t_id

                                    select new
                                    {
                                        TrainId = train.Train_id,
                                        DepartureStation = train.Departure_station,
                                        ArrivalStation = train.Arrival_station,
                                        DepartureTime = train.Departure_time,
                                        ArriveTime = train.Arrival_time,
                                        Price = train.Price,
                                        Remaining_tickets = train.Remaining_tickets,
                                    };

                    return Ok(ruleCodes);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpPost("AddTrain")]
        public IActionResult Add(string t_id, string d_station, string a_station, string d_time, string a_time, string price, string remain_tickets)
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                var train = new Train
                {
                    Train_id = t_id,
                    Departure_station = d_station,
                    Arrival_station = a_station,
                    Departure_time = d_time,
                    Arrival_time = a_time,
                    Price= price,
                    Remaining_tickets = remain_tickets,
                };
                try
                {
                    _dbContext.TRAIN.Add(train);
                    _dbContext.SaveChanges();
                    return Ok(train);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

        }

        [HttpPut("updateTrain")]
        public IActionResult Upadta(string t_id, string d_station, string a_station, string d_time, string a_time, string price, string remain_tickets)
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                if (t_id == null)
                {
                    return BadRequest("Invalid order data.");
                }
                try
                {
                    var train = _dbContext.TRAIN.FirstOrDefault(t => t.Train_id == t_id);

                    // Check if the record exists
                    if (train == null)
                    {
                        return NotFound(new { message = $"Train with ID {t_id} not found." });
                    }
                    train.Departure_station = d_station;
                    train.Arrival_time = a_time;
                    train.Departure_time = d_time;
                    train.Arrival_station = a_station;
                    train.Price = price;
                    train.Remaining_tickets = remain_tickets;
                    _dbContext.SaveChanges();
                    return Ok(train);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpDelete("deleteTrain")]
        public IActionResult Delete(string t_id)
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                if (t_id == null)
                {
                    return BadRequest("Invalid order data.");
                }
                try
                {
                    var train = _dbContext.TRAIN.FirstOrDefault(t => t.Train_id == t_id);

                    // Check if the record exists
                    if (train == null)
                    {
                        return NotFound(new { message = $"Train with ID {t_id} not found." });
                    }

                    // Remove the record
                    _dbContext.TRAIN.Remove(train);

                    // Save changes to the database
                    _dbContext.SaveChanges();
                    return Ok(train);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
