using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;

namespace AM.ApplicationCore.interfaces
{
    public interface IServiceFlight : IService<Flight>
    {
        public IEnumerable<Flight> SortFlights()
        {
            return GetMany().OrderByDescending(f => f.FlightDate);
        }
    }
}
