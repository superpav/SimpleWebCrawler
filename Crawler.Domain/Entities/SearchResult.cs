using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crawler.Domain.Entities
{
	[Table("SearchResult")]
	public partial class SearchResult
	{
		public int Id { get; set; }

		public int SearchQueryId { get; set; }

		public SearchEngineType SearchEngineType { get; set; }

		[Required]
		public string Link { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Description { get; set; }

		public virtual SearchQuery SearchQuery { get; set; }
	}
}
