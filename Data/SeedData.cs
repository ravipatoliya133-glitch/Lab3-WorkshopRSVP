using System.Linq;
using Lab3_WorkshopRSVP.Models;

namespace Lab3_WorkshopRSVP.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Rsvps.Any())
            {
                return;
            }

            context.Rsvps.AddRange(
                new Rsvp
                {
                    FullName = "Alice Johnson",
                    NeedsAccommodation = true,
                    WorkshopTitle = "AI Basics"
                },
                new Rsvp
                {
                    FullName = "Bob Smith",
                    NeedsAccommodation = false,
                    WorkshopTitle = "Cloud Computing"
                },
                new Rsvp
                {
                    FullName = "Charlie Brown",
                    NeedsAccommodation = true,
                    WorkshopTitle = "Cybersecurity"
                }
            );

            context.SaveChanges();
        }
    }
}