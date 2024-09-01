using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DB_Backend.DB_BackendDAL;
using DB_Backend.DB_BackendModel;
using Oracle.ManagedDataAccess.Client;

namespace DB_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyOrderController : ControllerBase
    {
        private readonly MyTicketDbContext _dbContext;
        public static string conStr = AccommodateServer.conStr;
        public MyOrderController(MyTicketDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("GetMyOrder")]
        public IActionResult Get(string? cust)
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
                                    where ticket.User_id == cust
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
    }
}
