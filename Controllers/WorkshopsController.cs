using Microsoft.AspNetCore.Mvc;
using Lab3_WorkshopRSVP.Models;
using Lab3_WorkshopRSVP.Data;
using System.Linq;

namespace Lab3_WorkshopRSVP.Controllers
{
    public class WorkshopsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkshopsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Workshops
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Workshops/RsvpForm
        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View(new Rsvp());
        }

        // POST: /Workshops/Confirm
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Confirm(Rsvp model)
        {
            // Simple validation
            if (string.IsNullOrWhiteSpace(model.FullName) || string.IsNullOrWhiteSpace(model.WorkshopTitle))
            {
                ModelState.AddModelError("", "Please enter your name and select a workshop.");
                return View("RsvpForm", model);
            }

            // For Lab 4, form submissions do not need to be saved to DB yet
            ViewData["Message"] = $"Thanks for registering, {model.FullName}!";

            return View(model);
        }

        // GET: /Workshops/Registrations
        public IActionResult Registrations()
        {
            var registrations = _context.Rsvps.ToList();
            return View(registrations);
        }
    }
}