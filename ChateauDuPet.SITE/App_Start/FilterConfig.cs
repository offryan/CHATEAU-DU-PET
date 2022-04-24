using System.Web;
using System.Web.Mvc;

namespace ChateauDuPet.SITE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
