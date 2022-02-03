using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Common;
using MovieStore.DbOperations;
using MovieStoreUnitTests.TestSetup.TestData;
using MovieStoreUnitTests.TestSetup.TestEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStoreUnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public ContextMovie context { get; set; }
        public IMapper mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<ContextMovie>().UseInMemoryDatabase(databaseName: "MovieStoreTestDb").Options;
            context = new ContextMovie(options);

            context.Database.EnsureCreated();
            context.AddMovies();
            context.AddDirectors();
            context.AddCustomers();
            context.SaveChanges();

            mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }

}
