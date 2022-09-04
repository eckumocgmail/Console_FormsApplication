using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeleReportsDataProvider.Views.Shared.Components.Search
{
    [EntityIcon("search")]
    [EntityLabel("Поисковый запрос")]
    public class SearchRequest: BaseEntity
    {
        [Icon("search")]
        [Label("Поисковое выражение")]
        [NotNullNotEmpty("Необходимо задать полисковое выражение")]
        public string query { get; set; }


        [Label("Номер страницы")]
        [NotNullNotEmpty("Необходимо указать номер страницы")]
        public string page { get; set; }


        [Label("Размер страницы")]
        [NotNullNotEmpty("Необходимо указать размер страницы")]
        public string size { get; set; }

        public static object FromDictionary(Dictionary<string, object> dictionary)
        {
            return ReflectionService.CopyValuesFromDictionary(new SearchRequest(), dictionary);
        }

     
    }
}
