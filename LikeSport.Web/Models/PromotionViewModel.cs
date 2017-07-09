using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class PromotionViewModel
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int Percent { get; set; }

     
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

      
        public string CreatedBy { get; set; }

     
        public string ModifiedBy { get; set; }

        public int ActivityInformation_Id { get; set; }

        public virtual ActivityInformationViewModel ActivityInformation { get; set; }
    }
}