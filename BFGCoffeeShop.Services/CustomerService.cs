using BFGCoffeeShop.Data;
using BFGCoffeeShop.Models.CustomerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFGCoffeeShop.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;
        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    CustomerTag = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PaymentType = model.PaymentType,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerList> GetCustomer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Where(e => e.CustomerTag == _userId)
                    .Select(
                        e =>
                        new CustomerList
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            PaymentType = e.PaymentType,
                        }
                    );
                return query.ToArray();
            }
        }
        public CustomerDetails GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == id && e.CustomerTag == _userId);
                return
                        new CustomerDetails
                        {
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            PaymentType = entity.PaymentType,
                        };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Customers
                    .Single(e => e.CustomerId == e.CustomerId && e.CustomerTag == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PaymentType = model.PaymentType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Customers
                    .Single(e => e.CustomerId == customerId && e.CustomerTag == _userId);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
