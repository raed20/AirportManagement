using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;

namespace AM.ApplicationCore.interfaces
{
    public interface IServicePlane : IService<Plane>
    {

        IEnumerable<Passenger> GetPassenger(Plane p);
        IEnumerable<Flight> GetFlights(int n);
        bool IsAvailablePlane(Flight flight, int n);

        void DeletePlanes();
    }
}
