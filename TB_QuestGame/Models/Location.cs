﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Location
    {
        #region FIELDS

        private string _commonName;
        private int _locationID; // must be a unique value for each object
        private int _date;
        private string _mapLocation;
        private string _description;
        private string _generalContents;
        private int[] _canAccess;
        private bool _accessable;
        private int _experiencePoints;
        private List<Events> _events;
        private List<EventTypes> _eventTypes;
        private string _eventDescription;

        #endregion


        #region PROPERTIES

        public string CommonName
        {
            get { return _commonName; }
            set { _commonName = value; }
        }

        public int LocationID
        {
            get { return _locationID; }
            set { _locationID = value; }
        }

        public int Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public string MapLocation
        {
            get { return _mapLocation; }
            set { _mapLocation = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string GeneralContents
        {
            get { return _generalContents; }
            set { _generalContents = value; }
        }

        public int[] CanAccess
        {
            get { return _canAccess; }
            set { _canAccess = value; }
        }

        public bool Accessable
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public int ExperiencePoints
        {
            get { return _experiencePoints; }
            set { _experiencePoints = value; }
        }

        public List<Events> Events
        {
            get { return _events; }
            set { _events = value; }
        }

        public List<EventTypes> EventTypes
        {
            get { return _eventTypes; }
            set { _eventTypes = value; }
        }

        public string EventDescription
        {
            get { return _eventDescription; }
            set { _eventDescription = value; }
        }
        #endregion


        #region CONSTRUCTORS



        #endregion


        #region METHODS



        #endregion


    }
}
