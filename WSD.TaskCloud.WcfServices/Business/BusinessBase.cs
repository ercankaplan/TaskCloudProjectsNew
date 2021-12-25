using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Data;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal abstract class BusinessBase
    {
        public TaskCloudEntities TaskCloudContext { get; set; }

        protected TrackableCollection<T> ToTrackableCollection<T>(List<T> items)
        {
            TrackableCollection<T> trackableCollection = new TrackableCollection<T>();
            items.ForEach(t => trackableCollection.Add(t));
            return trackableCollection;
        }
    }
}