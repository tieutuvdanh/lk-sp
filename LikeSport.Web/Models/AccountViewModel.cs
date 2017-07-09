using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class AccountViewModel
    {
        public int Id { get; set; }

      
        public string FirstName { get; set; }

      
        public string LastName { get; set; }


        public string Gender { get; set; }

        public DateTime BirthOfDate { get; set; }

  
        public string EmailAddress { get; set; }

 
        public string Hobby { get; set; }


        public string PhoneNumber { get; set; }

  
        public string LoginType { get; set; }


        public string Photo { get; set; }

  
        public string FacebookId { get; set; }

  
        public string TwitterId { get; set; }

  
        public string GoogleId { get; set; }

 
        public string TypeAccount { get; set; }

    
        public string BusinessName { get; set; }


        public string ContactName { get; set; }

    
        public string PhoneNumberOrganization { get; set; }


        public string PhotoOrganization { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }


        public string CreatedBy { get; set; }


        public string ModifiedBy { get; set; }

        public virtual ICollection<ChatInformationViewModel> ChatInformations { get; set; }

        public virtual ICollection<ActivityInformationViewModel> ActivityInformations { get; set; }

        public virtual ICollection<AddressViewModel> Addresses { get; set; }

        public virtual ICollection<FeebackViewModel> Feebacks { get; set; }

        public virtual ICollection<NotificationViewModel> Notifications { get; set; }
    }
}