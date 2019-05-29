using System.Web;
using System.Web.Mvc;
using Aghsat.UI.Classes;

namespace Aghsat.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TitleAndIconFilter());

        }
    }
}
