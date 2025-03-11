using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.domain
{
    public enum PlaneType
    {
        Boing,
        AirBus
    }

    public class Plane
    {
        public int PlaneId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La capacité doit être un entier positif.")]
        public int Capacity { get; set; }

        public DateTime ManufactureDate { get; set; }
        public PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> flights { get; set; }

        public override string ToString()
        {
            return "Capacity: " + Capacity + ", Date: " + ManufactureDate;
        }

        public Plane()
        {
        }

        public Plane(int capacity, DateTime manufactureDate, PlaneType planeType)
        {
            Capacity = capacity;
            ManufactureDate = manufactureDate;
            PlaneType = planeType;
        }
    }
}
