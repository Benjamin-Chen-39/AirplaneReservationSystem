using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppLibrary
{
    public class Section
    {
        public int Id { get; set; }
        public List<Seat> Seats { get; set; }
        public string CabinClass { get; set; }
        public Flight Flight { get; set; }

        public Section()
        {
            this.Seats = new();
        }

    }
}