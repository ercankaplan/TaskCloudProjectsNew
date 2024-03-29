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
    [KnownType(typeof(UserCalender))]
    [KnownType(typeof(UserSettings))]
    public partial class Users: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public int UserID
        {
            get { return _userID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_userID == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'UserID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
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
        private int _userID;
    
        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_userName == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "UserName"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "UserName"); 
    						}
                    _userName = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("UserName");
                }
            }
        }
        private string _userName;
    
        [DataMember]
        public string Password
        {
            get { return _password; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_password == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Password"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Password"); 
    						}
                    _password = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Password");
                }
            }
        }
        private string _password;
    
        [DataMember]
        public string PasswordQuestion
        {
            get { return _passwordQuestion; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_passwordQuestion == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "PasswordQuestion"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "PasswordQuestion"); 
    						}
                    _passwordQuestion = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("PasswordQuestion");
                }
            }
        }
        private string _passwordQuestion;
    
        [DataMember]
        public string PasswordAnswer
        {
            get { return _passwordAnswer; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_passwordAnswer == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "PasswordAnswer"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "PasswordAnswer"); 
    						}
                    _passwordAnswer = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("PasswordAnswer");
                }
            }
        }
        private string _passwordAnswer;
    
        [DataMember]
        public bool IsActive
        {
            get { return _isActive; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_isActive == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "IsActive"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "IsActive"); 
    						}
                    _isActive = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("IsActive");
                }
            }
        }
        private bool _isActive;
    
        [DataMember]
        public bool IsLockedOut
        {
            get { return _isLockedOut; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_isLockedOut == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "IsLockedOut"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "IsLockedOut"); 
    						}
                    _isLockedOut = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("IsLockedOut");
                }
            }
        }
        private bool _isLockedOut;
    
        [DataMember]
        public Nullable<System.DateTime> LastLoginDate
        {
            get { return _lastLoginDate; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_lastLoginDate == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "LastLoginDate"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "LastLoginDate"); 
    						}
                    _lastLoginDate = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("LastLoginDate");
                }
            }
        }
        private Nullable<System.DateTime> _lastLoginDate;
    
        [DataMember]
        public Nullable<System.DateTime> LastPasswordChangedDate
        {
            get { return _lastPasswordChangedDate; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_lastPasswordChangedDate == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "LastPasswordChangedDate"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "LastPasswordChangedDate"); 
    						}
                    _lastPasswordChangedDate = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("LastPasswordChangedDate");
                }
            }
        }
        private Nullable<System.DateTime> _lastPasswordChangedDate;
    
        [DataMember]
        public Nullable<System.DateTime> LastLockoutDate
        {
            get { return _lastLockoutDate; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_lastLockoutDate == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "LastLockoutDate"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "LastLockoutDate"); 
    						}
                    _lastLockoutDate = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("LastLockoutDate");
                }
            }
        }
        private Nullable<System.DateTime> _lastLockoutDate;
    
        [DataMember]
        public int FailedPasswordAttemptCount
        {
            get { return _failedPasswordAttemptCount; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_failedPasswordAttemptCount == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "FailedPasswordAttemptCount"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "FailedPasswordAttemptCount"); 
    						}
                    _failedPasswordAttemptCount = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("FailedPasswordAttemptCount");
                }
            }
        }
        private int _failedPasswordAttemptCount;
    
        [DataMember]
        public System.DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_createDate == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "CreateDate"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "CreateDate"); 
    						}
                    _createDate = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("CreateDate");
                }
            }
        }
        private System.DateTime _createDate;
    
        [DataMember]
        public Nullable<System.DateTime> LastActivityDate
        {
            get { return _lastActivityDate; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_lastActivityDate == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "LastActivityDate"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "LastActivityDate"); 
    						}
                    _lastActivityDate = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("LastActivityDate");
                }
            }
        }
        private Nullable<System.DateTime> _lastActivityDate;
    
        [DataMember]
        public string Comment
        {
            get { return _comment; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_comment == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Comment"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Comment"); 
    						}
                    _comment = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Comment");
                }
            }
        }
        private string _comment;
    
        [DataMember]
        public byte[] Logo
        {
            get { return _logo; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_logo == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "Logo"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "Logo"); 
    						}
                    _logo = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("Logo");
                }
            }
        }
        private byte[] _logo;
    
        [DataMember]
        public Nullable<bool> ISReset
        {
            get { return _iSReset; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_iSReset == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "ISReset"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "ISReset"); 
    						}
                    _iSReset = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("ISReset");
                }
            }
        }
        private Nullable<bool> _iSReset;
    
        [DataMember]
        public int UserGroupID
        {
            get { return _userGroupID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_userGroupID == value)))
                {
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "UserGroupID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "UserGroupID"); 
    						}
                    _userGroupID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("UserGroupID");
                }
            }
        }
        private int _userGroupID;

        #endregion

        #region Navigation Properties
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public TrackableCollection<Task> Task
        {
            get
            {
                if (_task == null)
                {
                    _task = new TrackableCollection<Task>();
                    _task.CollectionChanged += FixupTask;
                }
                return _task;
            }
            set
            {
                if (!ReferenceEquals(_task, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_task != null)
                    {
                        _task.CollectionChanged -= FixupTask;
                    }
                    _task = value;
                    if (_task != null)
                    {
                        _task.CollectionChanged += FixupTask;
                    }
                    OnNavigationPropertyChanged("Task");
                }
            }
        }
        private TrackableCollection<Task> _task;
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public TrackableCollection<UserCalender> UserCalender
        {
            get
            {
                if (_userCalender == null)
                {
                    _userCalender = new TrackableCollection<UserCalender>();
                    _userCalender.CollectionChanged += FixupUserCalender;
                }
                return _userCalender;
            }
            set
            {
                if (!ReferenceEquals(_userCalender, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_userCalender != null)
                    {
                        _userCalender.CollectionChanged -= FixupUserCalender;
                    }
                    _userCalender = value;
                    if (_userCalender != null)
                    {
                        _userCalender.CollectionChanged += FixupUserCalender;
                    }
                    OnNavigationPropertyChanged("UserCalender");
                }
            }
        }
        private TrackableCollection<UserCalender> _userCalender;
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public TrackableCollection<UserSettings> UserSettings
        {
            get
            {
                if (_userSettings == null)
                {
                    _userSettings = new TrackableCollection<UserSettings>();
                    _userSettings.CollectionChanged += FixupUserSettings;
                }
                return _userSettings;
            }
            set
            {
                if (!ReferenceEquals(_userSettings, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_userSettings != null)
                    {
                        _userSettings.CollectionChanged -= FixupUserSettings;
                    }
                    _userSettings = value;
                    if (_userSettings != null)
                    {
                        _userSettings.CollectionChanged += FixupUserSettings;
                    }
                    OnNavigationPropertyChanged("UserSettings");
                }
            }
        }
        private TrackableCollection<UserSettings> _userSettings;

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
            Task.Clear();
            UserCalender.Clear();
            UserSettings.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupTask(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Task item in e.NewItems)
                {
                    item.Users = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Task", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Task item in e.OldItems)
                {
                    if (ReferenceEquals(item.Users, this))
                    {
                        item.Users = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Task", item);
                    }
                }
            }
        }
    
        private void FixupUserCalender(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (UserCalender item in e.NewItems)
                {
                    item.Users = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("UserCalender", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserCalender item in e.OldItems)
                {
                    if (ReferenceEquals(item.Users, this))
                    {
                        item.Users = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("UserCalender", item);
                    }
                }
            }
        }
    
        private void FixupUserSettings(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (UserSettings item in e.NewItems)
                {
                    item.Users = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("UserSettings", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (UserSettings item in e.OldItems)
                {
                    if (ReferenceEquals(item.Users, this))
                    {
                        item.Users = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("UserSettings", item);
                    }
                }
            }
        }

        #endregion

    }
}
