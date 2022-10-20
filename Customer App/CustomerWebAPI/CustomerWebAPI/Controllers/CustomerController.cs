using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CustomerWebAPI.Service;
using CustomerWebAPI.Entities;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
       

            private readonly ICustomerService _customerService;


            public CustomerController(ICustomerService customerService)
            {
                _customerService = customerService;
            }




            [HttpGet]
            public async Task<IActionResult> GetAllCustomers([FromQuery] Pagination pagination)
            {
                try
                {
                    var customers = await _customerService.GetPagedCustomers(pagination);
                    return Ok(customers);
                }
                catch
                {
                    return StatusCode(500, "Internal Server error");
                }
            }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCustomer(int id)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var category = await _customerService.GetCustomer(id);
            return Ok(category);
        }





        [HttpPost("CreateCustomer")]
            public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                try
                {
                    await _customerService.Insert(customer);
                    return Ok();
                }
                catch
                {
                    return StatusCode(500, "Internal Server error");
                }
            }


            [HttpPut("UpdateCustomer")]
            public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
            {
                if (!ModelState.IsValid || id == 0) return BadRequest(ModelState);
                try
                {
                    await _customerService.UpdateCustomer(customer);
                    return Accepted();
                }
                catch
                {
                    return StatusCode(500, "Internal Server error");
                }
            }


            [HttpDelete("DeleteCustomer")]
            public async Task<IActionResult> DeleteCustomer(int id)
            {
                if (id == null) return BadRequest();
                try
                {
                    await _customerService.DeleteCustomer(id);

                    return Ok();
                }
                catch
                {
                    return StatusCode(500, "Internal Server error");
                }
            }


        }
    }

