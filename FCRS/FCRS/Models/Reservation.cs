using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FCRS.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [DataType(DataType.Time)]
        public DateTime RequestStart { get; set; }

        [DataType(DataType.Time)]
        public DateTime RequestStop { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Status { get; set; }
    }
}