using System.Web;
using System.Web.Mvc;

namespace Projektni_centar_zadatak
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
