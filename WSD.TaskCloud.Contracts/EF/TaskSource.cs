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
    public partial class TaskSource: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public int TaskSourceID
        {
            get { return _taskSourceID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskSourceID == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'TaskSourceID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TaskSourceID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TaskSourceID"); 
    						}
                    _taskSourceID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TaskSourceID");
                }
            }
        }
        private int _taskSourceID;
    
        [DataMember]
        public System.Guid TaskID
        {
            get { return _taskID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskID == value)))
                {
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
        public string Organization
        {
            get { return _organization; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_organization == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Organization"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Organization"); 
    						}
                    _organization = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Organization");
                }
            }
        }
        private string _organization;
    
        [DataMember]
        public string Title
        {
            get { return _title; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_title == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Title"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Title"); 
    						}
                    _title = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Title");
                }
            }
        }
        private string _title;
    
        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_firstName == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "FirstName"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "FirstName"); 
    						}
                    _firstName = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        private string _firstName;
    
        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_lastName == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "LastName"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "LastName"); 
    						}
                    _lastName = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("LastName");
                }
            }
        }
        private string _lastName;
    
        [DataMember]
        public Nullable<int> PersonnelID
        {
            get { return _personnelID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_personnelID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "PersonnelID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "PersonnelID"); 
    						}
                    _personnelID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("PersonnelID");
                }
            }
        }
        private Nullable<int> _personnelID;
    
        [DataMember]
        public bool Visible
        {
            get { return _visible; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_visible == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Visible"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Visible"); 
    						}
                    _visible = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Visible");
                }
            }
        }
        private bool _visible;

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
