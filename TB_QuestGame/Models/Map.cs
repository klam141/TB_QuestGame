using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class Map
    {
        #region FIELDS
        private List<Location> _locations;
        #endregion


        #region PROPERTIES
        public List<Location> Locations
        {
            get { return _locations; }
        }
        #endregion


        #region CONSTRUCTORS
        public Map()
        {
            InitMap();
        }
        #endregion


        #region METHODS
        private void InitMap()
        {
            _locations = MapObjects.Locations;
        }

        public bool isValidLocation(int currentId, int locationId)
        {
            List<int> LocationIds = new List<int>();

            Location currentLocation = GetLocationById(currentId);


            foreach (Location l in _locations) { LocationIds.Add(l.LocationID); }

            if (LocationIds.Contains(locationId) && currentLocation.CanAccess.Contains(locationId)) return true;
            else return false;
        }

        public bool IsAccessibleLocation(int locationId)
        {
            Location location = GetLocationById(locationId);
            if (location.Accessable == true) return true;
            else return false;
        }

        public int GetMaxLocationId()
        {
            int MaxId = 0;

            foreach(Location l in Locations)
            {
                if (l.LocationID > MaxId) MaxId = l.LocationID;
            }

            return MaxId;
        }

        public Location GetLocationById(int Id)
        {
            Location location = null;

            foreach(Location l in _locations)
            {
                if (l.LocationID == Id) location = l;
            }

            if(location == null)
            {
                string feedbackMessage = $"The Location ID {Id} does not exist on the map";
                throw new ArgumentException(Id.ToString(), feedbackMessage);
            }

            return location;
        }
        #endregion
    }
}
