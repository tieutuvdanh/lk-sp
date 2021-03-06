namespace LikeSport.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Promotions")]
    public partial class Promotion
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        public int Percent { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public int ActivityInformation_Id { get; set; }

        public virtual ActivityInformation ActivityInformation { get; set; }
    }
}
