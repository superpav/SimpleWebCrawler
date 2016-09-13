using System.ComponentModel.DataAnnotations;

namespace Crawler.Web.ViewModels
{
	public class SearchFormModel
	{
		[Required(ErrorMessage = "Необходимо указать слово для поиска")]
		public string Query { get; set; }
	}
}