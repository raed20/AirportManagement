using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string Airline { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }

        [ForeignKey("PlaneFK")]
        public virtual Plane plane { get; set; }
        public int PlaneFK { get; set; }
 //       public ICollection<Passenger> Passengers { get; set; }
        public virtual ICollection<Ticket> tickets { get; set; }

        public override string ToString()
        {
            return "Destination: " + Destination + ", Departure: " + Departure + ", Flight Date: " + FlightDate + ", Effective Arrival: " + EffectiveArrival + ", Estimated Duration: " + EstimatedDuration;
        }
    }
}
