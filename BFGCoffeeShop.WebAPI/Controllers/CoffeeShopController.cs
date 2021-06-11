using BFGCoffeeShop.Models.CoffeeShopModels;
using BFGCoffeeShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BFGCoffeeShop.WebAPI.Controllers
{
    public class CoffeeShopController : ApiController
    {
        public IHttpActionResult Get()
        {
            var coffeeShop = new CoffeeShopService();
            var coffee =coffeeShop.GetCoffeeShop();
            return Ok(coffee);
        }

        public IHttpActionResult Get(int id)
        {
            var coffeeShop = new CoffeeOrderService();
            var coffee = coffeeShop.GetCoffeeOrderById(id);
            return Ok(coffee);
        }

        public IHttpActionResult Post(CoffeeShopCreate coffee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new CoffeeShopService();
            if (!service.CreateCoffeeShop(coffee))
                return InternalServerError();

            return Ok(service);
        }

        public IHttpActionResult Put(CoffeeShopEdit coffee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = new CoffeeShopService();
            if (!service.UpdatCoffeeShop(coffee))
                return InternalServerError();
            return Ok(service);
        }

        public IHttpActionResult Delete(int id)
        {
            var service = new CoffeeShopService();
            if (!service.DeleteCoffeeShop(id))
                return InternalServerError();
            return Ok("It gone son");
        }
    }
}
