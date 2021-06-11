using BFGCoffeeShop.Data;
using BFGCoffeeShop.Models.MenuModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Services
{
    public class MenuService
    {
        private readonly Guid _userId;

        public MenuService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateMenu(MenuCreate model)
        {
            //_userId = model.CustomerOrder;
            var entity =
                new Menu()
                {
                    MenuTag = _userId,
                    ItemName = model.ItemName,
                    ItemPrice = model.ItemPrice,
                    CustomerId = model.CustomerId // Not sure if needed
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Menus.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MenuListItem> GetMenus()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Menus
                        .Where(e => e.MenuTag == _userId)
                        .Select(
                            e =>
                                new MenuListItem
                                {
                                    MenuId = e.MenuId,
                                    ItemName = e.ItemName,
                                    Price = e.ItemPrice
                                    
                                }
                        );
                return query.ToArray();
            }
        }

        public MenuDetail GetMenuById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.MenuId == id && e.MenuTag == _userId);
                return
                    new MenuDetail
                    {
                        MenuId = entity.MenuId,
                        ItemName = entity.ItemName,
                        ItemPrice = entity.ItemPrice
                    };
            }
        }

        public bool UpdateMenu(MenuEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.MenuId == model.MenuId && e.MenuTag == _userId);

                entity.MenuId = model.MenuId;
                entity.ItemName = model.ItemName;
                entity.ItemPrice = model.ItemPrice;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMenu(int menuId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Menus
                        .Single(e => e.MenuId == menuId && e.MenuTag == _userId);

                ctx.Menus.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
