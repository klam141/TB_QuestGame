using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// the character class the player uses in the game
    /// </summary>
    public class Citizen : Character
    {
        #region ENUMERABLES


        #endregion

        #region FIELDS
        string _status, _homePlanet;
        int _health, _lives, _exp;
        bool _isStunned;
        private List<int> _locationsVisited;

        #endregion

        #region PROPERTIES
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public string HomePlanet
        {
            get { return _homePlanet; }
            set { _homePlanet = value; }
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }

        public int Exp
        {
            get { return _exp; }
            set { _exp = value; }
        }

        public bool IsStunned
        {
            get { return _isStunned; }
            set { _isStunned = value; }
        }

        public List<int> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Citizen()
        {
            
            _locationsVisited = new List<int>();
        }

        public Citizen(string name, RaceType race, int locationID) : base(name, race, locationID)
        {
            _status = "Healthy";
            _health = 100;
            _isStunned = false;
            _locationsVisited = new List<int>();
        }

        #endregion

        #region METHODS

        public override string Greeting()
        {
            return $"Hi. I'm {base.Name}. I'm {base.Age} years old. I'm from {_homePlanet}";
        }

        public bool HasVisited(int locationID)
        {
            if (LocationsVisited.Contains(locationID)) return true;
            else return false;
        }

        #endregion
    }
}
