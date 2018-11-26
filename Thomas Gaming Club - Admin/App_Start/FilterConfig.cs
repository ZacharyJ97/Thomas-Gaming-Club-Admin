using System.Web;
using System.Web.Mvc;

namespace Thomas_Gaming_Club___Admin
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
