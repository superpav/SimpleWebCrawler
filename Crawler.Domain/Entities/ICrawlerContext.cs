using System.Data.Entity;

namespace Crawler.Domain.Entities
{
	public interface ICrawlerContext
	{
		DbSet<SearchQuery> SearchQuery { get; set; }
		DbSet<SearchResult> SearchResult { get; set; }
		int SaveChanges();
	}
}