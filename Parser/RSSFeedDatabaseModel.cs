namespace Parser
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RSSFeedDatabaseModel : DbContext
    {
        public RSSFeedDatabaseModel()
            : base("name=RSSFeedDatabaseModelEntities")
        {
        }

        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<Feed> Feed { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Channel>()
                .HasMany(e => e.Feed)
                .WithRequired(e => e.Channel)
                .WillCascadeOnDelete(false);
        }
    }
}
