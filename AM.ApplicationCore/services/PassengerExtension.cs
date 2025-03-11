using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.domain;

namespace AM.ApplicationCore.services
{
    public static class PassengerExtension 
    {
        

        public static void UpperFullName(this Passenger passenger)
        {

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            passenger.FullName.FirstName = textInfo.ToTitleCase(passenger.FullName.FirstName.ToLower());
            passenger.FullName.LastName = textInfo.ToTitleCase(passenger.FullName.LastName.ToLower());
        }
    }
}
