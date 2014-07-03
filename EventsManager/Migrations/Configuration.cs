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

            var user1 = new ApprovedUser()
            {
                ValidEmailAddress = "jen.pearson@tal.com.au"
            };

            var user2 = new ApprovedUser()
            {
                ValidEmailAddress = "andrew.wood-rich@tal.com.au"
            };

            context.ApprovedUsers.AddOrUpdate(user1);
            context.ApprovedUsers.AddOrUpdate(user2);

        }
    }
}
