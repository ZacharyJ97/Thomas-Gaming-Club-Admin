using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Thomas_Gaming_Club.Models
{
    public class Game
    {
        public string title { get; set; }
        public int year { get; set; }
        public string publisher { get; set; }
        public string developer { get; set; }
        public string platform { get; set; }
    }
}