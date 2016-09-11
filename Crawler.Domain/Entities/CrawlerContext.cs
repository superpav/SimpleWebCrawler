using System.Data.Entity;

namespace Crawler.Domain.Entities
{
	public partial class CrawlerContext : DbContext
	{
		public virtual DbSet<SearchQuery> SearchQuery { get; set; }
		public virtual DbSet<SearchResult> SearchResult { get; set; }

		public CrawlerContext() : base("name=Crawler")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SearchQuery>()
				.HasMany(e => e.SearchResult)
				.WithRequired(e => e.SearchQuery)
				.WillCascadeOnDelete(false);
		}
	}
}