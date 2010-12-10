using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using AutoReST.Infrastructure;
using AutoReST.Specs.Helpers;
using Machine.Specifications;

namespace AutoReST.Specs.Features
{
    [Subject("Parsing Controllers")]
    public class when_parsing_a_controller_with_no_actions
    {
        Establish context = () =>
        {
            controllerParser = new ControllerParser(new ControllerParserConfiguration());
        };

        Because of = () =>
        {
            actions = controllerParser.GetActions(typeof (ActionlessController));
        };

        It should_return_null = () =>
        {
            actions.Count.ShouldEqual(0);
        };

        static IList<ActionInfo> actions;
        static IControllerParser controllerParser;
    }

    [Subject("Parsing Controllers")]
    public class when_parsing_a_controller_with_actions
    {
        Establish context = () =>
        {
            controllerParser = new ControllerParser(new ControllerParserConfiguration());
        };

        Because of = () =>
        {
            actions = controllerParser.GetActions(typeof (ActionController));
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
            actions[3].Name.ShouldEqual("Update");
            actions[3].Verb.ShouldEqual(HttpVerbs.Get);
            actions[4].Name.ShouldEqual("Update");
            actions[4].Verb.ShouldEqual(HttpVerbs.Put);
        };

        static IList<ActionInfo> actions;
        static IControllerParser controllerParser;
    }

    [Subject("Parsing Controllers")]
    public class when_parsing_an_assembly_of_controllers
    {
        Establish context = () =>
        {
            controllerParser = new ControllerParser(new ControllerParserConfiguration());
        };

        Because of = () =>
        {
            actions = controllerParser.GetActions(Assembly.GetExecutingAssembly());
        };

        It should_return_all_actions_of_all_controllers = () => { actions.Count.ShouldEqual(12); };

        static IList<ActionInfo> actions;
        static IControllerParser controllerParser;
    }

    [Subject("Parsing Controllers")]
    public class when_parsing_an_assembly_of_controllers_with_filtered_namespaces
    {
        Establish context = () =>
        {
            IControllerParserConfiguration controllerParserConfiguration = new ControllerParserConfiguration();

            controllerParserConfiguration.Namespaces.Add("AutoReST.Specs.Helpers.SpecificNamespace");

            controllerParser = new ControllerParser(controllerParserConfiguration);
        };

        Because of = () =>
        {
            actions = controllerParser.GetActions(Assembly.GetExecutingAssembly());
        };

        It should_return_all_actions_of_all_controllers_defined_in_the_namespaces = () =>
        {
            actions.Count.ShouldEqual(1);
        };

        
        static IList<ActionInfo> actions;
        static IControllerParser controllerParser;

    }

    [Subject("Parsing Controllers")]
    public class when_parsing_an_assembly_of_controllers_with_specific_controllers
    {
        Establish context = () =>
        {
            IControllerParserConfiguration controllerParserConfiguration = new ControllerParserConfiguration();

            controllerParserConfiguration.Controllers.Add("ConventionController");

            controllerParser = new ControllerParser(controllerParserConfiguration);
        };

        Because of = () =>
        {
            actions = controllerParser.GetActions(Assembly.GetExecutingAssembly());
        };

        It should_return_all_actions_of_only_specified_controllers = () =>
        {
            actions.Count.ShouldEqual(5);
        };


        static IList<ActionInfo> actions;
        static IControllerParser controllerParser;

    }

}