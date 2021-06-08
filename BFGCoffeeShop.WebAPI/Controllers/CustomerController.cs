using BFGCoffeeShop.Models.CustomerModels;
using BFGCoffeeShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BFGCoffeeShop.WebAPI.Controllers
{
    [Authorize]
    public class CustomerController : ApiController
    {
        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new CustomerService(userId);
            return noteService;
        }
        public IHttpActionResult Get()
        {
            CustomerService noteService = CreateCustomerService();
            var customers = noteService.GetCustomer();
            return Ok(customers);
        }
        public IHttpActionResult Post(CustomerCreate customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.CreateCustomer(customer))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CustomerService customerService = CreateCustomerService();
            var customers = customerService.GetCustomerById(id);
            return Ok(customers);
        }

        public IHttpActionResult Put(CustomerEdit customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCustomerService();

            if (!service.UpdateCustomer(customer))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCustomerService();

            if (!service.DeleteCustomer(id))
                return InternalServerError();

            return Ok();
        }
    }
}
