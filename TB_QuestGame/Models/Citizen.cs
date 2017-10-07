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
        int _health;
        bool _isStunned;

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
            set { _health += value; }
        }

        public bool IsStunned
        {
            get { return _isStunned; }
            set { _isStunned = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Citizen()
        {

        }

        public Citizen(string name, RaceType race) : base(name, race)
        {
            _status = "Healthy";
            _health = 100;
            _isStunned = false;
        }

        #endregion

        #region METHODS

        public override string Greeting()
        {
            return $"Hi. I'm {base.Name}. I'm {base.Age} years old. I'm from {_homePlanet}";
        }

        #endregion
    }
}
