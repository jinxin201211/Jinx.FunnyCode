using System.Web;
using System.Web.Mvc;

namespace Jinx.J002.FrontEndZone
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
