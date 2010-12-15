using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Mvc;
using AutoReST.Infrastructure;
using Machine.Specifications;

namespace AutoReST.Specs.Specs
{
    [Subject("Finding Controllers")]
    public class when_getting_all_controllers_of_an_assembly
    {
        Establish context = () =>
        {
            controllerFinder = new ControllerFinder(new DefaultControllerFinderConfiguration());
        };

        Because of = () =>
        {
            controllers = controllerFinder.GetControllers(Assembly.GetExecutingAssembly());
        };

        It should_return_all_controllers = () => { controllers.Count.ShouldEqual(5); };

        static IList<Type> controllers;
        static IControllerFinder controllerFinder;
    }

    [Subject("Finding Controllers")]
    public class when_getting_all_controllers_of_an_assembly_with_filtered_namespaces
    {
        Establish context = () =>
        {
            IControllerFinderConfiguration controllerFinderConfiguration = new DefaultControllerFinderConfiguration();

            controllerFinderConfiguration.Namespaces.Add("AutoReST.Specs.Helpers.SpecificNamespace");

            controllerFinder = new ControllerFinder(controllerFinderConfiguration);
        };

        Because of = () =>
        {
            controllers = controllerFinder.GetControllers(Assembly.GetExecutingAssembly());
        };

        It should_return_only_controllers_of_the_specificed_namespaces = () => { controllers.Count.ShouldEqual(1); };

        static IList<Type> controllers;
        static IControllerFinder controllerFinder;
    }

    [Subject("Finding Controllers")]
    public class when_getting_all_controllers_of_an_assembly_with_filtered_controllers
    {
        Establish context = () =>
        {
            IControllerFinderConfiguration controllerFinderConfiguration = new DefaultControllerFinderConfiguration();

            controllerFinderConfiguration.Controllers.Add("ConventionController");

            controllerFinder = new ControllerFinder(controllerFinderConfiguration);
        };

        Because of = () =>
        {
            controllers = controllerFinder.GetControllers(Assembly.GetExecutingAssembly());
        };

        It should_return_only_controllers_of_the_specificed_controllers = () => { controllers.Count.ShouldEqual(1); };

        static IList<Type> controllers;
        static IControllerFinder controllerFinder;
    }




}