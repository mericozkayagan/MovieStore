using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Services
{
    public class DBLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] - " + message);
        }
    }
}
