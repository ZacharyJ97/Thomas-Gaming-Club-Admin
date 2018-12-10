using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Thomas_Gaming_Club.Models;

namespace Thomas_Gaming_Club.Data_Contexts
{
    public class EFDbContext : DbContext
    {
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Game> VideoGames { get; set; }

        public EFDbContext() : base("name=Thomas_Gaming_ClubDbContext")
        {

        }
    }
}