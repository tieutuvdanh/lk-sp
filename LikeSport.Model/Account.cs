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
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        public DateTime BirthOfDate { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Hobby { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string LoginType { get; set; }

        [Required]
        public string Photo { get; set; }

        [Required]
        public string FacebookId { get; set; }

        [Required]
        public string TwitterId { get; set; }

        [Required]
        public string GoogleId { get; set; }

        [Required]
        public string TypeAccount { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string PhoneNumberOrganization { get; set; }

        [Required]
        public string PhotoOrganization { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
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