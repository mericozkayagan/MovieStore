using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreUnitTests.TestSetup.TestData
{
    public static class Customers
    {
        public static void AddCustomers(this ContextMovie context)
        {
            context.Customers.AddRange(
                    new Customer
                    {
                        CustormerName="Meriç",CustormerSurname="Özkaya"
                    },
                    new Customer
                    {
                        CustormerName = "Derin",
                        CustormerSurname = "Özkaya",
                    }

                    );
        }
    }
}
