using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class ActivityInformationViewModel
    {
        public int Id { get; set; }

      
        public string Title { get; set; }

        public string Image { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string TagName { get; set; }

 
        public string WhatWeDo { get; set; }

        public string Views { get; set; }


        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        public string CreatedBy { get; set; }

 
        public string ModifiedBy { get; set; }

        public int Activity_Id { get; set; }

        public int Service_Id { get; set; }

        public string UserProfile_Id { get; set; }

        public virtual ApplicationUserViewModel Account { get; set; }

        public virtual ActivityViewModel Activity { get; set; }

        public virtual ICollection<PromotionViewModel> Promotions { get; set; }


        public virtual ICollection<RateViewModel> Rates { get; set; }


        public virtual ICollection<ReviewViewModel> Reviews { get; set; }


        public virtual ICollection<AddressViewModel> Addresses { get; set; }

        public virtual ServiceViewModel Service { get; set; }
    }
}