using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Thomas_Gaming_Club.Models
{
    public class VideoGame
    {
        [Key]
        public int GameId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }
        public string Platform { get; set; }
    }
}