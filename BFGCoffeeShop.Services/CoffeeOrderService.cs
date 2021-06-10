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
        private Guid _userId;
        
        public bool CreateCoffeeOrder(CoffeeOrderCreate model)
        {
            _userId = model.GetGUID();

            var entity = new CoffeeOrder()
            {
                FullName = model.FullName,
                CoffeeOrderTag = _userId,
                Created = DateTimeOffset.Now,
                Barista = model.Barista,
                CustomerId = model.CustomerId,
                TotalPrice = model.getTotalPrice(),
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
                    MenuItem = e.MenuItem,
                    TotalPrice = e.TotalPrice,
                    AdditionId = e.AdditionId,
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
                        CustomerId = entity.CustomerId,
                        Barista = entity.Barista,
                        MenuId = entity.MenuId,
                        AdditionId = entity.AdditionId,
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
                entity.AdditionId = model.AdditionId;
                entity.Edited = DateTimeOffset.Now;
                entity.Country = model.Country;
                entity.MenuId = model.MenuID;

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
