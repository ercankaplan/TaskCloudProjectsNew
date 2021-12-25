using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;
using WSD.TaskCloud.Contracts.DataContracts;
using WSD.TaskCloud.Contracts.EF;
using WSD.TaskCloud.Data;

namespace WSD.TaskCloud.WcfServices.EFQueries
{


    internal class TaskEFQueries
    {


        public static readonly Func<TaskCloudEntities, int, int, IQueryable<TaskRequest>> GetPrivateTaskRequest_CQ =
           CompiledQuery.Compile<TaskCloudEntities, int, int, IQueryable<TaskRequest>>(
           (ctx, userID, tType) => (from tr in ctx.TaskRequest
                                    join t in ctx.Task on tr.TaskID equals t.TaskID
                                    where
                                    tr.ToUserID == userID
                                        && t.PrivacyID == (byte)EnumPrivacy.Private
                                        && t.TypeID == tType
                                    select tr)
           );

        public static readonly Func<TaskCloudEntities, int, int, IQueryable<TaskRequest>> GetPublicTaskRequest_CQ =
          CompiledQuery.Compile<TaskCloudEntities, int, int, IQueryable<TaskRequest>>(
          (ctx, userRoleID, tType) => (from tr in ctx.TaskRequest
                                       join t in ctx.Task on tr.TaskID equals t.TaskID
                                       where
                                        tr.ToUserRoleID == userRoleID
                                            && t.PrivacyID == (byte)EnumPrivacy.Public
                                            && t.TypeID == tType
                                       select tr)
          );

        public static readonly Func<TaskCloudEntities, Guid, IQueryable<Attachment>> GetTaskResponseAttachments_CQ =
          CompiledQuery.Compile<TaskCloudEntities, Guid, IQueryable<Attachment>>(
          (ctx, tResponseID) => (from tra in ctx.TaskResponseAttachment
                                 join a in ctx.Attachment on tra.AttachmentID equals a.AttachmentID
                                 where
                                   tra.TaskResponseID == tResponseID
                                 select a)
          );

        public static readonly Func<TaskCloudEntities, Guid, IQueryable<Attachment>> GetTaskAttachments_CQ =
        CompiledQuery.Compile<TaskCloudEntities, Guid, IQueryable<Attachment>>(
        (ctx, taskID) => (from tra in ctx.TaskAttachment
                          join a in ctx.Attachment on tra.AttachmentID equals a.AttachmentID
                          where
                            tra.TaskID == taskID
                          select a)
        );


        public static readonly Func<TaskCloudEntities, Guid, IQueryable<PersonnelReference>> GetPersonnelReferences_CQ =
        CompiledQuery.Compile<TaskCloudEntities, Guid, IQueryable<PersonnelReference>>(
        (ctx, taskID) => (from tp in ctx.TaskPersonnel
                          join pr in ctx.PersonnelReference on tp.PersonnelID equals pr.PersonnelID 
                          where tp.TaskID == taskID && pr.TaskID == taskID
                          select pr)
        );

        public static readonly Func<TaskCloudEntities, int, IQueryable<Attachment>> GetReferencesAttachment_CQ =
        CompiledQuery.Compile<TaskCloudEntities, int, IQueryable<Attachment>>(
        (ctx, personnelID) => (from pr in ctx.PersonnelReference
                           join a in ctx.Attachment on pr.AttachmentID equals a.AttachmentID
                           where
                           pr.PersonnelID == personnelID
                           select a)
        );

        public static readonly Func<TaskCloudEntities, Guid, IQueryable<Personnel>> GetTaskPersonnel_CQ =
        CompiledQuery.Compile<TaskCloudEntities, Guid, IQueryable<Personnel>>(
        (ctx, taskID) => (from tp in ctx.TaskPersonnel
                         join pr in ctx.Personnel on tp.PersonnelID equals pr.PersonnelID
                         where tp.TaskID == taskID
                         select pr)
        );




    }
}