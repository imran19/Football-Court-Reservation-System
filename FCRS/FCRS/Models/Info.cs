using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCRS.Models
{
    public class Info
    {
        public int InfoID { get; set; }
        public string InfoText { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }





        //public int Id { get; set; }
        //public string Description { get; set; }

        //public int RequestId { get; set; }
    }
}