namespace LikeSport.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Rates")]
    public partial class Rate
    {
        public int Id { get; set; }

        [Required]
        public string Rated { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string ModifiedBy { get; set; }

        public int ActivityInformation_Id { get; set; }

        public virtual ActivityInformation ActivityInformation { get; set; }
    }
}
