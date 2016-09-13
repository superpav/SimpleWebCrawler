using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Crawler.Domain.Entities
{
	[Table("SearchQuery")]
	public partial class SearchQuery
	{
		public int Id { get; set; }

		[Required]
		public string Query { get; set; }

		public virtual ICollection<SearchResult> SearchResult { get; set; }

		public SearchQuery()
		{
			this.SearchResult = new HashSet<SearchResult>();
		}
	}
}
