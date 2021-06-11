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
        
        /*
        public Guid getUserIdFromCustomer()
        {
            CoffeeOrder MyCoffeeOrder = new CoffeeOrder();
            return MyCoffeeOrder.CoffeeOrderTag;
        }
        */

        public bool PostCoffeeOrder(CoffeeOrderCreate model)
        {
            var entity = new CoffeeOrder()
            {
                Created = DateTimeOffset.Now,
                Barista = model.Barista,
                CustomerId = model.CustomerId,
                Country = model.Country,
                CoffeeOrderTag = model.Customer.CustomerTag
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
                    CoffeeOrderId = e.CoffeeOrderId,
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
                        CustomerId = entity.CustomerId,
                        FullName = entity.Customer.FullName,
                        Country = entity.Country,
                        Barista = entity.Barista,
                        TotalPrice = entity.TotalPrice,
                        Created = entity.Created,
                        Edited = entity.Edited,
                        Customer = entity.Customer,
                        CoffeeOrderTag = entity.CoffeeOrderTag,
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
