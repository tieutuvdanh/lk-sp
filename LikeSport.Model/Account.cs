using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace LikeSport.Model
{
    [Table("Accounts")]
    public class Account
    {
        [SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            ChatInformations = new HashSet<ChatInformation>();
            ActivityInformations = new HashSet<ActivityInformation>();
            Addresses = new HashSet<Address>();
            Feebacks = new HashSet<Feeback>();
            Notifications = new HashSet<Notification>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Gender { get; set; }

        public DateTime BirthOfDate { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailAddress { get; set; }

     
        public string Hobby { get; set; }

        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginType { get; set; }

        [StringLength(1000)]
        public string Photo { get; set; }

        [StringLength(100)]
        public string FacebookId { get; set; }

        [StringLength(100)]
        public string TwitterId { get; set; }

        [StringLength(100)]
        public string GoogleId { get; set; }

        [StringLength(100)]
        public string TypeAccount { get; set; }

        [StringLength(100)]
        public string BusinessName { get; set; }

        [StringLength(100)]
        public string ContactName { get; set; }

        [StringLength(50)]
        public string PhoneNumberOrganization { get; set; }

        [StringLength(1000)]
        public string PhotoOrganization { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

     
        public string CreatedBy { get; set; }

  
        public string ModifiedBy { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatInformation> ChatInformations { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityInformation> ActivityInformations { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Addresses { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feeback> Feebacks { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}