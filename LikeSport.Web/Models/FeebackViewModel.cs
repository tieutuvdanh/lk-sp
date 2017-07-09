using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LikeSport.Web.Models
{
    public class FeebackViewModel
    {
        public int Id { get; set; }

      
        public string Type { get; set; }

        
        public string Title { get; set; }

    
        public string Content { get; set; }

   
        public string Reply { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

      
        public string CreatedBy { get; set; }

   
        public string ModifiedBy { get; set; }

        public int UserProfile_Id { get; set; }

        public virtual AccountViewModel Account { get; set; }
    }
}