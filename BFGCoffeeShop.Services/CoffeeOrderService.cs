using BFGCoffeeShop.Data;
using BFGCoffeeShop.Models.AdditionModels;
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
                Country = model.Country,
                CoffeeOrderTag = model.CoffeeOrderTag
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
                var query = ctx.CoffeeOrders.Select(e => new CoffeeOrderListItem()
                {
                    CustomerId = e.CustomerId,
                    Created = e.Created,
                });
                return query.ToList();
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
                        FullName = entity.FullName,
                        Country = entity.Country,
                        Barista = entity.Barista,
                        TotalPrice = entity.TotalPrice,
                        Created = entity.Created,
                        Edited = entity.Edited,
                        Customer = entity.Customers
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
                entity.Edited = DateTimeOffset.Now;
                entity.Country = model.Country;

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
