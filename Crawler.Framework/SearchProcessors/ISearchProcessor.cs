using System.Threading.Tasks;
using Crawler.Framework.SearchEngines;

namespace Crawler.Framework.SearchProcessors
{
	public interface ISearchProcessor
	{
		Task<SearchEngineResult> SearchAsync(string query);
	}
}
