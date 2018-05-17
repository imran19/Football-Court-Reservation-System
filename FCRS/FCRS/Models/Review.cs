using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCRS.Models
{
    public class Review
    {



        public int ReviewID { get; set; }
        public string ReviewText { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        //public int Id { get; set; }
        //public DateTime Date { get; set; }
        //public DateTime StartTme { get; set; }
        //public DateTime EndTime { get; set; }

        //public Field Field { get; set; }
        //public int FieldId { get; set; }


    }
}