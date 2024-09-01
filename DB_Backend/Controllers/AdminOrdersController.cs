using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using DB_Backend.DB_BackendDAL;

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
                    var ruleCodes = from ticket in _dbContext.ORDERLIST
                                    join train in _dbContext.TRAIN
                                    on ticket.Train_id equals train.Train_id

                                    select new
                                    {
                                        OrderId = ticket.Order_id,
                                        UserId = ticket.User_id,
                                        TrainId = train.Train_id,
                                        PassengerId = ticket.Passenger_id,
                                        OrderStatus = ticket.Order_status,
                                        Price = ticket.Price,
                                        TicketType = ticket.Ticket_type,
                                        DepartureStation = train.Departure_station,
                                        ArrivalStation = train.Arrival_station,
                                        DepartureTime = train.Departure_time,
                                        ArriveTime = train.Arrival_time
                                    };

                    return Ok(ruleCodes);

                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

        }
        [HttpGet("AddOrder")]
        public IActionResult Add()
        {
            return Ok();
        }

    }
}
