using Microsoft.AspNetCore.Mvc;
using Session07.Es.CustomerManagement.ApplicationServices.Customers;
using Session07.Es.CustomerManagement.ApplicationServices.People.Dtoes;
using System.Threading.Tasks;

namespace Session07.Es.CustomerManagement.Endpoints.WebApi.Controllers.v01
{
    [ApiController]
    [Route("v01/[controller]/[action]")]
    public class CustomerController : Controller
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }



        [HttpPost]
        public async Task<object> CreateCustomer([FromBody]SaveCustomerDto customer)
        {
            var insertedCustomerId = await customerService.CreateCustomer(customer.FirstName, customer.LastName);
            return new { PersonId = insertedCustomerId.ToString() };
        }

        [HttpPost]
        public async Task UpdateCustomer([FromQuery]string customerId, [FromBody]SaveCustomerDto customer)
        {
            await customerService.UpdateCustomer(customerId, customer.FirstName, customer.LastName);
            Ok();
        }

        [HttpPost]

        public async Task ChangeAddress(
            [FromQuery]string customerId,
            [FromBody]AddressDto address)
        {
            await customerService.UpdateAddress(customerId, address.City, address.Country, address.Street, address.ZipCode);
            Ok();
        }

        [HttpGet]
        public async Task<CustomerDto> GetCustomer([FromQuery]string customerId)
        {
            return await customerService.GetCustomer(customerId);
        }

    }
}