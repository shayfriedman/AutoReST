using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using AutoReST.Infrastructure;
using AutoReST.Routing;
using AutoReST.Specs.Helpers;
using Machine.Specifications;

namespace AutoReST.Specs.Features
{

    public class DefaultConventions
    {
        Establish context = () =>
        {
            conventions = new ConventionRouting();

            listAction = new ActionInfo() { Controller = "Employee", Name = "List" };
            detailsAction = new ActionInfo() { Controller = "Employee", Name = "Details", Parameters = new List<ActionParam>()
                                                                                                       {
                              
                                                                                                           new ActionParam() { Name = "id"}
                                                                                                       }};
            updateDisplayAction = new ActionInfo()
                                  {
                                      Controller = "Employee",
                                      Name = "Update",
                                      Parameters = new List<ActionParam>()
                                                   {

                                                       new ActionParam() {Name = "id"}
                                                   }
                                  };

            updateAction = new ActionInfo()
                           {
                               Controller = "Employee",
                               Name = "Update",
                               Parameters = new List<ActionParam>()
                                            {

                                                new ActionParam()
                                                {Name = "id", IsComplexType = false},
                                                new ActionParam()
                                                {Name = "employee", IsComplexType = true}
                                                                                                      
                                            }
            };

            createDisplayAction = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Create"};

            createAction = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Create",
                Parameters = new List<ActionParam>()
                                            {

                                                new ActionParam()
                                                {Name = "id", IsComplexType = false},
                                                new ActionParam()
                                                {Name = "Employee", IsComplexType = true}
                                                                                                      
                                            }
            };

        };

        protected static ConventionRouting conventions;
        protected static ActionInfo listAction;
        protected static ActionInfo detailsAction;
        protected static ActionInfo updateDisplayAction;
        protected static ActionInfo updateAction;
        protected static ActionInfo createDisplayAction;
        protected static ActionInfo createAction;
    }

    [Subject("Route Conventions")]
    public class when_getting_information_for_list_action_with_default_conventions: DefaultConventions
    {
        Because of = () =>
        {
            url = conventions.GetRouteUrl(listAction);
            controller = conventions.GetRouteController(listAction);
            action = conventions.GetRouteAction(listAction);
            verb = conventions.GetRouteConstraint(listAction);

        };

        It should_return_url_as_plural_of_controller = () =>
        {
            url.ShouldEqual("Employees");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_list = () =>
        {
            action.ShouldEqual("List");
        };

        It should_return_verb_as_get = () =>
        {
            verb.ShouldEqual(HttpVerbs.Get);
        };


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject("Route Conventions")]
    public class when_getting_information_for_details_action_with_default_conventions : DefaultConventions
    {
        Because of = () =>
        {
            url = conventions.GetRouteUrl(detailsAction);
            controller = conventions.GetRouteController(detailsAction);
            action = conventions.GetRouteAction(detailsAction);
            verb = conventions.GetRouteConstraint(detailsAction);

        };

        It should_return_url_as_controller_with_id_parameter = () =>
        {
            url.ShouldEqual("Employee/{id}");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Details = () =>
        {
            action.ShouldEqual("Details");
        };

        It should_return_verb_as_get = () =>
        {
            verb.ShouldEqual(HttpVerbs.Get);
        };


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject("Route Conventions")]
    public class when_getting_information_for_update_display_action_with_default_conventions : DefaultConventions
    {
        Because of = () =>
        {
            url = conventions.GetRouteUrl(updateDisplayAction);
            controller = conventions.GetRouteController(updateDisplayAction);
            action = conventions.GetRouteAction(updateDisplayAction);
            verb = conventions.GetRouteConstraint(updateDisplayAction);

        };

        It should_return_url_as_controller_with_id_parameter = () =>
        {
            url.ShouldEqual("Employee/edit/{id}");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Update = () =>
        {
            action.ShouldEqual("Update");
        };

        It should_return_verb_as_Get = () =>
        {
            verb.ShouldEqual(HttpVerbs.Get);
        };


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject("Route Conventions")]
    public class when_getting_information_for_update_action_with_default_conventions : DefaultConventions
    {
        Because of = () =>
        {
            url = conventions.GetRouteUrl(updateAction);
            controller = conventions.GetRouteController(updateAction);
            action = conventions.GetRouteAction(updateAction);
            verb = conventions.GetRouteConstraint(updateAction);

        };

        It should_return_url_as_controller_with_id_parameter = () =>
        {
            url.ShouldEqual("Employee/{id}");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Update = () =>
        {
            action.ShouldEqual("Update");
        };

        It should_return_verb_as_Put = () =>
        {
            verb.ShouldEqual(HttpVerbs.Put);
        };


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject("Route Conventions")]
    public class when_getting_information_for_create_display_action_with_default_conventions : DefaultConventions
    {
        Because of = () =>
        {
            url = conventions.GetRouteUrl(createDisplayAction);
            controller = conventions.GetRouteController(createDisplayAction);
            action = conventions.GetRouteAction(createDisplayAction);
            verb = conventions.GetRouteConstraint(createDisplayAction);

        };

        It should_return_url_as_controller_with_id_parameter = () =>
        {
            url.ShouldEqual("Employee/new");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Create = () =>
        {
            action.ShouldEqual("Create");
        };

        It should_return_verb_as_Get = () =>
        {
            verb.ShouldEqual(HttpVerbs.Get);
        };


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }

    [Subject("Route Conventions")]
    public class when_getting_information_for_create_action_with_default_conventions : DefaultConventions
    {
        Because of = () =>
        {
            url = conventions.GetRouteUrl(createAction);
            controller = conventions.GetRouteController(createAction);
            action = conventions.GetRouteAction(createAction);
            verb = conventions.GetRouteConstraint(createAction);

        };

        It should_return_url_as_controller = () =>
        {
            url.ShouldEqual("Employee");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Update = () =>
        {
            action.ShouldEqual("Create");
        };

        It should_return_verb_as_Post = () =>
        {
            verb.ShouldEqual(HttpVerbs.Post);
        };


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }







}