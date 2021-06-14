
using BFGCoffeeShop.Data;
using BFGCoffeeShop.Models.AdditionModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Services
{
    public class AdditionService
    {
        public bool CreateAddition(AdditionCreate create)
        {
            var entity =
                new Addition()
                {
                    Name = create.Name,
                    Price = create.Price,
                    CoffeeOrderId = create.CoffeeOrderId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Additions.Add(entity);
                return ctx.SaveChanges()==1;
            }
        }

        public IEnumerable<AdditionItemList> GetAdditions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Additions
                    //.Where(e => e.CustomerId == e.Customer.CustomerId)
                    .Select(
                        e =>
                        new AdditionItemList
                        {
                            AdditionId = e.AdditionId,
                            Name = e.Name,
                            Price = e.Price
                        });
                return query.ToArray();

            }
        }

        public AdditionDetail GetAdditionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Additions
                    .Single(e => e.AdditionId == id);
                return
                    new AdditionDetail
                    {
                        AdditionId = entity.AdditionId,
                        Name = entity.Name,
                        Price = entity.Price
                    };
            }
        }

        public bool UpdateAddition(AdditionEdit edit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Additions
                    .Single(e => e.AdditionId == edit.AdditionId);
                entity.Name = edit.Name;
                entity.Price = edit.Price;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAddition(int additionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Additions
                    .Single(e => e.AdditionId == additionId);
                ctx.Additions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

