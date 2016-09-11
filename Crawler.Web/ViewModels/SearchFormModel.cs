using System.ComponentModel.DataAnnotations;

namespace Crawler.Web.ViewModels
{
	public class SearchFormModel
	{
		[Required]
		public string Query { get; set; }
	}
}