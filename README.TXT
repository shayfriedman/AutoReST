Distributed under BSD License. See LICENSE.TXT for full license

[PLEASE NOTE THAT THIS HAS NOT BEEN TESTED IN FULL PRODUCTION YET. USE AT YOUR OWN WILL. IT'S STILL EVOLVING]

*AutoReST*


Add some ReST flavors to MVC Applications:

Currently Support:

- Routing Based on Verbs
- Routing Based on Conventions

Issue tracker is: http://youtrack.codebetter.com/issues/AREST



Generate ReST routes for your MVC Application automatically.

Create your controllers and set the correct verbs. Call the following in your RegisterRoutes:


            var routeGenerator = new RestRouteGenerator();

            routeGenerator.GenerateRoutesFromAssemblyAssembly.GetExecutingAssembly(), routes));


like so:

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

         
            var routeGenerator = new RestRouteGenerator();

            routeGenerator.GenerateRoutesFromAssemblyAssembly.GetExecutingAssembly(), routes));

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
      


AutoReST will do the rest (no pun intended)

You can now access your controllers use GET, PUT, DELETE, POST without any manual mapping.

