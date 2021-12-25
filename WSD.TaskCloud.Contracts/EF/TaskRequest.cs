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
    [KnownType(typeof(Task))]
    [KnownType(typeof(TaskResponse))]
    public partial class TaskRequest: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public System.Guid TaskRequestID
        {
            get { return _taskRequestID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskRequestID == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'TaskRequestID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
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
        public System.Guid TaskID
        {
            get { return _taskID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskID == value)))
                {
                    ChangeTracker.RecordOriginalValue("TaskID", _taskID);
                    if (!IsDeserializing)
                    {
                        if (Task != null && Task.TaskID != value)
                        {
                            Task = null;
                        }
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TaskID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TaskID"); 
    						}
                    _taskID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TaskID");
                }
            }
        }
        private System.Guid _taskID;
    
        [DataMember]
        public int ToUserID
        {
            get { return _toUserID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_toUserID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "ToUserID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "ToUserID"); 
    						}
                    _toUserID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("ToUserID");
                }
            }
        }
        private int _toUserID;
    
        [DataMember]
        public int ToUserRoleID
        {
            get { return _toUserRoleID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_toUserRoleID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "ToUserRoleID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "ToUserRoleID"); 
    						}
                    _toUserRoleID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("ToUserRoleID");
                }
            }
        }
        private int _toUserRoleID;
    
        [DataMember]
        public int FromUserID
        {
            get { return _fromUserID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_fromUserID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "FromUserID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "FromUserID"); 
    						}
                    _fromUserID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("FromUserID");
                }
            }
        }
        private int _fromUserID;
    
        [DataMember]
        public int FromUserRoleID
        {
            get { return _fromUserRoleID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_fromUserRoleID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "FromUserRoleID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "FromUserRoleID"); 
    						}
                    _fromUserRoleID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("FromUserRoleID");
                }
            }
        }
        private int _fromUserRoleID;
    
        [DataMember]
        public bool CC
        {
            get { return _cC; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_cC == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "CC"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "CC"); 
    						}
                    _cC = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("CC");
                }
            }
        }
        private bool _cC;
    
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
        public byte ViewState
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
        private byte _viewState;
    
        [DataMember]
        public int ResponseTypeID
        {
            get { return _responseTypeID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_responseTypeID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "ResponseTypeID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "ResponseTypeID"); 
    						}
                    _responseTypeID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("ResponseTypeID");
                }
            }
        }
        private int _responseTypeID;

        #endregion

        #region Navigation Properties
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public Task Task
        {
            get { return _task; }
            set
            {
                if (!ReferenceEquals(_task, value))
                {
                    var previousValue = _task;
                    _task = value;
                    FixupTask(previousValue);
                    OnNavigationPropertyChanged("Task");
                }
            }
        }
        private Task _task;
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public TrackableCollection<TaskResponse> TaskResponse
        {
            get
            {
                if (_taskResponse == null)
                {
                    _taskResponse = new TrackableCollection<TaskResponse>();
                    _taskResponse.CollectionChanged += FixupTaskResponse;
                }
                return _taskResponse;
            }
            set
            {
                if (!ReferenceEquals(_taskResponse, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_taskResponse != null)
                    {
                        _taskResponse.CollectionChanged -= FixupTaskResponse;
                    }
                    _taskResponse = value;
                    if (_taskResponse != null)
                    {
                        _taskResponse.CollectionChanged += FixupTaskResponse;
                    }
                    OnNavigationPropertyChanged("TaskResponse");
                }
            }
        }
        private TrackableCollection<TaskResponse> _taskResponse;

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
            Task = null;
            TaskResponse.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupTask(Task previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.TaskRequest.Contains(this))
            {
                previousValue.TaskRequest.Remove(this);
            }
    
            if (Task != null)
            {
                Task.TaskRequest.Add(this);
    
                TaskID = Task.TaskID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Task")
                    && (ChangeTracker.OriginalValues["Task"] == Task))
                {
                    ChangeTracker.OriginalValues.Remove("Task");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Task", previousValue);
                }
                if (Task != null && !Task.ChangeTracker.ChangeTrackingEnabled)
                {
                    Task.StartTracking();
                }
            }
        }
    
        private void FixupTaskResponse(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (TaskResponse item in e.NewItems)
                {
                    item.TaskRequest = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("TaskResponse", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (TaskResponse item in e.OldItems)
                {
                    if (ReferenceEquals(item.TaskRequest, this))
                    {
                        item.TaskRequest = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("TaskResponse", item);
                    }
                }
            }
        }

        #endregion

    }
}