using BFGCoffeeShop.Models.CoffeeOrderModels;
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
    public class CoffeeOrderController : ApiController
    {

        public IHttpActionResult Get()
        {
            var CoffeeOrder = CreateCoffeeOrderService();
            var coffee = CoffeeOrder.GetCoffeeOrders();
            return Ok(coffee);
        }

        public IHttpActionResult Get(int id)
        {
            var CoffeeOrder = CreateCoffeeOrderService();
            var coffee = CoffeeOrder.GetCoffeeOrderById(id);
            return Ok(coffee);
        }

        public IHttpActionResult Post(CoffeeOrderCreate Coffee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCoffeeOrderService();

            if (!service.PostCoffeeOrder(Coffee))
                return InternalServerError();

            return Ok(service);
        }

        public IHttpActionResult Put(CoffeeOrderEdit Coffee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCoffeeOrderService();

            if (!service.UpdateCoffeeOrder(Coffee))
                return InternalServerError();

            return Ok(service);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateCoffeeOrderService();

            if (!service.DeleteCoffeeOrder(id))
                return InternalServerError();

            return Ok($"CoffeeOrder with Id #{id} has been deleted");
        }

        public CoffeeOrderService CreateCoffeeOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var CoffeeService = new CoffeeOrderService(userId);
            return CoffeeService;
        }
    }
}
