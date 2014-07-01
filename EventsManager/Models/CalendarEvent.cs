using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsManager.Models
{
    public class CalendarEvent
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public DateTime EventDate { get; set; }
        public string ThumbnailUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}