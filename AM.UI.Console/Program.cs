// See https://aka.ms/new-console-template for more information

using AM.ApplicationCore.domain;
using AM.ApplicationCore.services;
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