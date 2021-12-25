using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.MVC.HelperClasses;

namespace WSD.TaskCloud.MVC.Models
{
    public static class GeneralDefinitionsServiceProxy
    {
        public static List<Department> GetDepartments()
        {

            List<Department> result = null;

            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                result = svcProxy.GetDepartments();


            }, WcfEndpoints.IGeneralDefinitionsService);


            return result;

        }

        public static List<TaskType> GetTaskTypes()
        {

            List<TaskType> result = null;

            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                result = svcProxy.GetTaskTypes();


            }, WcfEndpoints.IGeneralDefinitionsService);


            return result;

        }

        public static void UpdateTaskTypes(List<TaskType> taskTypes)
        {
            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                svcProxy.UpdateTaskTypes(taskTypes);


            }, WcfEndpoints.IGeneralDefinitionsService);

        }

        public static List<StateType> GetStateTypes()
        {

            List<StateType> result = null;

            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                result = svcProxy.GetStateTypes();


            }, WcfEndpoints.IGeneralDefinitionsService);


            return result;

        }

        public static void UpdateStateTypes(List<StateType> stateTypes)
        {
            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                svcProxy.UpdateStateTypes(stateTypes);


            }, WcfEndpoints.IGeneralDefinitionsService);

        }

        public static List<PriorityType> GetPriortyTypes()
        {

            List<PriorityType> result = null;

            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                result = svcProxy.GetPriortyTypes();


            }, WcfEndpoints.IGeneralDefinitionsService);


            return result;

        }

        public static void UpdatePriorityTypes(List<PriorityType> priorityTypes)
        {
            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                svcProxy.UpdatePriorityTypes(priorityTypes);


            }, WcfEndpoints.IGeneralDefinitionsService);

        }

        public static List<PrivacyType> GetPrivacyTypes()
        {

            List<PrivacyType> result = null;

            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                result = svcProxy.GetPrivacyTypes();


            }, WcfEndpoints.IGeneralDefinitionsService);


            return result;

        }

        public static void UpdatePrivacyTypes(List<PrivacyType> privacyTypes)
        {
            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                svcProxy.UpdatePrivacyTypes(privacyTypes);


            }, WcfEndpoints.IGeneralDefinitionsService);

        }

        public static List<ResultType> GetResultTypes()
        {

            List<ResultType> result = null;

            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                result = svcProxy.GetResultTypes();


            }, WcfEndpoints.IGeneralDefinitionsService);


            return result;

        }

        public static void UpdateResultTypes(List<ResultType> resultTypes)
        {
            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                svcProxy.UpdateResultTypes(resultTypes);


            }, WcfEndpoints.IGeneralDefinitionsService);

        }

        public static List<Role> GetRoles()
        {

            List<Role> result = null;

            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                result = svcProxy.GetRoles();


            }, WcfEndpoints.IGeneralDefinitionsService);


            return result;

        }

        public static void UpdateRoles(List<Role> roles)
        {
            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                svcProxy.UpdateRoles(roles);


            }, WcfEndpoints.IGeneralDefinitionsService);

        }

        public static List<Title> GetTitles()
        {

            List<Title> result = null;

            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                result = svcProxy.GetTitles();


            }, WcfEndpoints.IGeneralDefinitionsService);


            return result;

        }

        public static void UpdateTitles(List<Title> titles)
        {
            new ProxyHelper<IGeneralDefinitionsService>().Use(svcProxy =>
            {
                svcProxy.UpdateTitles(titles);


            }, WcfEndpoints.IGeneralDefinitionsService);

        }
    }
}