using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace MVC_Tuincentrum2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            var constraintsResolver = new DefaultInlineConstraintResolver(); 
            constraintsResolver.ConstraintMap.Add("values", typeof(ValuesConstraint)); 
            routes.MapMvcAttributeRoutes(constraintsResolver);
            //routes.MapMvcAttributeRoutes();  Deze moete we hemme...

            routes.MapRoute(
                "PlantByNr",
                "Plant/{id}",
                 new { controller = "Planten", action = "Details" },
                 new { id = new IntRouteConstraint() });

            routes.MapRoute(
                "PlantenVanEenSoort",
                "soort/{soortnaam}/planten",
                new { controller = "Planten", action = "FindPlantenBySoortNaam" },
                new {
                    soortnaam = new CompoundRouteConstraint(new List<IRouteConstraint> {
                        new AlphaRouteConstraint(),
                        new MinLengthRouteConstraint(3),
                        new MaxLengthRouteConstraint(10)})
            });

            routes.MapRoute(
                "Alleplanten",
                "Plantenlijst",
                new { controller = "Planten", action = "Index" });

            
            routes.MapRoute(
                "PlantenVanEenLeverancier",
                "leverancier/{levnr}/planten",
                new { controller = "Planten", action = "FindPlantenByLeverancier" },
                new { levnr = new MaxRouteConstraint(10) });


            //WTF is dees 
            //  ./planten?minprijs=0&maxprijs=7
            routes.MapRoute(
                "FindPlantenByPrijsBetween", 
                "planten", 
                new { controller = "Planten", action = "FindPlantenBetweenPrijzen" }, 
                new {
                    QueryConstraint = new QueryStringConstraint(
                        new string[] { "minprijs", "maxprijs" }) });
            routes.MapRoute(
                "FindPlantenByKleur", 
                "planten", 
                new { controller = "Planten", action = "FindPlantenVanEenKleur" }, 
                new {
                    QueryConstraint = new QueryStringConstraint( new string[] { "kleur" }) } //zelfgemaakte class
            );
            //WTF is dees Einde

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
