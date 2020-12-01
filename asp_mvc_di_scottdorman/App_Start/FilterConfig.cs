using System.Web;
using System.Web.Mvc;

namespace asp_mvc_di_scottdorman
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
