using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class FullName
    {
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Le prénom doit être compris entre 3 et 25 caractères.")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
