using BFGCoffeeShop.Data;
using BFGCoffeeShop.Models.CoffeeOrderModels;
using BFGCoffeeShop.Models.MenuModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Services
{
    public class CoffeeOrderService
    {
        private readonly Guid _userId;

        public CoffeeOrderService(Guid userId)
        {
            _userId = userId;
        }

        public bool PostCoffeeOrder(CoffeeOrderCreate model)
        {
            var entity = new CoffeeOrder()
            {
                Created = DateTimeOffset.Now,
                Barista = model.Barista,
                CustomerId = model.CustomerId,
                Country = model.Country
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.CoffeeOrders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CoffeeOrderListItem> GetCoffeeOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.CoffeeOrders.Select(e => new CoffeeOrderListItem
                {
                    CoffeeOrderId = e.CoffeeOrderId,
                    CustomerId = e.CustomerId,
                    Additions = e.Additions,
                    MenuItem = e.MenuItem,
                    TotalPrice = e.TotalPrice,
                    Created = e.Created
                });
                return query.ToArray();
            }
        }

        public CoffeeOrderDetail GetCoffeeOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.CoffeeOrders.Single(e => e.CoffeeOrderId == id);

                return
                    new CoffeeOrderDetail()
                    {
                        CoffeeOrderId = entity.CoffeeOrderId,
                        CustomerId = entity.CustomerId,
                        Additions = entity.Additions,
                        FullName = entity.FullName,
                        Country = entity.Country,
                        Barista = entity.Barista,
                        TotalPrice = entity.TotalPrice,
                        Created = entity.Created,
                        Edited = entity.Edited,
                        MenuItem = entity.MenuItem,
                    };
            }
        }

        public bool UpdateCoffeeOrder(CoffeeOrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CoffeeOrders
                        .Single(e => e.CoffeeOrderId == model.CoffeeOrderId);

                entity.Barista = model.Barista;
                //entity.AdditionId = model.AdditionId;
                entity.Edited = DateTimeOffset.Now;
                entity.Country = model.Country;
               // entity.MenuId = model.MenuID;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteCoffeeOrder(int CoffeeOrderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .CoffeeOrders
                        .Single(e => e.CoffeeOrderId == CoffeeOrderId);

                ctx.CoffeeOrders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
