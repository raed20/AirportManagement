﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.domain
{
    public class Traveller : Passenger
    {
        public string HealthInformation { get; set; }
        public string Nationality {  get; set; }
        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a traveller");
        }
    }
}
