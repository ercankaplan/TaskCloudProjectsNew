using CachingInfra;
using DataServerInfra;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Data;

namespace WSD.TaskCloud.WcfServices
{
    internal class ServiceBase
    {

        #region Transaction

        protected bool isRoot;
        private Dictionary<string, ObjectCtxManager> objectContexts;
        private ObjectCtxManager TaskCloudContextManager
        {
            get
            {
                return GetObjectContext<TaskCloudEntities>("TaskCloudEntities");
            }
        }

        protected TaskCloudEntities TaskCloudContext
        {
            get
            {

                return TaskCloudContextManager.EFContext as TaskCloudEntities;
            }
        }


        public void BeginTransaction()
        {
            this.isRoot = TaskCloudContextManager.BeginTransaction();
        }
        public void CommitTransaction()
        {
            if (this.isRoot)
                TaskCloudContextManager.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            if (this.isRoot)
                TaskCloudContextManager.RollbackTransaction();
        }

        protected ObjectCtxManager GetObjectContext<T>(string connectionName) where T : ObjectContext
        {
            if (objectContexts == null)
            {
                objectContexts = new Dictionary<string, ObjectCtxManager>();
            }

            if (!objectContexts.ContainsKey(connectionName))
            {
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
                ObjectCtxManager ctxManager = new ObjectCtxManager();
                ctxManager.SetObjectContext((T)Activator.CreateInstance(typeof(T), new object[] { connStr }));
                objectContexts.Add(connectionName, ctxManager);
            }

            return objectContexts[connectionName];
        }

        #endregion

        #region Caching
        public List<T> GetCacheItem<T>() where T : class
        {
            return (List<T>)CacheProvider.ProviderInstance.GetCacheItem<T>();
        }

        /// <summary>
        /// using by cacheprovider
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> CacheItemLoader<T>() where T : class
        {
            string defaultConnectionName = objectContexts.Keys.ToList()[0];
            return this.CacheItemLoaderWithConnection<T>(defaultConnectionName);
        }

        public List<T> CacheItemLoaderWithConnection<T>(string connectionName) where T : class
        {

            ObjectSet<T> dest = this.GetObjectContext<ObjectContext>(connectionName).EFContext.CreateObjectSet<T>();
            return dest.ToList();
        }

        #endregion

    }
}