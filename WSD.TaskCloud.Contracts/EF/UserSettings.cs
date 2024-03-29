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
    [KnownType(typeof(Users))]
    public partial class UserSettings: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public int UserSettingsID
        {
            get { return _userSettingsID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_userSettingsID == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'UserSettingsID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "UserSettingsID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "UserSettingsID"); 
    						}
                    _userSettingsID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("UserSettingsID");
                }
            }
        }
        private int _userSettingsID;
    
        [DataMember]
        public Nullable<int> UserID
        {
            get { return _userID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_userID == value)))
                {
                    ChangeTracker.RecordOriginalValue("UserID", _userID);
                    if (!IsDeserializing)
                    {
                        if (Users != null && Users.UserID != value)
                        {
                            Users = null;
                        }
                    }
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
        private Nullable<int> _userID;
    
        [DataMember]
        public bool WeeklyDashboard
        {
            get { return _weeklyDashboard; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_weeklyDashboard == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "WeeklyDashboard"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "WeeklyDashboard"); 
    						}
                    _weeklyDashboard = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("WeeklyDashboard");
                }
            }
        }
        private bool _weeklyDashboard;
    
        [DataMember]
        public bool TaskReminderSMS
        {
            get { return _taskReminderSMS; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskReminderSMS == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TaskReminderSMS"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TaskReminderSMS"); 
    						}
                    _taskReminderSMS = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TaskReminderSMS");
                }
            }
        }
        private bool _taskReminderSMS;
    
        [DataMember]
        public bool TaskReminderEmail
        {
            get { return _taskReminderEmail; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_taskReminderEmail == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TaskReminderEmail"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TaskReminderEmail"); 
    						}
                    _taskReminderEmail = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TaskReminderEmail");
                }
            }
        }
        private bool _taskReminderEmail;
    
        [DataMember]
        public byte Background
        {
            get { return _background; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_background == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Background"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Background"); 
    						}
                    _background = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Background");
                }
            }
        }
        private byte _background;
    
        [DataMember]
        public byte DefaultViewType
        {
            get { return _defaultViewType; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_defaultViewType == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "DefaultViewType"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "DefaultViewType"); 
    						}
                    _defaultViewType = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("DefaultViewType");
                }
            }
        }
        private byte _defaultViewType;

        #endregion

        #region Navigation Properties
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public Users Users
        {
            get { return _users; }
            set
            {
                if (!ReferenceEquals(_users, value))
                {
                    var previousValue = _users;
                    _users = value;
                    FixupUsers(previousValue);
                    OnNavigationPropertyChanged("Users");
                }
            }
        }
        private Users _users;

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
            Users = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupUsers(Users previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.UserSettings.Contains(this))
            {
                previousValue.UserSettings.Remove(this);
            }
    
            if (Users != null)
            {
                Users.UserSettings.Add(this);
    
                UserID = Users.UserID;
            }
            else if (!skipKeys)
            {
                UserID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Users")
                    && (ChangeTracker.OriginalValues["Users"] == Users))
                {
                    ChangeTracker.OriginalValues.Remove("Users");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Users", previousValue);
                }
                if (Users != null && !Users.ChangeTracker.ChangeTrackingEnabled)
                {
                    Users.StartTracking();
                }
            }
        }

        #endregion

    }
}
