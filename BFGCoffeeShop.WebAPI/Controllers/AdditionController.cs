
using BFGCoffeeShop.Models.AdditionModels;
using BFGCoffeeShop.Services;
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
        private AdditionService _additionService = new AdditionService();
        public IHttpActionResult Post(AdditionCreate create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_additionService.CreateAddition(create))
                return InternalServerError();

            return Ok();

        }
        public IHttpActionResult Get()
        {
            var additions = _additionService.GetAdditions();
            return Ok(additions);
        }

        public IHttpActionResult Get(int id)
        {
            var additions = _additionService.GetAdditionById(id);
            return Ok(additions);
        }

        public IHttpActionResult Put(AdditionEdit edit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_additionService.UpdateAddition(edit))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (!_additionService.DeleteAddition(id))
                return InternalServerError();
            return Ok();
        }
    }
}
