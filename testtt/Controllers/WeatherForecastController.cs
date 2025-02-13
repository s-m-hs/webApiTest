using System.Xml;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using DTO;
using testtt.Context;

namespace testtt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public TestContext _db { get; set; }
        public WeatherForecastController(TestContext testContext)
        {
            _db = testContext;
        }

        [HttpGet("user")]
        public async Task<ActionResult<CustomerDTO>> Get(int userId)
        {
            var customer = await _db.Customers.Where(x => x.ID == userId).Select(u =>
                new CustomerDTO()
                {
                    ID = u.ID,
                    Address = u.Address,
                    Name = u.Name,
                    Phone = u.Phone
                }
                ).FirstOrDefaultAsync();

            return Ok(customer);
        }


        [HttpGet("user/deleted")]
        public async Task<ActionResult<List<Customer>>> GetB()
        {
            var customers = await _db.Customers.Where(x => !x.IsVisible).ToArrayAsync();
            return Ok(customers);
        }


        [HttpGet("orders/customer")]
        public async Task<ActionResult<List<Order>>> GetC(int id)
        {

            var orders = _db.Orders.Where(x => x.customerID == id);

            return Ok(orders);


        }


        [HttpGet("getOrderByID")]
        public async Task<ActionResult<Order>> GetD(int Id, int userId)
        {
            var order = _db.Orders.Where(x => x.customerID == userId && x.ID == Id);

            return Ok(order);
        }

        [HttpGet("getOrderItemById")]
        public async Task<ActionResult<List<Order_Product>>> GetG(int id)
        {
            var order = _db.Order_Products.Where(x => x.OrderId == id).ToArrayAsync();
            return Ok(order);
        }

        [HttpPost("addUser")]
        public async Task<ActionResult<Customer>> addUser(Customer newCustomer)
        {
            var result = await _db.AddAsync(newCustomer);
            await _db.SaveChangesAsync();
            return Ok(result.Entity);


        }

        [HttpGet("getAllUsers")]
        public async Task<ActionResult<List<Customer>>> getAllUsers()
        {
            var users = await _db.Customers.ToArrayAsync();
            return Ok(users);
        }

        [HttpPut("editUser")]
        public async Task<ActionResult<Customer>> editUser(Customer newCustomer)
        {
            var userId = newCustomer.ID;
            var user = await _db.Customers.Where(x => x.ID == userId).FirstOrDefaultAsync();
            if (user != null)
            {
                newCustomer.Address = user.Address;
                newCustomer.LastModified = DateTime.Now;

                _db.Entry(user).CurrentValues.SetValues(newCustomer);
                var result = await _db.SaveChangesAsync();
                return Ok(result);
                //_db.Entry(newCustomer).State = EntityState.Modified;
                //await _db.SaveChangesAsync();
                //return NoContent();
            }
            return BadRequest();
        }


        [HttpDelete("deleteUser")]
        public async Task<ActionResult<Customer>> DeleteUser(int userId)
        {
            var user = await _db.Customers.Where(x => x.ID == userId).FirstOrDefaultAsync();
            if (user != null)
            {
                user.IsVisible = false;

                await _db.SaveChangesAsync();

                return Ok(new { result = "200" });

            }
            return BadRequest();
        }

        [HttpPost("searchUser")]
        public async Task<ActionResult<List<Customer>>> searchUser(string input)
        {
            if (input == null) return BadRequest();

            input = input.Replace(" ", "");
            var users = await _db.Customers.Where(x => x.Name.Replace(" ","").Contains(input)).ToArrayAsync();

            if (users.Any())
            {
                return Ok(users);
            }
            return NotFound();
        }
    }
}