using System;
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
            conventionRouting = new ConventionRouting();

            listAction = new ActionInfo() { Controller = "Employee", Name = "List" };

            detailsAction = new ActionInfo() { Controller = "Employee", Name = "Details", Parameters = new List<ActionParam>()
                                                                                                       {
                              
                                                                                                           new ActionParam() { Name = "id"}
                                                                                                       }};

            deleteAction = new ActionInfo() { Controller = "Employee", Name = "Delete", Parameters = new List<ActionParam>()
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
                                                {Name = "data", IsComplexType = true}
                                                                                                      
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
                                                {Name = "data", IsComplexType = true}
                                                                                                      
                                            }
            };

        };

        protected static ConventionRouting conventionRouting;
        protected static ActionInfo listAction;
        protected static ActionInfo detailsAction;
        protected static ActionInfo updateDisplayAction;
        protected static ActionInfo updateAction;
        protected static ActionInfo createDisplayAction;
        protected static ActionInfo createAction;
        protected static ActionInfo deleteAction;
    }

    [Subject("Route Conventions")]
    public class when_getting_information_for_list_action_with_default_conventions: DefaultConventions
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(listAction);
            controller = conventionRouting.GetRouteController(listAction);
            action = conventionRouting.GetRouteAction(listAction);
            verb = conventionRouting.GetRouteConstraint(listAction);

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
            url = conventionRouting.GetRouteUrl(detailsAction);
            controller = conventionRouting.GetRouteController(detailsAction);
            action = conventionRouting.GetRouteAction(detailsAction);
            verb = conventionRouting.GetRouteConstraint(detailsAction);

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
            url = conventionRouting.GetRouteUrl(updateDisplayAction);
            controller = conventionRouting.GetRouteController(updateDisplayAction);
            action = conventionRouting.GetRouteAction(updateDisplayAction);
            verb = conventionRouting.GetRouteConstraint(updateDisplayAction);

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
            url = conventionRouting.GetRouteUrl(updateAction);
            controller = conventionRouting.GetRouteController(updateAction);
            action = conventionRouting.GetRouteAction(updateAction);
            verb = conventionRouting.GetRouteConstraint(updateAction);

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
            url = conventionRouting.GetRouteUrl(createDisplayAction);
            controller = conventionRouting.GetRouteController(createDisplayAction);
            action = conventionRouting.GetRouteAction(createDisplayAction);
            verb = conventionRouting.GetRouteConstraint(createDisplayAction);

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
            url = conventionRouting.GetRouteUrl(createAction);
            controller = conventionRouting.GetRouteController(createAction);
            action = conventionRouting.GetRouteAction(createAction);
            verb = conventionRouting.GetRouteConstraint(createAction);

        };

        It should_return_url_as_controller = () =>
        {
            url.ShouldEqual("Employee");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Create = () =>
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

    [Subject("Route Conventions")]
    public class when_getting_information_for_delete_action_with_default_conventions : DefaultConventions
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(deleteAction);
            controller = conventionRouting.GetRouteController(deleteAction);
            action = conventionRouting.GetRouteAction(deleteAction);
            verb = conventionRouting.GetRouteConstraint(deleteAction);

        };

        It should_return_url_as_controller_with_id_parameter = () =>
        {
            url.ShouldEqual("Employee/{id}");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Delete = () =>
        {
            action.ShouldEqual("Delete");
        };

        It should_return_verb_as_get = () =>
        {
            verb.ShouldEqual(HttpVerbs.Delete);
        };


        static string url;
        static string controller;
        static string action;
        static HttpVerbs verb;
    }


    [Subject("Route Conventions")]
    public class when_getting_url_for_non_existent_action_with_default_conventions: DefaultConventions
    {
 
        Because of = () =>
        {

            var nonExistentAction = new ActionInfo() { Controller = "Employee", Name = "DoesNotExist" };

            exception = Catch.Exception(() => conventionRouting.GetRouteUrl(nonExistentAction));
            
        };

        It should_return_mapping_not_found_exception = () =>
        {
            exception.ShouldBeOfType(typeof(MappingException));

            var actionInfo = ((MappingException) exception).ActionInfo;
            
            actionInfo.Name.ShouldEqual("DoesNotExist");
            actionInfo.Controller.ShouldEqual("Employee");
        };
        static Exception exception;
    }

    [Subject("Route Conventions")]
    public class when_getting_url_for_action_with_mismatched_parameters_with_default_conventions: DefaultConventions
    {
 
        Because of = () =>
        {

            var nonExistentAction = new ActionInfo() { Controller = "Employee", Name = "Update" };

            exception = Catch.Exception(() => conventionRouting.GetRouteUrl(nonExistentAction));

        };

        It should_return_mapping_not_found_exception = () =>
        {
            exception.ShouldBeOfType(typeof(MappingException));

            var actionInfo = ((MappingException)exception).ActionInfo;

            actionInfo.Name.ShouldEqual("Update");
            actionInfo.Controller.ShouldEqual("Employee");
        };
        static Exception exception;
    }




}