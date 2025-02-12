using Microsoft.AspNetCore.Mvc;
using Models;
using testtt.Context;

namespace testtt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        public TestContext _db;
        public OrdersController(TestContext testCo)
        {
            _db = testCo;
        }

        [HttpGet("getAllOrder")] 
        public async Task<ActionResult<List<Order>>> getAllOrder()
        {
            return 
        }

    }
}
