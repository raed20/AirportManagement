using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;
using AM.ApplicationCore.interfaces;

namespace AM.ApplicationCore.services
{
    public class FlightMethods : IFlightMethods
    {
        //q16
        public Action<Plane> FlighDetailDel;
        public Func<string, double> DurationAverageDel;
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> dates = new List<DateTime>();
            /*for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].Destination == destination)
                {
                    dates.Add(Flights[i].FlightDate);
                }
            }*/
            /* foreach (Flight flight in Flights)
             {
                 if (flight.Destination == destination)
                 {
                     dates.Add(flight.FlightDate);
                 }
             }*/
            //dates= from flight in Flights
            //       where flight.Destination == destination
            //       select flight.FlightDate;

            dates = Flights.Where(flight => flight.Destination == destination)
                .Select(flight => flight.FlightDate);

            return dates;

        }

        public IEnumerable<Flight> GetFlights(string filterType, string filterValue)
        {
            IEnumerable<Flight> filteredFlights = Enumerable.Empty<Flight>();

            switch (filterType)
            {
                case "Destination":
                    filteredFlights = Flights.Where(flight => flight.Destination == filterValue);
                    break;
                case "Departure":
                    filteredFlights = Flights.Where(flight => flight.Departure == filterValue);
                    break;
                case "Plane":
                    filteredFlights = Flights.Where(flight => flight.plane.ToString() == filterValue);
                    break;
            }

            return filteredFlights;
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var details = from flight in Flights
            //              where flight.Plane == plane
            //              select new { flight.FlightDate, flight.Destination };
            //foreach (var f in details)
            //{
            //    Console.WriteLine(f);
            //}
           var  details= Flights.Where(f => f.plane == plane)
                .Select(f => new { f.FlightDate, f.Destination });
            foreach (var f in details)
            {
                Console.WriteLine(f);
            }

        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var req = from flight in Flights
            //          where DateTime.Compare(flight.FlightDate, startDate) > 0 && (flight.FlightDate - startDate).TotalDays < 8
            //          select flight;
            //return req.Count();
            var req = Flights.Where(f => DateTime.Compare(f.FlightDate, startDate) > 0 
                && (f.FlightDate - startDate)
                 .TotalDays < 8);
            return req.Count();

        }
        public double DurationAverage(string destination)
        {
        //    var req = from flight in Flights
        //              where flight.Destination == destination
        //              select flight.EstimatedDuration;
        //    return req.Average();
            return  Flights.Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration)
                .Average();

        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //var req = from flight in Flights
            //          orderby flight.EstimatedDuration descending
            //          select flight;
            //return req;
            return Flights.OrderByDescending(f => f.EstimatedDuration);
        }
        /*public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            var req = from t in flight.Tickets
                       .OfType<Traveller>()
                      orderby t.BirthDate
                      select t;
            return req.Take(3);

        }*/

        public IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights()
        {
            var req= from f in Flights
                     group f by f.Destination;
            foreach (var g in req) {
                Console.WriteLine("Destination" + g.Key);
                       foreach (var f in g) Console.WriteLine(f);
            }
            return req;
        }

        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            throw new NotImplementedException();
        }

        public FlightMethods()
        {
            FlighDetailDel = pl =>
            {
                var details = from flight in Flights
                              where flight.plane == pl
                              select new { flight.FlightDate, flight.Destination };
                foreach (var f in details)
                {
                    Console.WriteLine(f);
                }
            };
            DurationAverageDel = dest =>
                        {
                            var req = from flight in Flights
                                      where flight.Destination == dest
                                      select flight.EstimatedDuration;
                            return req.Average();
                        };
        }

        }
}
