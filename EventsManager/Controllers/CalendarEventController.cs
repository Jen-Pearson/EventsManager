using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using EventsManager.Models;

namespace EventsManager.Controllers
{
    public class CalendarEventController : ApiController
    {
        private CalendarEventContext db = new CalendarEventContext();

        // GET api/CalendarEvent
        public IEnumerable<CalendarEvent> GetCalendarEvents(string q = null, string sort = null, bool desc = false,
                                                        int? limit = null, int offset = 0)
        {
            var list = ((IObjectContextAdapter)db).ObjectContext.CreateObjectSet<CalendarEvent>();

            IQueryable<CalendarEvent> items = string.IsNullOrEmpty(sort) ? list.OrderBy(o => o.EventDate)
                : list.OrderBy(String.Format("it.{0} {1}", sort, desc ? "DESC" : "ASC"));

            items = items.Where(o => o.EventDate > DateTime.Now);

            //figure if we search by anything it would be description
            if (!string.IsNullOrEmpty(q) && q != "undefined") items = items.Where(t => t.EventDescription.Contains(q));

            if (offset > 0) items = items.Skip(offset);
            if (limit.HasValue) items = items.Take(limit.Value);
            return items;
        }

        // GET api/CalendarEvent/5
        public CalendarEvent GetCalendarEvent(int id)
        {
            CalendarEvent calendarevent = db.CalendarEvents.Find(id);
            if (calendarevent == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return calendarevent;
        }

        // PUT api/CalendarEvent/5
        public HttpResponseMessage PutCalendarEvent(int id, CalendarEvent calendarevent)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != calendarevent.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(calendarevent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/CalendarEvent
        public HttpResponseMessage PostCalendarEvent(CalendarEvent calendarevent)
        {
            if (ModelState.IsValid)
            {
                db.CalendarEvents.Add(calendarevent);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, calendarevent);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = calendarevent.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/CalendarEvent/5
        public HttpResponseMessage DeleteCalendarEvent(int id)
        {
            CalendarEvent calendarevent = db.CalendarEvents.Find(id);
            if (calendarevent == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.CalendarEvents.Remove(calendarevent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, calendarevent);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}