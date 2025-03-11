using System;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.domain
{
    public class Staff : Passenger
    {
        public DateTime EmploymentDate { get; set; }
        public string Function { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Le salaire doit être une valeur monétaire.")]
        public decimal Salary { get; set; }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a staff");
        }
    }
}
