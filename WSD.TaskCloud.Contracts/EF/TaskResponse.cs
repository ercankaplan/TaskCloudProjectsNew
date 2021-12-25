//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Collections;
using System.Linq; 
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;


namespace WSD.TaskCloud.Contracts.EF
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(TaskRequest))]
    public partial class TaskResponse: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public System.Guid TaskResponseID
        {
            get { return _taskResponseID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskResponseID == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'TaskResponseID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TaskResponseID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TaskResponseID"); 
    						}
                    _taskResponseID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TaskResponseID");
                }
            }
        }
        private System.Guid _taskResponseID;
    
        [DataMember]
        public System.Guid TaskRequestID
        {
            get { return _taskRequestID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskRequestID == value)))
                {
                    ChangeTracker.RecordOriginalValue("TaskRequestID", _taskRequestID);
                    if (!IsDeserializing)
                    {
                        if (TaskRequest != null && TaskRequest.TaskRequestID != value)
                        {
                            TaskRequest = null;
                        }
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TaskRequestID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TaskRequestID"); 
    						}
                    _taskRequestID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TaskRequestID");
                }
            }
        }
        private System.Guid _taskRequestID;
    
        [DataMember]
        public string Subject
        {
            get { return _subject; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_subject == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Subject"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Subject"); 
    						}
                    _subject = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Subject");
                }
            }
        }
        private string _subject;
    
        [DataMember]
        public string Summary
        {
            get { return _summary; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_summary == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Summary"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Summary"); 
    						}
                    _summary = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Summary");
                }
            }
        }
        private string _summary;
    
        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_description == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Description"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Description"); 
    						}
                    _description = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
        [DataMember]
        public Nullable<int> CCUserRoleID
        {
            get { return _cCUserRoleID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_cCUserRoleID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "CCUserRoleID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "CCUserRoleID"); 
    						}
                    _cCUserRoleID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("CCUserRoleID");
                }
            }
        }
        private Nullable<int> _cCUserRoleID;
    
        [DataMember]
        public int UserRoleID
        {
            get { return _userRoleID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_userRoleID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "UserRoleID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "UserRoleID"); 
    						}
                    _userRoleID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("UserRoleID");
                }
            }
        }
        private int _userRoleID;
    
        [DataMember]
        public int UserID
        {
            get { return _userID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_userID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "UserID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "UserID"); 
    						}
                    _userID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("UserID");
                }
            }
        }
        private int _userID;
    
        [DataMember]
        public System.DateTime Optime
        {
            get { return _optime; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_optime == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Optime"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Optime"); 
    						}
                    _optime = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Optime");
                }
            }
        }
        private System.DateTime _optime;
    
        [DataMember]
        public Nullable<byte> ViewState
        {
            get { return _viewState; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_viewState == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "ViewState"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "ViewState"); 
    						}
                    _viewState = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("ViewState");
                }
            }
        }
        private Nullable<byte> _viewState;

        #endregion

        #region Navigation Properties
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public TaskRequest TaskRequest
        {
            get { return _taskRequest; }
            set
            {
                if (!ReferenceEquals(_taskRequest, value))
                {
                    var previousValue = _taskRequest;
                    _taskRequest = value;
                    FixupTaskRequest(previousValue);
                    OnNavigationPropertyChanged("TaskRequest");
                }
            }
        }
        private TaskRequest _taskRequest;

        #endregion

        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            TaskRequest = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupTaskRequest(TaskRequest previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.TaskResponse.Contains(this))
            {
                previousValue.TaskResponse.Remove(this);
            }
    
            if (TaskRequest != null)
            {
                TaskRequest.TaskResponse.Add(this);
    
                TaskRequestID = TaskRequest.TaskRequestID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("TaskRequest")
                    && (ChangeTracker.OriginalValues["TaskRequest"] == TaskRequest))
                {
                    ChangeTracker.OriginalValues.Remove("TaskRequest");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("TaskRequest", previousValue);
                }
                if (TaskRequest != null && !TaskRequest.ChangeTracker.ChangeTrackingEnabled)
                {
                    TaskRequest.StartTracking();
                }
            }
        }

        #endregion

    }
}