namespace Lab3_WorkshopRSVP.Models
{
    public class Rsvp
    {
        // Primary key for EF Core
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        // checkbox in the form
        public bool NeedsAccommodation { get; set; }

        // dropdown selection in the form
        public string WorkshopTitle { get; set; } = string.Empty;
    }
}