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
    public partial class TaskCodeType: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public int TaskCodeTypeID
        {
            get { return _taskCodeTypeID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskCodeTypeID == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'TaskCodeTypeID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TaskCodeTypeID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TaskCodeTypeID"); 
    						}
                    _taskCodeTypeID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TaskCodeTypeID");
                }
            }
        }
        private int _taskCodeTypeID;
    
        [DataMember]
        public int TaskTypeID
        {
            get { return _taskTypeID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskTypeID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TaskTypeID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TaskTypeID"); 
    						}
                    _taskTypeID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TaskTypeID");
                }
            }
        }
        private int _taskTypeID;
    
        [DataMember]
        public string Code
        {
            get { return _code; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_code == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Code"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Code"); 
    						}
                    _code = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Code");
                }
            }
        }
        private string _code;

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
        }

        #endregion

    }
}
