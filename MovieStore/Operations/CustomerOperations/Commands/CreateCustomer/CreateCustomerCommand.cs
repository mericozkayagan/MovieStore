using AutoMapper;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Operations.CustomerOperations.Commands
{
    public class CreateCustomerCommand
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public CreateCustomerModel Model { get; set; }

        public void Handle()
        {
            var customer = _context.Customers.FirstOrDefault(x => x.CustormerName == Model.CustormerName && x.CustormerSurname == Model.CustormerSurname);
            if (customer is not null)
            {
                throw new InvalidOperationException("Müşteri zaten kayıtlı");
            }
            customer = _mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();

        }
    }
    public class CreateCustomerModel
    {
        public string CustormerName { get; set; }
        public string CustormerSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
