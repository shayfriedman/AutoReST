using System.Reflection;
using System.Web.Routing;
using AutoReST.Infrastructure;
using AutoReST.Routing;
using Machine.Specifications;

namespace AutoReST.Specs.Specs
{
    [Subject("Route Generation")]
    public class when_generating_rest_routing_based_on_verbs_given_assembly
    {
        Establish context = () =>
        {
            routeGenerator = new RouteGenerator();

            routes = new RouteCollection();

            assembly = Assembly.GetExecutingAssembly();
        };

        Because of = () =>
        {
            routeGenerator.GenerateRoutesFromAssembly(assembly, routes);
        };

        It should_return_routing_collection_with_rest_routes = () =>
        {
            routes.Count.ShouldEqual(13);
        };

        static RouteCollection routes;
        static RouteGenerator routeGenerator;
        static Assembly assembly;

    }

    
    [Subject("Route Generation")]
    public class when_generating_rest_routing_based_on_verbs_given_assembly_and_custom_namespaces
    {
        Establish context = () =>
        {
            IControllerFinderConfiguration controllerFinderConfiguration = new DefaultControllerFinderConfiguration();

            controllerFinderConfiguration.Namespaces.Add("AutoReST.Specs.Helpers.SpecificNamespace");

            routes = new RouteCollection();

            routeGenerator = new RouteGenerator(new VerbRouting(), new ControllerFinder(controllerFinderConfiguration), new ActionFinder());

            assembly = Assembly.GetExecutingAssembly();
        };

        Because of = () =>
        {
            routeGenerator.GenerateRoutesFromAssembly(assembly, routes);
        };

        It should_return_routing_collection_with_rest_routes = () => routes.Count.ShouldEqual(2);

        static RouteCollection routes;
        static RouteGenerator routeGenerator;
        static Assembly assembly;

    }

    [Subject("Route Generation")]
    public class when_generating_rest_routing_based_on_conventions_given_assembly
    {
        Establish context = () =>
        { 
            routes = new RouteCollection();

            routeGenerator = new RouteGenerator();

            
            assembly = Assembly.GetExecutingAssembly();
        };

        Because of = () =>
        {
          
            routeGenerator.GenerateRoutesFromAssembly(assembly, routes);
        };

        It should_return_routing_collection_with_rest_routes = () => routes.Count.ShouldEqual(13);
 
        static RouteCollection routes;
        static RouteGenerator routeGenerator;
        static Assembly assembly;

    }


}