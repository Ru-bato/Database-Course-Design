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

        [HttpGet("GetMyAllOrder")]
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
        [HttpGet("GetMyPaidOrder")]
        public IActionResult GetPaid(string? cust)
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                try
                {
                    //var ruleCodes = string.IsNullOrEmpty(cust) ? _dbContext.ORDERLIST
                    //    .ToList() : _dbContext.ORDERLIST.Where(code => code.User_id == cust)
                    //    .ToList();
                    Console.WriteLine("cust = " + cust);
                    var ruleCodes = from ticket in _dbContext.ORDERLIST
                                    join train in _dbContext.TRAIN
                                    on ticket.Train_id equals train.Train_id
                                    where ticket.User_id == cust
                                    where ticket.Order_status == "paid"
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
        [HttpGet("GetMyUnpaidOrder")]
        public IActionResult GetUnpaid(string? cust)
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
                                    where ticket.Order_status == "unpaid"
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
        [HttpGet("GetMyWaitOrder")]
        public IActionResult GetWait(string? cust)
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
                                    where ticket.Order_status == "wait"
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
        [HttpDelete("DeleteUnpaidOrder")]

        public IActionResult DeleteUnpaidOrder(string o_id)
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                if (o_id == null)
                {
                    return BadRequest("Invalid order data.");
                }
                try
                {
                    var orderlist = _dbContext.ORDERLIST.FirstOrDefault(o => o.Order_id == o_id);

                    // Check if the record exists
                    if (orderlist == null)
                    {
                        return NotFound(new { message = $"Train with ID {o_id} not found." });
                    }

                    var train = _dbContext.TRAIN.FirstOrDefault(t => t.Train_id == orderlist.Train_id);
                    if (train == null)
                    {
                        return NotFound(new { message = $"Train with ID {orderlist.Train_id} not found." });
                    }
                    train.Remaining_tickets = train.Remaining_tickets + 1;
                    // Remove the record
                    _dbContext.ORDERLIST.Remove(orderlist);

                    // Save changes to the database
                    _dbContext.SaveChanges();
                    return Ok(orderlist);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }

        [HttpDelete("DeleteWaitOrder")]

        public IActionResult DeleteWaitOrder(string o_id)
        {
            using (OracleConnection connection = new OracleConnection(conStr))
            {
                if (o_id == null)
                {
                    return BadRequest("Invalid order data.");
                }
                try
                {
                    var orderlist = _dbContext.ORDERLIST.FirstOrDefault(o => o.Order_id == o_id);

                    // Check if the record exists
                    if (orderlist == null)
                    {
                        return NotFound(new { message = $"Train with ID {o_id} not found." });
                    }

                    /*var train = _dbContext.TRAIN.FirstOrDefault(t => t.Train_id == orderlist.Train_id);
                    if (train == null)
                    {
                        return NotFound(new { message = $"Train with ID {orderlist.Train_id} not found." });
                    }
                    train.Remaining_tickets = train.Remaining_tickets;*/
                    // Remove the record
                    _dbContext.ORDERLIST.Remove(orderlist);

                    // Save changes to the database
                    _dbContext.SaveChanges();
                    return Ok(orderlist);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
