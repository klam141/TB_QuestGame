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

        public bool isValidLocation(int locationId)
        {
            List<int> LocationIds = new List<int>();


            foreach (Location l in _locations) { LocationIds.Add(l.LocationID); }

            if (LocationIds.Contains(locationId)) return true;
            else return false;
        }

        public bool IsAccessibleLocation(int locationId)
        {

            return false;
        }

        public int GetMaxLocationId()
        {
            int MaxId = 0;


            return MaxId;
        }

        public Location GetLocationById(int Id)
        {
            Location location = null;


            return location;
        }
        #endregion
    }
}
