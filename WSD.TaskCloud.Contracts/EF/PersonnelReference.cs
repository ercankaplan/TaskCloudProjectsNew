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
    [KnownType(typeof(Reference))]
    [KnownType(typeof(Task))]
    [KnownType(typeof(Personnel))]
    public partial class PersonnelReference: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public System.Guid PersonnelReferenceID
        {
            get { return _personnelReferenceID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_personnelReferenceID == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'PersonnelReferenceID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "PersonnelReferenceID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "PersonnelReferenceID"); 
    						}
                    _personnelReferenceID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("PersonnelReferenceID");
                }
            }
        }
        private System.Guid _personnelReferenceID;
    
        [DataMember]
        public Nullable<System.Guid> TaskID
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
        private Nullable<System.Guid> _taskID;
    
        [DataMember]
        public int PersonnelID
        {
            get { return _personnelID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_personnelID == value)))
                {
                    ChangeTracker.RecordOriginalValue("PersonnelID", _personnelID);
                    if (!IsDeserializing)
                    {
                        if (Personnel != null && Personnel.PersonnelID != value)
                        {
                            Personnel = null;
                        }
                    }
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
        private int _personnelID;
    
        [DataMember]
        public int ReferenceID
        {
            get { return _referenceID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_referenceID == value)))
                {
                    ChangeTracker.RecordOriginalValue("ReferenceID", _referenceID);
                    if (!IsDeserializing)
                    {
                        if (Reference != null && Reference.ReferenceID != value)
                        {
                            Reference = null;
                        }
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "ReferenceID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "ReferenceID"); 
    						}
                    _referenceID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("ReferenceID");
                }
            }
        }
        private int _referenceID;
    
        [DataMember]
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_isVisible == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "IsVisible"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "IsVisible"); 
    						}
                    _isVisible = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("IsVisible");
                }
            }
        }
        private bool _isVisible;
    
        [DataMember]
        public Nullable<System.Guid> AttachmentID
        {
            get { return _attachmentID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_attachmentID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "AttachmentID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "AttachmentID"); 
    						}
                    _attachmentID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("AttachmentID");
                }
            }
        }
        private Nullable<System.Guid> _attachmentID;
    
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
        public int OpUserID
        {
            get { return _opUserID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_opUserID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "OpUserID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "OpUserID"); 
    						}
                    _opUserID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("OpUserID");
                }
            }
        }
        private int _opUserID;

        #endregion

        #region Navigation Properties
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public Reference Reference
        {
            get { return _reference; }
            set
            {
                if (!ReferenceEquals(_reference, value))
                {
                    var previousValue = _reference;
                    _reference = value;
                    FixupReference(previousValue);
                    OnNavigationPropertyChanged("Reference");
                }
            }
        }
        private Reference _reference;
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
        public Personnel Personnel
        {
            get { return _personnel; }
            set
            {
                if (!ReferenceEquals(_personnel, value))
                {
                    var previousValue = _personnel;
                    _personnel = value;
                    FixupPersonnel(previousValue);
                    OnNavigationPropertyChanged("Personnel");
                }
            }
        }
        private Personnel _personnel;

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
            Reference = null;
            Task = null;
            Personnel = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupReference(Reference previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.PersonnelReference.Contains(this))
            {
                previousValue.PersonnelReference.Remove(this);
            }
    
            if (Reference != null)
            {
                Reference.PersonnelReference.Add(this);
    
                ReferenceID = Reference.ReferenceID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Reference")
                    && (ChangeTracker.OriginalValues["Reference"] == Reference))
                {
                    ChangeTracker.OriginalValues.Remove("Reference");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Reference", previousValue);
                }
                if (Reference != null && !Reference.ChangeTracker.ChangeTrackingEnabled)
                {
                    Reference.StartTracking();
                }
            }
        }
    
        private void FixupTask(Task previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.PersonnelReference.Contains(this))
            {
                previousValue.PersonnelReference.Remove(this);
            }
    
            if (Task != null)
            {
                Task.PersonnelReference.Add(this);
    
                TaskID = Task.TaskID;
            }
            else if (!skipKeys)
            {
                TaskID = null;
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
    
        private void FixupPersonnel(Personnel previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.PersonnelReference.Contains(this))
            {
                previousValue.PersonnelReference.Remove(this);
            }
    
            if (Personnel != null)
            {
                Personnel.PersonnelReference.Add(this);
    
                PersonnelID = Personnel.PersonnelID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Personnel")
                    && (ChangeTracker.OriginalValues["Personnel"] == Personnel))
                {
                    ChangeTracker.OriginalValues.Remove("Personnel");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Personnel", previousValue);
                }
                if (Personnel != null && !Personnel.ChangeTracker.ChangeTrackingEnabled)
                {
                    Personnel.StartTracking();
                }
            }
        }

        #endregion

    }
}