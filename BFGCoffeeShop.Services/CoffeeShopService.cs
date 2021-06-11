using BFGCoffeeShop.Data;
using BFGCoffeeShop.Models.CoffeeShopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Services
{
    public class CoffeeShopService
    {
        private readonly Dictionary<int, string> _menuDirectory = new Dictionary<int, string>();
    
        public bool CreateCoffeeShop(CoffeeShopCreate model)
        {
            var entity =
                new CoffeeShop()
                {
                    MenuId = model.MenuId,
                    ShopName = model.ShopName,
                    Location = model.Location,
                    PhoneNumber = model.PhoneNumber,
                    Website = model.Website,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CoffeeShops.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CoffeeShopListItem> GetCoffeeShop()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .CoffeeShops
                    //.Where(e => e.CustomerTag == _userId)
                    .Select(
                        e =>
                        new CoffeeShopListItem
                        {
                            CoffeeShopId = e.CoffeeShopId,
                            ShopName = e.ShopName,
                            Location = e.Location,
                            PhoneNumber = e.PhoneNumber,
                            Website = e.Website,
                        }
                    );
                return query.ToArray();
            }
        }
        public CoffeeShopDetails GetCoffeeShopById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CoffeeShops
                    .Single(e => e.CoffeeShopId == id);
                return
                        new CoffeeShopDetails
                        {
                            CoffeeShopId = entity.CoffeeShopId,
                            ShopName = entity.ShopName,
                            Location = entity.Location,
                            PhoneNumber = entity.PhoneNumber,
                            Website = entity.Website,
                        };
            }
        }

        public bool UpdatCoffeeShop(CoffeeShopEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CoffeeShops
                    .Single(e => e.CoffeeShopId == e.CoffeeShopId);

                entity.CoffeeShopId = model.CoffeeShopId;
                entity.ShopName = model.ShopName;
                entity.Location = model.Location;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Website = model.Website;


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCoffeeShop(int coffeeShopId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .CoffeeShops
                    .Single(e => e.CoffeeShopId == coffeeShopId);
                ctx.CoffeeShops.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
