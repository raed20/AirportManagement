using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.interfaces;
using AM.ApplicationCore.Services;

namespace AM.ApplicationCore.services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public IEnumerable<Flight> SortFlights()
        {
            return GetMany().OrderByDescending(f => f.FlightDate);
        }

    }

}
