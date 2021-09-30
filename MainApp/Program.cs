using System;
using AppLibrary;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var db = new Database();

            // var flight1 = new Flight("737") { Departure = "JFK", Arrival = "LAX" };
            // var flight2 = new Flight("747") { Departure = "LGA", Arrival = "BDL" };

            // db.Add(flight1);
            // db.Add(flight2);
            // db.SaveChanges();

            // // Listing all flights, sections, seats
            // foreach (var flight in db.Flights)
            //     Console.WriteLine($"Flight {flight.Id} is a {flight.AircraftType}, departs {flight.Departure} and arrives in {flight.Arrival}");
            // foreach (var section in db.Sections)
            //     Console.WriteLine($"Section {section.Id} is {section.CabinClass}");

            // var sortedSeats = db.Seats.OrderBy(s => s.Section.Flight.Id).ThenBy(s => s.UniqueId);
            // foreach (var s in sortedSeats)
            // {

            //     if (s.Occupant == "none")
            //         Console.WriteLine($"Seat {s.UniqueId} costs {s.Cost} and is on flight {s.Section.Flight.Id}");
            // }

            //searching by parameter, e.g. Departure location "JFK"
            // Console.WriteLine("searching flights by parameter, e.g. Departure location JFK");
            // var searchPlane = db.Flights.Where(f => f.Departure == "JFK");

            // foreach (var flight in searchPlane)
            //     Console.WriteLine($"Flight {flight.Id} is a {flight.AircraftType}, departs {flight.Departure} and arrives in {flight.Arrival}");

            // //booking empty seat
            // Console.WriteLine("Booking seat A1 on flight 2 for adult and A2 for child");
            // //"fake" code to parse user input

            // int userFlightID1 = 2;
            // int userSection1 = 0;    //this section depends on translating user input
            // int userSeatNumber1 = 1;
            // string occupant1 = "adult";

            // // if seat is empty, change to specified occupant
            // if (db.Flights.Where(f => f.Id == userFlightID1).First().Sections[userSection1].Seats[userSeatNumber1 - 1].Occupant == "none")
            // {
            //     db.Flights.Where(f => f.Id == userFlightID1).First().Sections[userSection1].Seats[userSeatNumber1 - 1].Occupant = occupant1;
            // }

            // int userFlightID = 2;
            // int userSection = 0;    //this section depends on translating user input
            // int userSeatNumber = 2;
            // string occupant = "child";

            // // if seat is empty, change to specified occupant
            // if (db.Flights.Where(f => f.Id == userFlightID).First().Sections[userSection].Seats[userSeatNumber - 1].Occupant == "none")
            // {
            //     db.Flights.Where(f => f.Id == userFlightID).First().Sections[userSection].Seats[userSeatNumber - 1].Occupant = occupant;
            // }

            //doesn't update when we comment out lines 16-21
            int userFlightID2 = 2;
            int userSection2 = 0;    //this section depends on translating user input
            int userSeatNumber2 = 3;
            string occupant2 = "child";

            // if seat is empty, change to specified occupant
            if (db.Flights.Where(f => f.Id == userFlightID2).First().Sections[userSection2].Seats[userSeatNumber2 - 1].Occupant == "none")
            {
                db.Flights.Where(f => f.Id == userFlightID2).First().Sections[userSection2].Seats[userSeatNumber2 - 1].Occupant = occupant2;
            }
            db.SaveChanges();


            //seats occupied by children
            var flightChosen = 2;
            var seatOccupied = Convert.ToDouble(db.Seats.Where(s => s.Section.Flight.Id == flightChosen).Where(s => s.Occupant != "none").Count());
            var seatTotal = Convert.ToDouble(db.Seats.Where(s => s.Section.Flight.Id == flightChosen).Count());
            var seatPercentOccupied = (seatOccupied / seatTotal) * 100;
            Console.WriteLine($"Flight 1 is {seatPercentOccupied}% occupied");

            var childSeats = db.Seats.Where(s => s.Occupant == "child").Count();
            Console.WriteLine($"There are {childSeats} seats occupied by children.");

            //revenue per flight
            foreach (var flight in db.Flights)
                Console.WriteLine($"Revenue for flight {flight.Id}: {Convert.ToDecimal(db.Seats.Where(s => s.Section.Flight.Id == flight.Id).Where(s => s.Occupant != "none").Select(s => s.Cost).Sum())}");

        }
    }
}
