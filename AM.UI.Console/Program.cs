// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.domain;
using AM.ApplicationCore.services;
using AM.Infrastructure;
/*Plane plane = new Plane();
plane.PlaneType = PlaneType.AirBus;
plane.Capacity = 200;*/
Plane plane2 = new Plane { Capacity = 200 };


FlightMethods fn = new FlightMethods();
fn.Flights = TestData.listFlights;
Console.WriteLine("Services");
foreach (var x in fn.GetFlightDates("Madrid"))
{
    Console.WriteLine(x);
}

fn.ShowFlightDetails(TestData.BoingPlane);
var p= fn.ProgrammedFlightNumber(new DateTime(2022, 12, 1));
Console.WriteLine(p);
var s = fn.DurationAverage("Madrid");
Console.WriteLine(s);

foreach (var n in fn.OrderedDurationFlights()) {
    Console.WriteLine(n); }
fn.DestinationGroupedFlights() ;

//insertion dans la bd
AMContext ctx = new AMContext();

//instanciation des objets
//Plane plane1 = new Plane
//{
//    PlaneType = PlaneType.AirBus,
//    Capacity = 150,
//    ManufactureDate = new DateTime(2015, 02, 03)
//};

//Flight f1 = new Flight
//{
//    Departure = "Tunis",
//    Airline = "Tunisair",
//    FlightDate = new DateTime(2022, 02, 01, 21, 10, 10),
//    Destination = "Paris",
//    EffectiveArrival = new DateTime(2022, 02, 01, 23, 10, 10),
//    EstimatedDuration = 105,
//    plane = plane1
//};

//ajout des objects aux dbset
//ctx.Planes.Add(TestData.Airbusplane);
//ctx.Planes.Add(TestData.BoingPlane);

//ctx.Flights.Add(f1);

////persister les données 
//ctx.SaveChanges();
//Console.WriteLine("ajout effectué avec succés");

foreach (Flight f in ctx.Flights)
    Console.WriteLine("Date: " + f.FlightDate + "Destination : " +f.Destination +"plane capacity :" + f.plane.Capacity);

