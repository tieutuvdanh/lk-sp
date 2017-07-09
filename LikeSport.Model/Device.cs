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

        [Required]
        public string BrowserType { get; set; }

        [Required]
        public string OS { get; set; }

        public DateTime Time { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
