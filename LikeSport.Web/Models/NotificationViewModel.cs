using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class NotificationViewModel
    {
        public int Id { get; set; }

       
        public string Type { get; set; }

      
        public string Content { get; set; }

     
        public string Title { get; set; }

       
        public string Image { get; set; }

     
        public string SenderName { get; set; }

       
        public string ReceiverName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

      
        public string CreatedBy { get; set; }

      
        public string ModifiedBy { get; set; }

        public string UserProfile_Id { get; set; }

        public virtual ApplicationUserViewModel Account { get; set; }
    }
}