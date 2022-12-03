using CastleCoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CastleCoreApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ActionResult CreateCustomer()
        {
            _customerService.CreateCustomer();
            return Ok();
        }

        [HttpGet]
        public ActionResult GetCustomer()
        {
            _customerService.GetCustomerById();
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateCustomerDetails()
        {
            _customerService.UpdateCustomerDetails();
            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteCustomer()
        {
            _customerService.DeleteCustomer();
            return NoContent();
        }
    }
}
