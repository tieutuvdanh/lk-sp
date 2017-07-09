using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class DeviceViewModel
    {
        public int Id { get; set; }

     
        public string IP { get; set; }

     
        public string BrowserType { get; set; }

  
        public string OS { get; set; }

        public DateTime Time { get; set; }

   
        public string Location { get; set; }
    }
}