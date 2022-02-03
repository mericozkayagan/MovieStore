using MovieStore.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.CustomerOperations.Commands
{
    public class DeleteCustomerCommand
    {
        private readonly IContext _context;

        public DeleteCustomerCommand(IContext context)
        {
            _context = context;
        }

        public int CustomerId { get; set; }

        public void Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.CustomerId == CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Müşteri bulunamadı");
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
