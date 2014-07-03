using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace EventsManager.Models
{
    public class ApprovedUser
    {
        public int Id { get; set; }
        public string ValidEmailAddress { get; set; }
    }
}