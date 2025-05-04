using System.Reflection.Metadata;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.interfaces;
using AM.ApplicationCore.Services;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.services
{
    public class ServicePlane : Service<Plane>,IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        //Le service GetPassenger qui retourne les voyageurs d’un avion passé en paramètre.

        public IEnumerable<Passenger> GetPassenger(Plane p)
        {
            return p.flights.SelectMany(f=>f.tickets).Select(t=>t.Passenger);
        }

        //Le service GetFlights qui retourne les vols ordonnés date de départ des n derniers avions
        public IEnumerable<Flight> GetFlights(int n)
        {
            return GetMany()
            .OrderByDescending(p => p.PlaneId)
            .Take(n).SelectMany(p => p.flights)
            .OrderBy(f => f.FlightDate);
        }


        //Le service IsAvailablePlane qui retourne true si on peut réserver n place à un vol passé en paramètre.

        public bool IsAvailablePlane(Flight flight, int n)
        {
            return flight.plane.Capacity - flight.tickets.Count >= n;
        }
        //Le service DeletePlanes qui supprime tous les avions dont la date de fabrication a dépassé 10 ans.

        public void DeletePlanes()
        {
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays > 360 * 10);
        }

    }
}
