namespace LikeSport.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("Device")]
    public partial class Device
    {
        public int Id { get; set; }

        [Required]
        public string IP { get; set; }

        [StringLength(50)]
        public string BrowserType { get; set; }

        [StringLength(50)]
        public string OS { get; set; }

        public DateTime Time { get; set; }

        [StringLength(500)]
        public string Location { get; set; }
    }
}
