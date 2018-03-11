namespace Parser
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feed")]
    public partial class Feed
    {
        public int FeedID { get; set; }

        public int ChannelID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Date { get; set; }

        public string Imagelink { get; set; }

        public virtual Channel Channel { get; set; }
    }
}
