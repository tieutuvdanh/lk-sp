namespace LikeSport.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("ChatInformations")]
    public partial class ChatInformation
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public int Account_Id { get; set; }

        public virtual Account Account { get; set; }
    }
}
