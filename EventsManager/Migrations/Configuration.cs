namespace EventsManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<EventsManager.Models.CalendarEventContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventsManager.Models.CalendarEventContext context)
        {

            var item = new CalendarEvent {
                EventTitle = "SampleEvent",
                EventDescription = "This would be a really cool event to attend",
                 ImageUrl = "http://kimolsen.files.wordpress.com/2008/01/lolcats-funny-picture-lalalalala.jpg",
                 ThumbnailUrl = "http://kimolsen.files.wordpress.com/2008/01/lolcats-funny-picture-lalalalala.jpg",
                 EventDate = DateTime.Now.AddDays(3)
            };

            context.CalendarEvents.AddOrUpdate(item);

            var item2 = new CalendarEvent
            {
                EventTitle = "Sample Event 2",
                EventDescription = "This would be a really cool event to attend",
                ImageUrl = "http://kimolsen.files.wordpress.com/2008/01/lolcats-funny-picture-lalalalala.jpg",
                ThumbnailUrl = "http://kimolsen.files.wordpress.com/2008/01/lolcats-funny-picture-lalalalala.jpg",
                EventDate = DateTime.Now.AddDays(3)
            };

            context.CalendarEvents.AddOrUpdate(item2);
        }
    }
}
