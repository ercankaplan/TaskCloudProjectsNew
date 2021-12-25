using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts.Personel;
using WSD.TaskCloud.Contracts.DataContracts.Referans;
using WSD.TaskCloud.Contracts.DataContracts.Task;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Contracts.ServiceContracts;
using WSD.TaskCloud.MVC.HelperClasses;

namespace WSD.TaskCloud.MVC.Models
{
    public static class TaskServiceProxy
    {
       

        public static List<Reference> GetReferenceAll()
        {

            List<Reference> result = null;

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                result = svcProxy.GetReferenceAll();

            }, WcfEndpoints.ITaskService);


            return result;

        }

        public static Reference GetReferenceByID(int refID)
        {

           Reference result = null;

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                result = svcProxy.GetReferenceByID(refID);

            }, WcfEndpoints.ITaskService);


            return result;

        }

        public static void UpdateReferences(List<Reference> references)
        {
            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                svcProxy.UpdateReferences(references);

            }, WcfEndpoints.ITaskService);

        }

        public static void UpdateReference(Reference reference)
        {
            List<Reference> lst = new List<Reference>();
            lst.Add(reference);

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                svcProxy.UpdateReferences(lst);

            }, WcfEndpoints.ITaskService);

        }

        public static void SaveNewReference(ReferenceRequest request)
        {
            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                svcProxy.SaveNewReference(request);

            }, WcfEndpoints.ITaskService);
        }

        public static void SaveNewPersonnel(PersonnelRequest request)
        {
            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                svcProxy.SaveNewPersonnel(request);

            }, WcfEndpoints.ITaskService);
        }

        public static List<Personnel> GetPersonnelsByDepartmentID(int depID)
        {

            List<Personnel> result = null;

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                result = svcProxy.GetPersonnelsByDepartmentID(depID);

            }, WcfEndpoints.ITaskService);


            return result;

        }

        public static Personnel GetPersonnelBySicilNo(string sicilNo)
        {
            Personnel result = null;

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                result = svcProxy.GetPersonnelBySicilNo(sicilNo);

            }, WcfEndpoints.ITaskService);


            return result;

        }

        public static List<Department> GetDepartmentUserByRoleID(int nUserRoleID)
        {

            List<Department> result = null;

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                result = svcProxy.GetDepartmentUserByRoleID(nUserRoleID);


            }, WcfEndpoints.ITaskService);


            return result;
        }

        public static List<TaskTemplate> GetUserTemplate(int UserID, int typeID)
        {
            List<TaskTemplate> result = null;

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                result = svcProxy.GetUserTemplate(UserID, typeID);


            }, WcfEndpoints.ITaskService);


            return result;
        }

        public static List<Department> GetDepartmentUsersByUpperDepartmentID(int nUpperDepartmentID, int nDepartmentID)
        {
            List<Department> result = null;

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                result = svcProxy.GetDepartmentUsersByUpperDepartmentID(nUpperDepartmentID,nDepartmentID);


            }, WcfEndpoints.ITaskService);


            return result;
        }

        public static void SaveNewTask(TaskRequestModel request)
        {

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                 svcProxy.SaveNewTask(request);


            }, WcfEndpoints.ITaskService);
        }

        public static void SaveTaskRespose(TaskResponseModel request)
        {

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                svcProxy.SaveTaskRespose(request);

            }, WcfEndpoints.ITaskService);
        }

        public static void SaveForwardTask(TaskForwardModel request)
        {

            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                svcProxy.SaveForwardTask(request);

            }, WcfEndpoints.ITaskService);
        }

        

        public static void UpdatePersonel(Personnel model)
        {
            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                svcProxy.UpdatePersonel(model);

            }, WcfEndpoints.ITaskService);

        }

        public static List<Task> SearchTask(string desc)
        {
            List<Task> result = new List<Task>();
            new ProxyHelper<ITaskService>().Use(svcProxy =>
            {
                result=svcProxy.SearchTask(desc);

            }, WcfEndpoints.ITaskService);
            return result;
        }
    }
}