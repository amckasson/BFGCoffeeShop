using BFGCoffeeShop.Data;
using BFGCoffeeShop.Models.AdditionModels;
using BFGCoffeeShop.Models.CoffeeOrderModels;
using BFGCoffeeShop.Models.CustomerModels;
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
        public bool PostCoffeeOrder(CoffeeOrderCreate model)
        {
            var entity = new CoffeeOrder()
            {
                Created = DateTimeOffset.Now,
                Barista = model.Barista,
                Country = model.Country,
                CoffeeShopId = model.CoffeeShopId
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
                        Country = entity.Country,
                        Barista = entity.Barista,
                        Created = entity.Created,
                        Edited = entity.Edited,

                        Customer = entity.Customer.Select(e => new Customer()
                        {
                            CustomerTag = e.CustomerTag,
                            CustomerId = e.CustomerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            PaymentType = e.PaymentType,
                        }).ToList(),


                        Additions = entity.Additions.Select(e => new Addition()
                        {
                            AdditionId = e.AdditionId,
                            Name = e.Name,
                            Price = e.Price,

                        }).ToList(),

                        Menus = entity.Menus.Select(e => new Menu()
                        {
                            ItemName = e.ItemName,
                            MenuId = e.MenuId,
                            ItemPrice = e.ItemPrice
                        }).ToList()
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
