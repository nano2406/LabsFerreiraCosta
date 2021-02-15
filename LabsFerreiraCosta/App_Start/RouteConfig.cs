using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LabsFerreiraCosta {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "usuario_editar",
            //    "usuario/{id}/editar",
            //    new { Controller = "home", Action = "about", id = 0}
            //    );

            //routes.MapRoute(
            //    "Sobre",
            //    "Sobre",
            //    new { Controller = "Home", Action = "about" }
            //    );

            //routes.MapRoute(
            //  "Contato",
            //  "Contato",
            //  new { Controller = "Home", Action = "contact" }
            //  );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Usuario", action = "Pesquisar", id = UrlParameter.Optional }
            );
        }
    }
}
