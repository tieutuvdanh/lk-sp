using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class RateViewModel
    {
        public int Id { get; set; }

       
        public string Rated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

     
        public string CreatedBy { get; set; }

   
        public string ModifiedBy { get; set; }

        public int ActivityInformation_Id { get; set; }

        public virtual ActivityInformationViewModel ActivityInformation { get; set; }
    }
}