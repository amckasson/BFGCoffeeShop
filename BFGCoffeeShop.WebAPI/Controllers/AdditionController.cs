
using BFGCoffeeShop.Models.AdditionModels;
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
    public class AdditionController : ApiController
    {
       // private AdditionService _additionService = new AdditionService();
        public IHttpActionResult Post(AdditionCreate create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateAdditionService();
            if (!service.CreateAddition(create))
                return InternalServerError();
            return Ok();

        }

        public IHttpActionResult Get()
        {
            AdditionService additionService = CreateAdditionService();
            var additions = additionService.GetAdditions();
            return Ok(additions);
        }

        private AdditionService CreateAdditionService()
        {
            var additionId = Guid.Parse(User.Identity.GetUserId());
            var additionService = new AdditionService(additionId);
            return additionService;
        }

        public IHttpActionResult Get(int id)
        {
            AdditionService additionService = CreateAdditionService();
            var additions = additionService.GetAdditionById(id);
            return Ok(additions);
        }

        public IHttpActionResult Put(AdditionEdit edit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var additionService = CreateAdditionService();
            if (!additionService.UpdateAddition(edit))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var additionService = CreateAdditionService();
            if (additionService.DeleteAddition(id))
                return InternalServerError();
            return Ok();
        }
    }
}
