using MVC_Tuincentrum2.Filters;
using System.Data.Entity.Core;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tuincentrum2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // DB errorhandeling
            HandleErrorAttribute myHandleErrorAttribute = new HandleErrorAttribute();
            myHandleErrorAttribute.View = "DatabaseError";
            myHandleErrorAttribute.ExceptionType = typeof(EntityException);
            myHandleErrorAttribute.Order = 1;
            filters.Add(myHandleErrorAttribute);
            filters.Add(new HandleErrorAttribute());
            //*/



            filters.Add(new HandleErrorAttribute());
            //filters.Add(new Filters.StatistiekActionFilter());

            StatistiekActionFilter mijnStatistiekActionFilter = new StatistiekActionFilter();
            mijnStatistiekActionFilter.Order = 1;
            //AndereActionFilter mijnAndereActionFilter = new AndereActionFilter();
            //mijnAndereActionFilter.Order = 2;
            filters.Add(mijnStatistiekActionFilter);
            //filters.Add(mijnAndereActionFilter);

        }
    }
}
