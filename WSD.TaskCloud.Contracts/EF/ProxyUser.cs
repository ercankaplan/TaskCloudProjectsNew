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
    public partial class ProxyUser: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public int ID
        {
            get { return _iD; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_iD == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "ID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "ID"); 
    						}
                    _iD = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("ID");
                }
            }
        }
        private int _iD;
    
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
        public System.DateTime StartDate
        {
            get { return _startDate; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_startDate == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "StartDate"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "StartDate"); 
    						}
                    _startDate = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("StartDate");
                }
            }
        }
        private System.DateTime _startDate;
    
        [DataMember]
        public Nullable<System.DateTime> FinishDate
        {
            get { return _finishDate; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_finishDate == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "FinishDate"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "FinishDate"); 
    						}
                    _finishDate = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("FinishDate");
                }
            }
        }
        private Nullable<System.DateTime> _finishDate;
    
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
