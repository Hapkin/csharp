using MVC_Tuincentrum2.Filters;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tuincentrum2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new Filters.StatistiekActionFilter());
            /*
            StatistiekActionFilter mijnStatistiekActionFilter = new StatistiekActionFilter();
            mijnStatistiekActionFilter.Order = 1;
            //AndereActionFilter mijnAndereActionFilter = new AndereActionFilter();
            //mijnAndereActionFilter.Order = 2;
            filters.Add(mijnStatistiekActionFilter);
            //filters.Add(mijnAndereActionFilter);
            */
        }
    }
}
