using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppLibrary
{
    public class Seat
    {
        public int Id { get; set; }
        public string UniqueId { get; set; }
        public decimal Cost { get; set; }
        [Column(TypeName = "varchar(5)")]
        public string Occupant { get; set; } //type of occupant, "none", "adult", or "child"      
        public Section Section { get; set; }
  
    }
}
