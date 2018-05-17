using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCRS.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }



    }
}