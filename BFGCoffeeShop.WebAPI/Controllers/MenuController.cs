using BFGCoffeeShop.Models.MenuModels;
using BFGCoffeeShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BFGCoffeeShop.WebAPI.Controllers
{
    public class MenuController : ApiController
    {


        private MenuService _menuService = new MenuService();

        public IHttpActionResult Get()
        {
            MenuService menuService = CreateMenuService();
            var menus = menuService.GetMenus();
            return Ok(menus);
        }

        public IHttpActionResult Post(MenuCreate menu)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMenuService();

            if (!service.CreateMenu(menu))
                return InternalServerError();

            return Ok();
        }

        private MenuService CreateMenuService()
        {
            //var menuId = User.Identity.Get
            var menuService = new MenuService();
            return menuService;
        }

        public IHttpActionResult Get(int id)
        {
            MenuService menuService = CreateMenuService();
            var menu = menuService.GetMenuById(id);
            return Ok(menu);
        }

        public IHttpActionResult Put(MenuEdit menu)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateMenuService();

            if (!service.UpdateMenu(menu))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateMenuService();

            if (!service.DeleteMenu(id))
                return InternalServerError();

            return Ok();
        }
    }
    }
