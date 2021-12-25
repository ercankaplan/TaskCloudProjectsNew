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
    [KnownType(typeof(Title))]
    [KnownType(typeof(PersonnelReference))]
    public partial class Reference: BaseEntityType,IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
    	[Key] //Fix++ : need to know key fields
        [DataMember]
        public int ReferenceID
        {
            get { return _referenceID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_referenceID == value)))
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ReferenceID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
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
        public int TitleID
        {
            get { return _titleID; }
            set
            {
               
    			//Fix++ :check current value
    		    if (!((value != null) && (_titleID == value)))
                {
                    ChangeTracker.RecordOriginalValue("TitleID", _titleID);
                    if (!IsDeserializing)
                    {
                        if (Title != null && Title.TitleID != value)
                        {
                            Title = null;
                        }
                    }
                    //Fix++ : Property Validation
    				if (!isServerProcess)
    					if (!bIsCancelling)
    						if (this.ChangeTracker.State != ObjectState.Unchanged)
    							Validate(value, "TitleID"); 
    						else
    						{
    							if (IsJustInitialized)	
    								Validate(value, "TitleID"); 
    						}
                    _titleID = value;
    				IsJustInitialized = false;
                    OnPropertyChanged("TitleID");
                }
            }
        }
        private int _titleID;
    
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
        public Title Title
        {
            get { return _title; }
            set
            {
                if (!ReferenceEquals(_title, value))
                {
                    var previousValue = _title;
                    _title = value;
                    FixupTitle(previousValue);
                    OnNavigationPropertyChanged("Title");
                }
            }
        }
        private Title _title;
        [ScriptIgnore] //Fix++ circular reference exception 
        [DataMember]
        public TrackableCollection<PersonnelReference> PersonnelReference
        {
            get
            {
                if (_personnelReference == null)
                {
                    _personnelReference = new TrackableCollection<PersonnelReference>();
                    _personnelReference.CollectionChanged += FixupPersonnelReference;
                }
                return _personnelReference;
            }
            set
            {
                if (!ReferenceEquals(_personnelReference, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_personnelReference != null)
                    {
                        _personnelReference.CollectionChanged -= FixupPersonnelReference;
                    }
                    _personnelReference = value;
                    if (_personnelReference != null)
                    {
                        _personnelReference.CollectionChanged += FixupPersonnelReference;
                    }
                    OnNavigationPropertyChanged("PersonnelReference");
                }
            }
        }
        private TrackableCollection<PersonnelReference> _personnelReference;

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
            Title = null;
            PersonnelReference.Clear();
        }

        #endregion

        #region Association Fixup
    
        private void FixupTitle(Title previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Reference.Contains(this))
            {
                previousValue.Reference.Remove(this);
            }
    
            if (Title != null)
            {
                Title.Reference.Add(this);
    
                TitleID = Title.TitleID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Title")
                    && (ChangeTracker.OriginalValues["Title"] == Title))
                {
                    ChangeTracker.OriginalValues.Remove("Title");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Title", previousValue);
                }
                if (Title != null && !Title.ChangeTracker.ChangeTrackingEnabled)
                {
                    Title.StartTracking();
                }
            }
        }
    
        private void FixupPersonnelReference(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (PersonnelReference item in e.NewItems)
                {
                    item.Reference = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("PersonnelReference", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (PersonnelReference item in e.OldItems)
                {
                    if (ReferenceEquals(item.Reference, this))
                    {
                        item.Reference = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("PersonnelReference", item);
                    }
                }
            }
        }

        #endregion

    }
}
