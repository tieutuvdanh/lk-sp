namespace LikeSport.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Feebacks")]
    public partial class Feeback
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(500)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

   
        public string Reply { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public int UserProfile_Id { get; set; }

        public virtual Account Account { get; set; }
    }
}
