using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }

      
        public string Street { get; set; }

      
        public string City { get; set; }

    
        public string PostalCode { get; set; }

     
        public string State { get; set; }

     
        public string Country { get; set; }

  
        public string MapInfor { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

    
        public string ModifiedBy { get; set; }

        public string UserProfile_Id { get; set; }

        public int ActivityInformations_Id { get; set; }

        public virtual ApplicationUserViewModel Account { get; set; }

        public virtual ActivityInformationViewModel ActivityInformation { get; set; }
    }
}