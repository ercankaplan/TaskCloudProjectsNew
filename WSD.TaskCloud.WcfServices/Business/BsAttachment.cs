using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.WcfServices.Business
{
    internal class BsAttachment : BusinessBase
    {
        public Attachment GetAttachmentByID(Guid ID)
        {

            Attachment aFile = TaskCloudContext.Attachment.Where(x => x.AttachmentID == ID).SingleOrDefault();

            if (aFile == null)
                throw new ApplicationException("Dosya bulunamadı");

            return aFile;
        }
    }
}