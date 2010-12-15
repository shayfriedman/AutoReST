using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using AutoReST.Infrastructure;
using AutoReST.Specs.Helpers;
using AutoReST.Specs.Helpers.SpecificNamespace;
using Machine.Specifications;

namespace AutoReST.Specs.Specs
{
    [Subject("Action Finder")]
    public class when_getting_actions_for_controllerless_action
    {
        Establish context = () =>
        {
            actionFinder = new ActionFinder();
            controllerList = new List<Type> { typeof(ActionlessController) };
        };

        Because of = () =>
        {

            actions = actionFinder.GetActions(controllerList);
        };

        It should_return_0_actions = () =>
        {
            actions.Count.ShouldEqual(0);
        };

        static IList<ActionInfo> actions;
        static IActionFinder actionFinder;
        static List<Type> controllerList;
    }

    [Subject("Action Finder")]
    public class when_getting_actions_for_a_controller_with_actions
    {
        Establish context = () =>
        {
            actionFinder = new ActionFinder();

            controllerList = new List<Type> { typeof(ActionController) };
        };

        Because of = () =>
        {

            actions = actionFinder.GetActions(controllerList);
        };

        It should_return_all_actions_of_the_controller = () =>
        {
            actions.Count.ShouldEqual(5);
            actions[0].Name.ShouldEqual("Create");
            actions[0].Verb.ShouldEqual(HttpVerbs.Get);
            actions[1].Name.ShouldEqual("Create");
            actions[1].Verb.ShouldEqual(HttpVerbs.Post);
            actions[2].Name.ShouldEqual("Delete");
            actions[2].Verb.ShouldEqual(HttpVerbs.Delete);
            actions[3].Name.ShouldEqual("Edit");
            actions[3].Verb.ShouldEqual(HttpVerbs.Get);
            actions[4].Name.ShouldEqual("Edit");
            actions[4].Verb.ShouldEqual(HttpVerbs.Put);
        };

        static IList<ActionInfo> actions;
        static IActionFinder actionFinder;
        static List<Type> controllerList;
    }

    [Subject("Finding Actions")]
    public class when_getting_actions_for_a_controller_with_a_complex_parameter
    {
        Establish context = () =>
        {
            actionFinder = new ActionFinder();

            controllerList = new List<Type> { typeof(ThirdController) };
        };

        Because of = () =>
        {
            actions = actionFinder.GetActions(controllerList);
        };

        It should_contains_a_list_of_parameters_with_IsComplexType_set_to_true_for_the_complex_parameter = () =>
        {
            actions[1].Parameters[0].IsComplexType.ShouldBeTrue();
        };


        static IList<ActionInfo> actions;
        static IActionFinder actionFinder;
        static List<Type> controllerList;
    }

}