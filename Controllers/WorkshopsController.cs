using Microsoft.AspNetCore.Mvc;
using Lab3_WorkshopRSVP.Models;

namespace Lab3_WorkshopRSVP.Controllers
{
    public class WorkshopsController : Controller
    {
        // In-memory list of registrations (static so it persists while the app is running)
        private static readonly List<Rsvp> _registrations = new List<Rsvp>();

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
            // Simple validation (optional but helps avoid blank submissions)
            if (string.IsNullOrWhiteSpace(model.FullName) || string.IsNullOrWhiteSpace(model.WorkshopTitle))
            {
                ModelState.AddModelError("", "Please enter your name and select a workshop.");
                return View("RsvpForm", model);
            }

            // Save to in-memory list
            _registrations.Add(model);

            // Required ViewData message
            ViewData["Message"] = $"Thanks for registering, {model.FullName}!";

            // Required: strongly typed view with View(model)
            return View(model);
        }

        // GET: /Workshops/Registrations
        public IActionResult Registrations()
        {
            return View(_registrations);
        }
    }
}
