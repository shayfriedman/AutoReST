using System;
using System.Collections.Generic;
using System.Web.Mvc;
using AutoReST.Infrastructure;
using AutoReST.Routing;
using Machine.Specifications;

namespace AutoReST.Specs.Specs
{

    public class DefaultConventionsSpecs
    {
        Establish context = () =>
        {
            conventionRouting = new ConventionRouting(new DefaultRouteConventions());

            listAction = new ActionInfo() { Controller = "Employee", Name = "List" };

            detailsAction = new ActionInfo() { Controller = "Employee", Name = "Details", Parameters = new List<ActionParam>()
                                                                                                       {
                              
                                                                                                           new ActionParam() { Name = "id"}
                                                                                                       }};

            deleteAction = new ActionInfo() { Controller = "Employee", Name = "Delete", Parameters = new List<ActionParam>()
                                                                                                       {
                              
                                                                                                           new ActionParam() { Name = "id"}
                                                                                                       }};
            editDisplayAction = new ActionInfo()
                                  {
                                      Controller = "Employee",
                                      Name = "Edit",
                                      Parameters = new List<ActionParam>()
                                                   {

                                                       new ActionParam() {Name = "id"}
                                                   }
                                  };

            editAction = new ActionInfo()
                           {
                               Controller = "Employee",
                               Name = "Edit",
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
        protected static ActionInfo editDisplayAction;
        protected static ActionInfo editAction;
        protected static ActionInfo createDisplayAction;
        protected static ActionInfo createAction;
        protected static ActionInfo deleteAction;
    }

    [Subject("Route Conventions")]
    public class when_getting_information_for_list_action_with_default_conventions: DefaultConventionsSpecs
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
    public class when_getting_information_for_details_action_with_default_conventions : DefaultConventionsSpecs
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
    public class when_getting_information_for_Edit_display_action_with_default_conventions : DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(editDisplayAction);
            controller = conventionRouting.GetRouteController(editDisplayAction);
            action = conventionRouting.GetRouteAction(editDisplayAction);
            verb = conventionRouting.GetRouteConstraint(editDisplayAction);

        };

        It should_return_url_as_controller_with_id_parameter = () =>
        {
            url.ShouldEqual("Employee/edit/{id}");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Edit = () =>
        {
            action.ShouldEqual("Edit");
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
    public class when_getting_information_for_edit_action_with_default_conventions : DefaultConventionsSpecs
    {
        Because of = () =>
        {
            url = conventionRouting.GetRouteUrl(editAction);
            controller = conventionRouting.GetRouteController(editAction);
            action = conventionRouting.GetRouteAction(editAction);
            verb = conventionRouting.GetRouteConstraint(editAction);

        };

        It should_return_url_as_controller_with_id_parameter = () =>
        {
            url.ShouldEqual("Employee/{id}");
        };

        It should_return_controller_as_name_of_controller = () =>
        {
            controller.ShouldEqual("Employee");
        };

        It should_return_action_Edit = () =>
        {
            action.ShouldEqual("Edit");
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
    public class when_getting_information_for_create_display_action_with_default_conventions : DefaultConventionsSpecs
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
    public class when_getting_information_for_create_action_with_default_conventions : DefaultConventionsSpecs
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
    public class when_getting_information_for_delete_action_with_default_conventions : DefaultConventionsSpecs
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
    public class when_getting_url_for_non_existent_action_with_default_conventions: DefaultConventionsSpecs
    {
 
        Because of = () =>
        {

            nonExistentAction = new ActionInfo() { Controller = "Employee", Name = "DoesNotExist" };

            exception = Catch.Exception(() => conventionRouting.GetRouteUrl(nonExistentAction));
            
        };

        It should_return_mapping_not_found_exception = () =>
        {
            exception.ShouldBeOfType(typeof(MappingException));
        };

        It should_return_exception_message_with_controller_action_and_parameters = () =>
        {

            exception.Message.ShouldEqual(
                String.Format(
                    "Mapping for {0}.{1} with {2} parameters not found. Make sure you have your Conventions correctly in place",
                    nonExistentAction.Controller, nonExistentAction.Name, 0));
        };

        It should_return_actionInfo_with_correct_controller_and_action = () =>
        {
            var actionInfo = ((MappingException) exception).ActionInfo;
            
            actionInfo.Name.ShouldEqual("DoesNotExist");
            actionInfo.Controller.ShouldEqual("Employee");
        };
        static Exception exception;
        static ActionInfo nonExistentAction;
    }

    [Subject("Route Conventions")]
    public class when_getting_url_for_action_with_mismatched_parameters_with_default_conventions: DefaultConventionsSpecs
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

    [Subject("Route Conventions")]
    public class when_getting_url_for_action_with_convention_with_three_mappings_of_same_action_name
    {

        Establish context = () =>
        {

            var conventions = new RouteConventions();

            conventions.MapAction("Edit").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "id" } }


                ).ToCustomUrl("/edit").ConstraintToVerb(HttpVerbs.Get);

            conventions.MapAction("Edit").WithParameters(
                new List<ActionParam>() { new ActionParam() { IsComplexType = false, Name = "date" } }


                ).ToCustomUrl("/edit").ConstraintToVerb(HttpVerbs.Get);

            conventions.MapAction("Edit").WithParameters(
                new List<ActionParam>()
                {
                    new ActionParam() { IsComplexType = false, Name = "id"},
                    new ActionParam() { IsComplexType = true, Name = "data"}
                }


                ).ToRoot().ConstraintToVerb(HttpVerbs.Put);

            action = new ActionInfo()
            {
                Controller = "Employee",
                Name = "Edit",
                Parameters = new List<ActionParam>()
                                                   {

                                                       new ActionParam() {Name = "date"}
                                                   }
            };


            routingConvention = new ConventionRouting(conventions);

        };
        Because of = () =>
        {
            url = routingConvention.GetRouteUrl(action);
        };

        
        It should_return_mapping_not_found_exception = () =>
        {
            url.ShouldEqual("Employee/edit/{date}");
        };
        static Exception exception;
        static string url;
        static ConventionRouting routingConvention;
        static ActionInfo action;
    }




}