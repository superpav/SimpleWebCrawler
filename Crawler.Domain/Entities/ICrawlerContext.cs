using System.Data.Entity;
using System.Threading.Tasks;

namespace Crawler.Domain.Entities
{
	public interface ICrawlerContext
	{
		DbSet<SearchQuery> SearchQuery { get; set; }
		DbSet<SearchResult> SearchResult { get; set; }
		Task<int> SaveChangesAsync();
	}
}