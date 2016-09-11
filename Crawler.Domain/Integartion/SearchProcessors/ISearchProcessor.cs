using System.Threading.Tasks;
using Crawler.Domain.Integartion.SearchEngines;

namespace Crawler.Domain.Integartion.SearchProcessors
{
	public interface ISearchProcessor
	{
		Task<SearchEngineResult> SearchAsync(string query);
	}
}
