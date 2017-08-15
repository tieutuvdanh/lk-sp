using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class ChatInformationViewModel
    {
        public int Id { get; set; }

     
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

      
        public string CreatedBy { get; set; }

        public string Account_Id { get; set; }

        public virtual ApplicationUserViewModel Account { get; set; }
    }
}