﻿using System;
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
        
        public enum Statuses
        {
            Healthy,
            Stunned,
            Dead
        }

        #endregion

        #region FIELDS
        Statuses _status;
        string _homePlanet;
        int _health, _lives, _exp, _money;
        bool _isStunned;

        private List<int> _locationsVisited;
        private List<CitizenObject> _inventory;

        #endregion

        #region PROPERTIES
        public Statuses Status
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

        public int Money {
            get { return _money; }
            set { _money = value; }
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

        public List<CitizenObject> Inventory
        {
            get { return _inventory; }
            set { _inventory = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Citizen()
        {
            
            _locationsVisited = new List<int>();
            _inventory = new List<CitizenObject>();
        }

        public Citizen(string name, RaceType race, int locationID) : base(name, race, locationID)
        {
            _status = Statuses.Healthy;
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
