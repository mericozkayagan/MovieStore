using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreUnitTests.TestSetup.TestData
{
    public static class Directors
    {
        public static void AddDirectors(this ContextMovie context)
        {
            context.Directors.AddRange(
                    new Director
                    {
                        DirectorName="David",DirectorSurname="Fincher"
                    },
                    new Director
                    {
                        DirectorName = "George",
                        DirectorSurname = "Lucas"
                    }

                    );
        }
    }
}
