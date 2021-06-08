using BFGCoffeeShop.Data;
using BFGCoffeeShop.Models.CoffeeOrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Services
{
    public class CoffeeOrderService
    {
        public bool CreateCoffeeOrder(CoffeeOrderCreate model)
        {
            var entity = new CoffeeOrder()
            {
                FullName = model.FullName,
                Created = DateTimeOffset.Now,
                //    AdditionId = model.AdditionId,
                // new Comment
                Barista = model.Barista,
                //    CustomerId = model.CustomerId,
                //    MenuId = model.MenuId,
                TotalPrice = Math.Round(model.TotalPrice, 2),
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
                var query =
                    ctx
                        .CoffeeOrders
                        .Select(
                        e =>
                            new CoffeeOrderListItem
                            {
                                CoffeeOrderId = e.CoffeeOrderId,
                                    //  CustomerId = e.CustomerId,
                                    //  MenuId = e.MenuId,
                                    //  AdditionId = e.AdditionId,
                                    TotalPrice = e.TotalPrice,
                                Created = e.Created
                            }
                        );
                return query.ToArray();
            }
        }

        public CoffeeOrderDetail GetCoffeeOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .CoffeeOrders
                    .Single(e => e.CoffeeOrderId == id);
                return
                    new CoffeeOrderDetail()
                    {
                        CoffeeOrderId = entity.CoffeeOrderId,
                        FullName = entity.FullName,
                        Country = entity.Country,
                            // CustomerId = entity.CustomerId,
                            Barista = entity.Barista,
                            // MenuId = entity.MenuId,
                            // AdditionId = entity.AdditionId,
                            TotalPrice = entity.TotalPrice,
                        Created = entity.Created,
                        Edited = entity.Edited
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
                //  entity.AdditionId = model.AdditionId;
                entity.Edited = DateTimeOffset.Now;
                entity.Country = model.Country;
                //  entity.MenuId = model.MenuID;

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
