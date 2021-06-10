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
        public bool CreateMenu(MenuCreate model)
        {
            var entity =
                new Menu()
                {
                    ItemName = model.ItemName,
                    ItemPrice = model.ItemPrice
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
                        .Select(
                            e =>
                                new MenuListItem
                                {
                                    MenuId = e.MenuId,
                                    ItemName = e.ItemName,
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
                        .Single(e => e.MenuId == id);
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
                        .Single(e => e.MenuId == model.MenuId);

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
                        .Single(e => e.MenuId == menuId);

                ctx.Menus.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
