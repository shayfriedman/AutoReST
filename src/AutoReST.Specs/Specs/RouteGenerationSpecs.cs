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
            routes.Count.ShouldEqual(12);
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
            IControllerParserConfiguration controllerParserConfiguration = new ControllerParserConfiguration();

            controllerParserConfiguration.Namespaces.Add("AutoReST.Specs.Helpers.SpecificNamespace");

            routes = new RouteCollection();

            routeGenerator = new RouteGenerator(controllerParserConfiguration);

            assembly = Assembly.GetExecutingAssembly();
        };

        Because of = () =>
        {
            routeGenerator.GenerateRoutesFromAssembly(assembly, routes);
        };

        It should_return_routing_collection_with_rest_routes = () => routes.Count.ShouldEqual(1);

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

            routeGenerator = new RouteGenerator(new ConventionRouting());

            
            assembly = Assembly.GetExecutingAssembly();
        };

        Because of = () =>
        {
          
            routeGenerator.GenerateRoutesFromAssembly(assembly, routes);
        };

        It should_return_routing_collection_with_rest_routes = () => routes.Count.ShouldEqual(12);
 
        static RouteCollection routes;
        static RouteGenerator routeGenerator;
        static Assembly assembly;

    }


}