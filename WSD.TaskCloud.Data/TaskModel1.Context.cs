﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using WSD.TaskCloud.Contracts.EF;

namespace WSD.TaskCloud.Data
{
    public partial class TaskCloudEntities : ObjectContext
    {
        public const string ConnectionString = "name=TaskCloudEntities";
        public const string ContainerName = "TaskCloudEntities";
    
        #region Constructors
    
        public TaskCloudEntities()
            : base(ConnectionString, ContainerName)
        {
            Initialize();
        }
    
        public TaskCloudEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            Initialize();
        }
    
        public TaskCloudEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            Initialize();
        }
    
        private void Initialize()
        {
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        }
    
        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }

        #endregion

        #region ObjectSet Properties
    
        public ObjectSet<ActionCode> ActionCode
        {
            get { return _actionCode  ?? (_actionCode = CreateObjectSet<ActionCode>("ActionCode")); }
        }
        private ObjectSet<ActionCode> _actionCode;
    
        public ObjectSet<AppSettings> AppSettings
        {
            get { return _appSettings  ?? (_appSettings = CreateObjectSet<AppSettings>("AppSettings")); }
        }
        private ObjectSet<AppSettings> _appSettings;
    
        public ObjectSet<Category> Category
        {
            get { return _category  ?? (_category = CreateObjectSet<Category>("Category")); }
        }
        private ObjectSet<Category> _category;
    
        public ObjectSet<Conversation> Conversation
        {
            get { return _conversation  ?? (_conversation = CreateObjectSet<Conversation>("Conversation")); }
        }
        private ObjectSet<Conversation> _conversation;
    
        public ObjectSet<Department> Department
        {
            get { return _department  ?? (_department = CreateObjectSet<Department>("Department")); }
        }
        private ObjectSet<Department> _department;
    
        public ObjectSet<EmailRequest> EmailRequest
        {
            get { return _emailRequest  ?? (_emailRequest = CreateObjectSet<EmailRequest>("EmailRequest")); }
        }
        private ObjectSet<EmailRequest> _emailRequest;
    
        public ObjectSet<Permission> Permission
        {
            get { return _permission  ?? (_permission = CreateObjectSet<Permission>("Permission")); }
        }
        private ObjectSet<Permission> _permission;
    
        public ObjectSet<PriorityType> PriorityType
        {
            get { return _priorityType  ?? (_priorityType = CreateObjectSet<PriorityType>("PriorityType")); }
        }
        private ObjectSet<PriorityType> _priorityType;
    
        public ObjectSet<PrivacyType> PrivacyType
        {
            get { return _privacyType  ?? (_privacyType = CreateObjectSet<PrivacyType>("PrivacyType")); }
        }
        private ObjectSet<PrivacyType> _privacyType;
    
        public ObjectSet<Profession> Profession
        {
            get { return _profession  ?? (_profession = CreateObjectSet<Profession>("Profession")); }
        }
        private ObjectSet<Profession> _profession;
    
        public ObjectSet<ProxyUser> ProxyUser
        {
            get { return _proxyUser  ?? (_proxyUser = CreateObjectSet<ProxyUser>("ProxyUser")); }
        }
        private ObjectSet<ProxyUser> _proxyUser;
    
        public ObjectSet<ResultType> ResultType
        {
            get { return _resultType  ?? (_resultType = CreateObjectSet<ResultType>("ResultType")); }
        }
        private ObjectSet<ResultType> _resultType;
    
        public ObjectSet<Role> Role
        {
            get { return _role  ?? (_role = CreateObjectSet<Role>("Role")); }
        }
        private ObjectSet<Role> _role;
    
        public ObjectSet<SMSRequest> SMSRequest
        {
            get { return _sMSRequest  ?? (_sMSRequest = CreateObjectSet<SMSRequest>("SMSRequest")); }
        }
        private ObjectSet<SMSRequest> _sMSRequest;
    
        public ObjectSet<StateType> StateType
        {
            get { return _stateType  ?? (_stateType = CreateObjectSet<StateType>("StateType")); }
        }
        private ObjectSet<StateType> _stateType;
    
        public ObjectSet<TaskCategory> TaskCategory
        {
            get { return _taskCategory  ?? (_taskCategory = CreateObjectSet<TaskCategory>("TaskCategory")); }
        }
        private ObjectSet<TaskCategory> _taskCategory;
    
        public ObjectSet<TaskResponse> TaskResponse
        {
            get { return _taskResponse  ?? (_taskResponse = CreateObjectSet<TaskResponse>("TaskResponse")); }
        }
        private ObjectSet<TaskResponse> _taskResponse;
    
        public ObjectSet<Title> Title
        {
            get { return _title  ?? (_title = CreateObjectSet<Title>("Title")); }
        }
        private ObjectSet<Title> _title;
    
        public ObjectSet<UserCalender> UserCalender
        {
            get { return _userCalender  ?? (_userCalender = CreateObjectSet<UserCalender>("UserCalender")); }
        }
        private ObjectSet<UserCalender> _userCalender;
    
        public ObjectSet<UserSettings> UserSettings
        {
            get { return _userSettings  ?? (_userSettings = CreateObjectSet<UserSettings>("UserSettings")); }
        }
        private ObjectSet<UserSettings> _userSettings;
    
        public ObjectSet<WorkCalender> WorkCalender
        {
            get { return _workCalender  ?? (_workCalender = CreateObjectSet<WorkCalender>("WorkCalender")); }
        }
        private ObjectSet<WorkCalender> _workCalender;
    
        public ObjectSet<UserRole> UserRole
        {
            get { return _userRole  ?? (_userRole = CreateObjectSet<UserRole>("UserRole")); }
        }
        private ObjectSet<UserRole> _userRole;
    
        public ObjectSet<UserProfile> UserProfile
        {
            get { return _userProfile  ?? (_userProfile = CreateObjectSet<UserProfile>("UserProfile")); }
        }
        private ObjectSet<UserProfile> _userProfile;
    
        public ObjectSet<TaskPersonnel> TaskPersonnel
        {
            get { return _taskPersonnel  ?? (_taskPersonnel = CreateObjectSet<TaskPersonnel>("TaskPersonnel")); }
        }
        private ObjectSet<TaskPersonnel> _taskPersonnel;
    
        public ObjectSet<Reference> Reference
        {
            get { return _reference  ?? (_reference = CreateObjectSet<Reference>("Reference")); }
        }
        private ObjectSet<Reference> _reference;
    
        public ObjectSet<TaskResponseAttachment> TaskResponseAttachment
        {
            get { return _taskResponseAttachment  ?? (_taskResponseAttachment = CreateObjectSet<TaskResponseAttachment>("TaskResponseAttachment")); }
        }
        private ObjectSet<TaskResponseAttachment> _taskResponseAttachment;
    
        public ObjectSet<PersonnelReference> PersonnelReference
        {
            get { return _personnelReference  ?? (_personnelReference = CreateObjectSet<PersonnelReference>("PersonnelReference")); }
        }
        private ObjectSet<PersonnelReference> _personnelReference;
    
        public ObjectSet<TaskTemplate> TaskTemplate
        {
            get { return _taskTemplate  ?? (_taskTemplate = CreateObjectSet<TaskTemplate>("TaskTemplate")); }
        }
        private ObjectSet<TaskTemplate> _taskTemplate;
    
        public ObjectSet<TaskType> TaskType
        {
            get { return _taskType  ?? (_taskType = CreateObjectSet<TaskType>("TaskType")); }
        }
        private ObjectSet<TaskType> _taskType;
    
        public ObjectSet<Meeting> Meeting
        {
            get { return _meeting  ?? (_meeting = CreateObjectSet<Meeting>("Meeting")); }
        }
        private ObjectSet<Meeting> _meeting;
    
        public ObjectSet<UserSignImg> UserSignImg
        {
            get { return _userSignImg  ?? (_userSignImg = CreateObjectSet<UserSignImg>("UserSignImg")); }
        }
        private ObjectSet<UserSignImg> _userSignImg;
    
        public ObjectSet<Task> Task
        {
            get { return _task  ?? (_task = CreateObjectSet<Task>("Task")); }
        }
        private ObjectSet<Task> _task;
    
        public ObjectSet<TaskBy> TaskBy
        {
            get { return _taskBy  ?? (_taskBy = CreateObjectSet<TaskBy>("TaskBy")); }
        }
        private ObjectSet<TaskBy> _taskBy;
    
        public ObjectSet<TaskCodeType> TaskCodeType
        {
            get { return _taskCodeType  ?? (_taskCodeType = CreateObjectSet<TaskCodeType>("TaskCodeType")); }
        }
        private ObjectSet<TaskCodeType> _taskCodeType;
    
        public ObjectSet<TaskSource> TaskSource
        {
            get { return _taskSource  ?? (_taskSource = CreateObjectSet<TaskSource>("TaskSource")); }
        }
        private ObjectSet<TaskSource> _taskSource;
    
        public ObjectSet<Personnel> Personnel
        {
            get { return _personnel  ?? (_personnel = CreateObjectSet<Personnel>("Personnel")); }
        }
        private ObjectSet<Personnel> _personnel;
    
        public ObjectSet<Attachment> Attachment
        {
            get { return _attachment  ?? (_attachment = CreateObjectSet<Attachment>("Attachment")); }
        }
        private ObjectSet<Attachment> _attachment;
    
        public ObjectSet<TaskAttachment> TaskAttachment
        {
            get { return _taskAttachment  ?? (_taskAttachment = CreateObjectSet<TaskAttachment>("TaskAttachment")); }
        }
        private ObjectSet<TaskAttachment> _taskAttachment;
    
        public ObjectSet<TaskRequest> TaskRequest
        {
            get { return _taskRequest  ?? (_taskRequest = CreateObjectSet<TaskRequest>("TaskRequest")); }
        }
        private ObjectSet<TaskRequest> _taskRequest;
    
        public ObjectSet<UserGroup> UserGroup
        {
            get { return _userGroup  ?? (_userGroup = CreateObjectSet<UserGroup>("UserGroup")); }
        }
        private ObjectSet<UserGroup> _userGroup;
    
        public ObjectSet<Users> Users
        {
            get { return _users  ?? (_users = CreateObjectSet<Users>("Users")); }
        }
        private ObjectSet<Users> _users;

        #endregion

    }
}