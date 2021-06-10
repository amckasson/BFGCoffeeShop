
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
        private readonly Guid _userId;

        public AdditionService(Guid userId)
        {
            _userId = userId;
        }
      
        public bool CreateAddition(AdditionCreate create)
        {
            var entity =
                new Addition()
                {
                    AdditionTag = _userId,
                    Name = create.Name,
                    Price = create.Price,
                    CustomerId = create.CustomerId //Not sure if needed
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Additions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AdditionItemList> GetAdditions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Additions
                    .Where(e => e.AdditionTag == _userId)
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
                    .Single(e => e.AdditionId == id && e.AdditionTag == _userId);
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
                    .Single(e => e.AdditionId == edit.AdditionId && e.AdditionTag == _userId);
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
                    .Single(e => e.AdditionId == additionId && e.AdditionTag == _userId);
                ctx.Additions.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}

