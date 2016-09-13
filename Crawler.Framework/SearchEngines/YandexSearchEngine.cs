using Crawler.Domain.Entities;

namespace Crawler.Framework.SearchEngines
{
	public class YandexSearchEngine : SearchEngineBase
	{
		protected override string SearchUrl => "https://www.yandex.ru/search?text={0}";
		public override SearchEngineType EngineType => SearchEngineType.Yandex;
	}
}
