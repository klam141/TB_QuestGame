using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public class GameMap
    {
        #region FIELDS
        private List<Location> _locations;
        private List<GameObject> _gameObjects;
        #endregion


        #region PROPERTIES
        public List<Location> Locations
        {
            get { return _locations; }
        }

        public List<GameObject> GameObjects
        {
            get { return _gameObjects; }
        }
        #endregion


        #region CONSTRUCTORS
        public GameMap()
        {
            InitMap();
        }
        #endregion


        #region METHODS
        private void InitMap()
        {
            _locations = MapObjects.Locations;
            _gameObjects = MapObjects.gameObjects;
        }

        public bool IsValidLocation(int currentId, int locationId)
        {
            List<int> LocationIds = new List<int>();

            Location currentLocation = GetLocationById(currentId);


            foreach (Location l in _locations) { LocationIds.Add(l.LocationID); }

            if (LocationIds.Contains(locationId) && currentLocation.CanAccess.Contains(locationId)) return true;
            else return false;
        }

        public bool IsValidObjectByLocationId(int gameObjectId, int currentLocationId)
        {
            List<int> gameObjectIds = new List<int>();

            foreach(GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == currentLocationId) gameObjectIds.Add(gameObject.Id);
            }

            if (gameObjectIds.Contains(gameObjectId)) return true;
            else return false;
        }

        public bool IsValidCitizenObjectByLocationId(int citizenObjectId, int currentLocation)
        {
            List<int> citizenObjectIds = new List<int>();

            //make list of object ids in current location
            foreach(GameObject gameObject in _gameObjects)
            {
                if(gameObject.LocationId == currentLocation && gameObject is CitizenObject)
                {
                    citizenObjectIds.Add(gameObject.Id);
                }
            }

            //check if object id is valid
            if (citizenObjectIds.Contains(citizenObjectId)) return true;
            else return false;
        }

        public bool IsValidTreasureObjectByLocationId(int treasureObjectId, int currentLocation)
        {
            List<int> treasureObjectIds = new List<int>();

            //make list of object ids in current location
            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == currentLocation && gameObject is TreasureObject)
                {
                    treasureObjectIds.Add(gameObject.Id);
                }
            }

            //check if object id is valid
            if (treasureObjectIds.Contains(treasureObjectId)) return true;
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

        public Location GetLocationById(int id)
        {
            Location locationToReturn = null;

            foreach(Location location in _locations)
            {
                if (location.LocationID == id) locationToReturn = location;
            }

            if(locationToReturn == null)
            {
                string feedbackMessage = $"The Location ID {id} does not exist on the map";
                throw new ArgumentException(id.ToString(), feedbackMessage);
            }

            return locationToReturn;
        }

        public GameObject GetGameObjectById(int id)
        {
            GameObject gameObjectToReturn = null;

            foreach(GameObject gameObject in _gameObjects)
            {
                if (gameObject.Id == id) gameObjectToReturn = gameObject;
            }

            if(gameObjectToReturn == null)
            {
                string feedbackMessage = $"The Object ID {id} does not exist";
                throw new ArgumentException(id.ToString(), feedbackMessage);
            }

            return gameObjectToReturn;
        }

        public List<GameObject> GetGameObjectsByLocationId(int locationId)
        {
            List<GameObject> gameObjects = new List<GameObject>();

            foreach (GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == locationId) gameObjects.Add(gameObject);
            }

            return gameObjects;
        }

        public List<CitizenObject> GetCitizenObjectsByLocationId(int locationId)
        {
            List<CitizenObject> citizenObjects = new List<CitizenObject>();

            //get list of all objects in current location
            foreach(GameObject gameObject in _gameObjects)
            {
                if (gameObject.LocationId == locationId && gameObject is CitizenObject)
                {
                    citizenObjects.Add(gameObject as CitizenObject);
                }
            }

            return citizenObjects;
        }

        public bool canPickUpObjectInLocation(int gameObjectId, int currentLocationId)
        {
            //stop if the id is unset
            if (!IsValidObjectByLocationId(gameObjectId, currentLocationId)) return false;

            GameObject gameObject = GetGameObjectById(gameObjectId);

            if (gameObject is TreasureObject) return true;
            else if (gameObject is CitizenObject && (gameObject as CitizenObject).CanInventory) return true;
            else return false;
        }
        #endregion
    }
}
