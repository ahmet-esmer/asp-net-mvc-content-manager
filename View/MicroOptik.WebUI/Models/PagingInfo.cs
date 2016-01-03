using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroOptik.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string ActionName { get; set; }
        public string TargetDiv { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}