using System;
using System.Collections.Generic;
using System.Linq;

namespace AppLibrary
{
    public class Flight
    {
        public int Id { get; set; }
        public string AircraftType { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public List<Section> Sections { get; set; }

        public Flight(string aircraftType)
        {
            this.AircraftType = aircraftType;

            this.Sections = new List<Section>();
            this.Sections.Add(new Section() { CabinClass = "First Class" });
            this.Sections.Add(new Section() { CabinClass = "Business Class" });
            this.Sections.Add(new Section() { CabinClass = "Economy Class" });
            int seatCounter = 1;
            switch (aircraftType)
            {
                case "737":
                    foreach (int value in Enumerable.Range(0, 2))
                    {
                        this.Sections[0].Seats.Add(new Seat());
                        this.Sections[0].Seats[value].UniqueId = "A" + seatCounter.ToString();
                        this.Sections[0].Seats[value].Cost = 100;
                        this.Sections[0].Seats[value].Occupant = "none";
                        seatCounter += 1;
                    }
                    foreach (int value in Enumerable.Range(0, 3))
                    {
                        this.Sections[1].Seats.Add(new Seat());
                        this.Sections[1].Seats[value].UniqueId = "B" + seatCounter.ToString();
                        this.Sections[1].Seats[value].Cost = 80;
                        this.Sections[1].Seats[value].Occupant = "none";
                        seatCounter += 1;
                    }
                    foreach (int value in Enumerable.Range(0, 5))
                    {
                        this.Sections[2].Seats.Add(new Seat());
                        this.Sections[2].Seats[value].UniqueId = "C" + seatCounter.ToString();
                        this.Sections[2].Seats[value].Cost = 50;
                        this.Sections[2].Seats[value].Occupant = "none";
                        seatCounter += 1;
                    }
                    break;

                case "747":
                    foreach (int value in Enumerable.Range(0, 3))
                    {
                        this.Sections[0].Seats.Add(new Seat());
                        this.Sections[0].Seats[value].UniqueId = "A" + seatCounter.ToString();
                        this.Sections[0].Seats[value].Cost = 200;
                        this.Sections[0].Seats[value].Occupant = "none";
                        seatCounter += 1;
                    }
                    foreach (int value in Enumerable.Range(0, 5))
                    {
                        this.Sections[1].Seats.Add(new Seat());
                        this.Sections[1].Seats[value].UniqueId = "B" + seatCounter.ToString();
                        this.Sections[1].Seats[value].Cost = 150;
                        this.Sections[1].Seats[value].Occupant = "none";
                        seatCounter += 1;
                    }
                    foreach (int value in Enumerable.Range(0, 8))
                    {
                        this.Sections[2].Seats.Add(new Seat());
                        this.Sections[2].Seats[value].UniqueId = "C" + seatCounter.ToString();
                        this.Sections[2].Seats[value].Cost = 120;
                        this.Sections[2].Seats[value].Occupant = "none";
                        seatCounter += 1;
                    }
                    break;
            }
        }
    }
}