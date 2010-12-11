using System.Collections.Generic;
using System.Web.Mvc;
using AutoReST.Infrastructure;
using AutoReST.Routing;
using Machine.Specifications;

namespace AutoReST.Specs.Features
{
    [Subject("Route Mapping")]
    public class when_generating_verb_route_for_actionInfo_with_single_parameter
    {
        Establish context = () =>
        {
            actionInfo = new ActionInfo();

            actionInfo.Name = "Details";
            actionInfo.Controller = "Customer";
            actionInfo.Verb = HttpVerbs.Get;
            actionInfo.Parameters = new List<ActionParam> {new ActionParam {Name = "id"}};

            routing = new VerbRouting();
        };

        Because of = () =>
        {
            url = routing.GetRouteUrl(actionInfo);
        };

        It should_return_url_with_single_parameter = () =>
        {
            url.ShouldEqual("Customer/{id}");
        };

        static IRouting routing;
        static string url;
        static ActionInfo actionInfo;

    }

    [Subject("Route Mapping")]
    public class when_generating_verb_route_for_actionInfo_with_two_parameters
    {
        Establish context = () =>
        {
            actionInfo = new ActionInfo();

            actionInfo.Name = "Details";
            actionInfo.Controller = "Customer";
            actionInfo.Verb = HttpVerbs.Get;
            actionInfo.Parameters = new List<ActionParam>
                                    {
                                        new ActionParam {Name = "section"},
                                        new ActionParam {Name = "id"}
                                    };

            routing = new VerbRouting();
        };

        Because of = () =>
        {
            url = routing.GetRouteUrl(actionInfo);
        };

        It should_return_url_with_two_parameters = () =>
        {
            url.ShouldEqual("Customer/{section}/{id}");
        };

        static IRouting routing;
        static string url;
        static ActionInfo actionInfo;

    }

    [Subject("Route Mapping")]
    public class when_generating_verb_route_for_actionInfo_with_complex_parameter
    {
        Establish context = () =>
        {
            actionInfo = new ActionInfo();

            actionInfo.Name = "Details";
            actionInfo.Controller = "Customer";
            actionInfo.Verb = HttpVerbs.Get;
            actionInfo.Parameters = new List<ActionParam>
                                    {
                                        new ActionParam
                                        {Name = "customerRecord", IsComplexType = true}
                                    };

            routing = new VerbRouting();
        };

        Because of = () =>
        {
            url = routing.GetRouteUrl(actionInfo);
        };

        It should_return_url_ignoring_complex_param = () =>
        {
            url.ShouldEqual("Customer");
        };

        static string url;
        static ActionInfo actionInfo;
        static IRouting routing;

    }


    [Subject("Route Mapping")]
    public class when_generating_convention_route_for_actionInfo_with_single_parameter
    {
        Establish context = () =>
        {
            actionInfo = new ActionInfo();

            actionInfo.Name = "Details";
            actionInfo.Controller = "Customer";
            actionInfo.Verb = HttpVerbs.Get;
            actionInfo.Parameters = new List<ActionParam>
                                    {
                                        new ActionParam
                                        {Name = "customerRecord", IsComplexType = true}
                                    };

            routing = new ConventionRouting();
        };

        Because of = () =>
        {
            url = routing.GetRouteUrl(actionInfo);
        };

        It should_return_url_ignoring_complex_param = () =>
        {
            url.ShouldEqual("Customer");
        };

        static string url;
        static ActionInfo actionInfo;
        static IRouting routing;

    }
}