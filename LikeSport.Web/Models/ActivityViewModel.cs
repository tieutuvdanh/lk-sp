using System;
using System.Collections.Generic;

namespace LikeSport.Web.Models
{
    public class ActivityViewModel
    {
        public int Id { get; set; }


        public string ActivityName { get; set; }
     

        public string State { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public int ActivityGroup_Id { get; set; }

        public virtual ICollection<ActivityInformationViewModel> ActivityInformations { get; set; }

        public virtual ActivityGroupViewModel ActivityGroup { get; set; }
    }
}