using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum RaceType
        {
            None,
            Human,
            Thorian,
            Xantorian
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _age, _locationId;
        private RaceType _race;
        private bool _isAlive;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }

        public RaceType Race
        {
            get { return _race; }
            set { _race = value; }
        }

        public bool IsAlive
        {
            get { return _isAlive; }
            set { _isAlive = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, RaceType race, int locationID)
        {
            _name = name;
            _race = race;
            _locationId = locationID;
        }

        #endregion

        #region METHODS
        public virtual string Greeting()
        {
            return $"Hi. I'm {_name}.";
        }


        #endregion
    }
}
