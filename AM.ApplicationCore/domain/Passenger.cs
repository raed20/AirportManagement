using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AM.ApplicationCore.domain
{
    public class Passenger
    {
        [Key]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Le numéro de passeport doit contenir exactement 7 caractères.")]
        public string PassportNumber { get; set; }

        public FullName FullName { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date, ErrorMessage = "Veuillez entrer une date valide.")]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse e-mail valide.")]
        public string EmailAddress { get; set; }

        [Required]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "Le numéro de téléphone doit contenir exactement 8 chiffres.")]
        public string TelNumber { get; set; }

        public ICollection<Flight> flights { get; set; }

        public bool CheckProfile(string firstName, string lastName)
        {
            return firstName == FullName.FirstName && FullName.LastName == lastName;
        }

        public bool CheckProfile1(string firstName, string lastName, string email)
        {
            return FullName.FirstName == firstName && FullName.LastName == lastName && EmailAddress == email;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
    }
}
