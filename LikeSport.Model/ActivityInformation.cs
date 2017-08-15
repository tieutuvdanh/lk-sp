namespace LikeSport.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("ActivityInformations")]
    public partial class ActivityInformation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivityInformation()
        {
            Promotions = new HashSet<Promotion>();
            Rates = new HashSet<Rate>();
            Reviews = new HashSet<Review>();
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Image { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

   
        public string TagName { get; set; }

        [Required]
        [StringLength(1000)]
        public string WhatWeDo { get; set; }

        [Required]
        [StringLength(1000)]
        public string Views { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CreatedBy { get; set; }

    
        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public int Activity_Id { get; set; }

        public int Service_Id { get; set; }

        //public int UserProfile_Id { get; set; }
        public string UserProfile_Id { get; set; }

        public virtual ApplicationUser Account { get; set; }
        //public virtual Account Account { get; set; }
        public virtual Activity Activity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Promotion> Promotions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rate> Rates { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }

        public virtual Service Service { get; set; }
    }
}
