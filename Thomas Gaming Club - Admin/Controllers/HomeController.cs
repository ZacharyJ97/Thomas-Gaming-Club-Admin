using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thomas_Gaming_Club.Models;
using Thomas_Gaming_Club.Data_Contexts;
using System.Net;

namespace Thomas_Gaming_Club.Controllers
{
    public class HomeController : Controller
    {
        private EFDbContext db = new EFDbContext();

        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Events()
        {
            return View();
        }

        [HttpGet]
        public ViewResult ExtraLife()
        {
            return View();
        }

        [HttpGet]
        public ViewResult About()
        {
            return View();
        }

        [HttpGet]
        public ViewResult Resources()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PS4Games()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.platform.Contains("PS4") || x.platform.Contains("PSVR")).ToList().OrderBy(x => x.title);
            return View();
        }

        [HttpGet]
        public ActionResult WiiUGames()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.platform.Contains("WiiU")).ToList().OrderBy(x => x.title);
            return View();
        }

        [HttpGet]
        public ActionResult XboxGames()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.platform.Contains("Xbox")).ToList().OrderBy(x => x.title);
            return View();
        }

        [HttpGet]
        public ActionResult PCGames()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.platform.Contains("PC")).ToList().OrderBy(x => x.title);
            return View();
        }
        [HttpGet]
        public ActionResult WiiGames()
        {
            ViewBag.VideoGames = db.VideoGames.Where(x => x.platform.Equals("Wii")).ToList().OrderBy(x => x.title);
            return View();
        }

        [HttpGet]
        public ActionResult ResourceManager()
        {
            ViewBag.VideoGames = db.VideoGames.OrderBy(x => x.title);
            return View();
        }
        private IQueryable<VideoGame> GetGames()
        {
            var games = from stack in db.VideoGames
                         select new VideoGame
                         {
                             gameId = stack.gameId,
                             title = stack.title,
                             year = stack.year,
                             publisher = stack.publisher,
                             developer = stack.developer,
                             platform = stack.platform
                         };

            return games;
        }

        [HttpGet]
        public ViewResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ViewResult AllContacts()
        {
            ViewBag.Contacts = db.Contacts.ToList();
            return View(ViewBag.Contacts);
        }

        [HttpPost]
        public ActionResult Contact(Contact inquiry)
        {
             if (ModelState.IsValid && TryUpdateModel(inquiry))
             {
                db.Contacts.Add(inquiry);
                db.SaveChanges();
               
                return View("ContactSummary", inquiry);
             }
             else
             {
                 // there is a validation error
                 return View(inquiry);
             }
        }

        //Ignore all commented code from here down, is extra methods for other trials previously conducted
        /*private IQueryable<Contact> GetContacts()
        {
            var contacts = from conts in db.Contacts
                         select new Contact
                         {
                             PreferredContact = conts.PreferredContact,
                             PreferredTitle = conts.PreferredTitle,
                             FirstName = conts.FirstName,
                             LastName = conts.LastName,
                             Email = conts.Email,
                             Phone = conts.Phone,
                             Message = conts.Message
                        };

            return contacts;
        }*/


        /*[HttpPost]
        public ActionResult Contact(List<Contact> data)
        {
            data = this.makeContacts();
            foreach (Contact c in data)
            {
                if (ModelState.IsValid)
                {
                    // TODO: Email response to the party organizer
                    //return View("ContactSummary", inquiry);
                    View("ContactSummary", c);
                }
                else
                {
                    // there is a validation error
                    return View();
                }
            }
           return View("ContactSummary");
        }*/

        /*private List<Contact> makeContacts()
        {
            List<Contact> contacts = new List<Contact>
            {
                new Contact
                {
                    PreferredContact = "The Events Coordinator",
                    PreferredTitle = "Student",
                    FirstName = "Bubbles",
                    LastName = "McGee",
                    Email = "b.mcgee@email.com",
                    Phone = "2075555555",
                    Message = "Can I be the officer of memes for the club?"
                },

                new Contact
                {
                    PreferredContact = "The Officer of Communication",
                    PreferredTitle = "Staff",
                    FirstName = "Eric",
                    LastName = "Idle",
                    Email = "fleshwound@circus.com",
                    Phone = "",
                    Message = "What is the airspeed velocity of an unladen swallow?"
                },

                new Contact
                {
                    PreferredContact = "The Officer of Operations",
                    PreferredTitle = "Student",
                    FirstName = "Barron",
                    LastName = "Trump",
                    Email = "notmydad@gov.us",
                    Phone = "",
                    Message = "Help me."
                },

                new Contact
                {
                    PreferredContact = "The Officer of Operations",
                    PreferredTitle = "Prospective Student",
                    FirstName = "David",
                    LastName = "Sugden",
                    Email = "its4@thomas.edu",
                    Phone = "",
                    Message = "Can I please be a part of your super awesome club?"
                }

            };
            return contacts;

        }*/

    }
}