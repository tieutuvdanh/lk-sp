using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class ActivityGroupViewModel
    {
        public int Id { get; set; }

      
        public string ActivityGroupName { get; set; }

 
        public string State { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

  
        public string CreatedBy { get; set; }


        public string ModifiedBy { get; set; }

        public virtual ICollection<ActivityViewModel> Activities { get; set; }
    }
}