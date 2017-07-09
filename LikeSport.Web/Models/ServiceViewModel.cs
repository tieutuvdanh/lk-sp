using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

     
        public string NameType { get; set; }

     
        public string State { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

      
        public string CreatedBy { get; set; }

      
        public string ModifiedBy { get; set; }

        public virtual ICollection<ActivityInformationViewModel> ActivityInformations { get; set; }
    }
}