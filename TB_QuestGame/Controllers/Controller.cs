using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// controller for the MVC pattern in the application
    /// </summary>
    public class Controller
    {
        #region FIELDS

        private ConsoleView _gameConsoleView;
        private Citizen _gameCitizen;
        private GameMap _gameMap;
        private Menu _currentMenu;
        private dynamic _currentObject;
        private bool _playingGame;
        private Location _currentLocation;

        #endregion

        #region PROPERTIES


        #endregion

        #region CONSTRUCTORS

        public Controller()
        {
            //
            // setup all of the objects in the game
            //
            InitializeGame();

            //
            // begins running the application UI
            //
            ManageGameLoop();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize the major game objects
        /// </summary>
        private void InitializeGame()
        {
            _gameCitizen = new Citizen();
            _gameMap = new GameMap();
            _gameConsoleView = new ConsoleView(_gameCitizen, _gameMap);
            _currentMenu = ActionMenu.None;
            _playingGame = true;

            _gameCitizen.Inventory.Add(_gameMap.GetGameObjectById(8) as CitizenObject);
            _gameCitizen.Inventory.Add(_gameMap.GetGameObjectById(9) as CitizenObject);

            Console.CursorVisible = false;
        }

        /// <summary>
        /// method to manage the application setup and game loop
        /// </summary>
        private void ManageGameLoop()
        {
            CitizenAction CitizenActionChoice = CitizenAction.None;

            //
            // display splash screen
            //
            _playingGame = _gameConsoleView.DisplaySpashScreen();

            //
            // player chooses to quit
            //
            if (!_playingGame)
            {
                Environment.Exit(1);
            }

            //
            // display introductory message
            //
            _gameConsoleView.DisplayGamePlayScreen(Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission Citizen
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _currentMenu = ActionMenu.MainMenu;
            _currentLocation = _gameMap.GetLocationById(_gameCitizen.LocationId);
            _gameConsoleView.DisplayGamePlayScreen(Text.CurrentLocationInfo(_currentLocation), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                //Process all flags, events, stats
                UpdateGameStatus();


                if(CheckGameWon())
                {
                    CitizenActionChoice = CitizenAction.None;
                }
                else
                {
                    CitizenActionChoice = _gameConsoleView.GetActionMenuChoice(_currentMenu);
                }
                

                //
                // choose an action based on the user's menu choice
                //
                switch (CitizenActionChoice)
                {
                    case CitizenAction.None:
                        break;

                    case CitizenAction.CitizenInfo:
                        _gameConsoleView.DisplayCitizenInfo();                        
                        break;

                    case CitizenAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        TriggerEvents();
                        break;

                    case CitizenAction.Interact:
                        Interact();
                        break;

                    case CitizenAction.PickUpItem:
                        PickUpObject();
                        break;

                    case CitizenAction.Talk:
                        TalkTo();
                        break;

                    case CitizenAction.Trade:
                        Trade();
                        break;

                    case CitizenAction.Inventory:
                        _gameConsoleView.DisplayInventory();
                        _currentMenu = ActionMenu.InventoryMenu;
                        break;

                    case CitizenAction.LookAt:
                        _currentObject = _gameMap.GetGameObjectById(_gameConsoleView.DisplayGetGameObjectsToLookAt(0));

                        _gameConsoleView.DisplayObjectInfo(_currentObject);
                        break;

                    case CitizenAction.PutDownItem:
                        PutDownObject();
                        break;

                    case CitizenAction.Travel:
                        UpdateLocation(_gameConsoleView.DisplayGetNextLocation());
                        break;

                    case CitizenAction.AdminMenu:
                        _currentMenu = ActionMenu.AdminMenu;
                        break;

                    case CitizenAction.ListDestinations:
                        _gameConsoleView.DisplayListOfLocations();
                        break;

                    case CitizenAction.ListItems:
                        _gameConsoleView.DisplayListOfGameObjects(_gameMap.GameObjects);
                        break;

                    case CitizenAction.ListNpcs:
                        _gameConsoleView.DisplayListOfNpcs(_gameMap.Npcs);
                        break;

                    case CitizenAction.ReturnToMainMenu:
                        ResetMenu();
                        _gameConsoleView.DisplayLocationInfo();
                        break;

                    case CitizenAction.Exit:
                        _gameConsoleView.DisplayExit();
                        _playingGame = false;
                        break;

                    default:
                        break;
                }
            }

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the player info
        /// </summary>
        private void InitializeMission()
        {
            Citizen Citizen = _gameConsoleView.GetInitialCitizenInfo();

            _gameCitizen.Name = Citizen.Name;
            _gameCitizen.Age = Citizen.Age;
            _gameCitizen.LocationId = 1;
            _gameCitizen.Race = Citizen.Race;
            _gameCitizen.HomePlanet = Citizen.HomePlanet;

            _gameCitizen.Status = Citizen.Statuses.Healthy;
            _gameCitizen.Lives = 3;
            _gameCitizen.Health = 100;
            _gameCitizen.Exp = 0;
            _gameCitizen.Money = 0;
            _gameCitizen.IsStunned = false;
        }

        private void UpdateGameStatus()
        {
            if (!_gameCitizen.HasVisited(_currentLocation.LocationID))
            {
                //add location to list of visited locations
                _gameCitizen.LocationsVisited.Add(_currentLocation.LocationID);

                //add exp for visiting a new location
                _gameCitizen.Exp += _currentLocation.ExperiencePoints;

                //add/subtract hp for triggering an event

            }

            //death
            if(_gameCitizen.Health <= 0)
            {
                if (_gameCitizen.Lives > 0)
                {
                    _gameCitizen.Lives -= 1;
                    _gameCitizen.Health = 100;

                    //respawns you at your quarters
                    UpdateLocation(1);
                }
                else
                {
                    //TODO game over
                }
            }

            //Update status box and menu box info immeadiatly instead of waiting for the screen to update.
            _gameConsoleView.DisplayMenuBox(_currentMenu);
            _gameConsoleView.DisplayStatusBox();
        }

        private void UpdateLocation(int newLocation)
        {
            _gameCitizen.LocationId = newLocation;
            _currentLocation = _gameMap.GetLocationById(newLocation);

            //show new location's info
            _gameConsoleView.DisplayLocationInfo();
        }

        private void TriggerEvents()
        {
            //only do first time events on the first time
            if (!(_currentLocation.EventTypes == null)) {
                if (_currentLocation.EventTypes.Contains(EventTypes.FirstTimeOnly))
                {
                    DoEvent();
                    _currentLocation.Events.Clear();
                }
                else DoEvent();
            }
        }

        private void DoEvent()
        {
            foreach (Events e in _currentLocation.Events)
            {
                switch (e)
                {
                    case Events.Death:
                        _gameCitizen.Health = -9999;
                        break;

                    //TODO other events
                    case Events.MinorDamage:

                        break;

                    case Events.ModerateDamage:

                        break;

                    case Events.SevereDamage:

                        break;

                    case Events.AddNewItem:

                        break;

                    default:

                        break;
                }

                _gameConsoleView.DisplayEventText();
            }
        }

        private void ResetMenu()
        {
            _currentObject = null;
            _currentMenu = ActionMenu.MainMenu;
        }

        //look at a thing and get a menu to interact with it
        private void Interact()
        {
            Dictionary<int, object> mapObjectsInLocation = _gameMap.GetMapObjectyByLocationId(_gameCitizen.LocationId);

            int mapObjectToLookAt = _gameConsoleView.DisplayGetMapObjectsToLookAt(mapObjectsInLocation);

            if (mapObjectToLookAt != 0)
            {
                _currentObject = mapObjectsInLocation[mapObjectToLookAt];

                if (_currentObject is GameObject)
                {
                    _currentMenu = ActionMenu.ObjectMenu;
                }
                else if (_currentObject is Npc)
                {
                    _currentMenu = ActionMenu.NpcMenu;
                }
                else
                {
                    string feedbackMessage = $"The object {_currentObject.name} is a {_currentObject.GetType()}";
                    throw new ArgumentException(_currentObject.ToString(), feedbackMessage);
                }

                _gameConsoleView.DisplayObjectInfo(_currentObject);
            }
        }

        private void TalkTo()
        {
            Npc npc = _currentObject;

            _gameConsoleView.DisplayTalkTo(npc);
        }

        private void Trade()
        {
            Npc npc = _currentObject;

            int tradeItemId = 0; 

            if (npc is Trader)
            {
                Trader trader = npc as Trader;

                Dictionary<int, KeyValuePair<int, GameObject>> tradeInventory = new Dictionary<int, KeyValuePair<int, GameObject>>();

                //make a dictionary of gameobjects where key is the selection and value is price and object
                int i = 0;
                foreach (KeyValuePair<int, int> tradeObject in trader.Inventory)
                {
                    i++;
                    tradeInventory.Add(i, new KeyValuePair<int, GameObject>(tradeObject.Key, _gameMap.GetGameObjectById(tradeObject.Value)));
                }

                if (tradeInventory.Count > 0)
                {
                    tradeItemId = _gameConsoleView.DisplayGetTrade(tradeInventory);

                    if (tradeItemId > 0)
                    {
                        KeyValuePair<int, GameObject> itemToBuy = tradeInventory[tradeItemId];

                        //check if player has enough money
                        if (_gameCitizen.Money > itemToBuy.Key)
                        {
                            GameObject gameObject = itemToBuy.Value;
                            _gameCitizen.Money -= itemToBuy.Key;
                            trader.Inventory.Remove(itemToBuy.Key);

                            //picks up object automatically if it can be picked up, else puts it in that room
                            if (gameObject is CitizenObject)
                            {
                                _gameCitizen.Inventory.Add(gameObject as CitizenObject);
                                gameObject.LocationId = 0;
                            }
                            else
                            {
                                gameObject.LocationId = _gameCitizen.LocationId;
                            }

                            _gameConsoleView.DisplayGamePlayScreen($"You bought the {gameObject.Name}.", ActionMenu.NpcMenu, "");

                        }
                        else
                        {
                            _gameConsoleView.DisplayGamePlayScreen("You don't have enough money for that.", ActionMenu.NpcMenu, "");
                        }
                    }
                    else
                    {
                        _gameConsoleView.DisplayObjectInfo(_currentObject);
                    }
                }
                else
                {
                    _gameConsoleView.DisplayGamePlayScreen("Merchant: \nI'm all out of stock", ActionMenu.NpcMenu, "");
                }
            }
            else
            {
                _gameConsoleView.DisplayGamePlayScreen("They don't have anything to trade.", ActionMenu.NpcMenu, "");
            }
        }
            

        private void PickUpObject()
        {
            bool canPickUp = true;

            if (_currentObject.Id != 0)
            {
                GameObject gameobject = _currentObject;

                if (gameobject is CitizenObject)
                {
                    if ((gameobject as CitizenObject).CanInventory)
                    {
                        _gameCitizen.Inventory.Add(gameobject as CitizenObject);
                        gameobject.LocationId = 0;
                    }
                    else
                    {
                        canPickUp = false;
                    }
                }
                else if (gameobject is TreasureObject)
                {
                    _gameCitizen.Money += (gameobject as TreasureObject).Value;

                    //remove from the game
                    MapObjects.gameObjects.Remove(gameobject);
                }

                _gameConsoleView.DisplayConfirmPickUp(gameobject, canPickUp);

                ResetMenu();
            }
        }

        private void PutDownObject()
        {
            int citizenObjectToPutDownId = _gameConsoleView.DisplayGetCitizenObjectToPutDown();

            if (citizenObjectToPutDownId != 0)
            {
                CitizenObject citizenObject = _gameMap.GetGameObjectById(citizenObjectToPutDownId) as CitizenObject;

                _gameCitizen.Inventory.Remove(citizenObject);
                citizenObject.LocationId = _gameCitizen.LocationId;

                _gameConsoleView.DisplayConfirmDrop(citizenObject);
            }

            _currentMenu = ActionMenu.MainMenu;

            ResetMenu();
        }

        private bool CheckGameWon()
        {
            //check if you're in your room with the pillow
            if (_gameCitizen.LocationId == 1 && _gameCitizen.Inventory.Contains(_gameMap.GetGameObjectById(10)))
            {
                _playingGame = false;
                _currentMenu = ActionMenu.None;

                _gameConsoleView.DisplayGameWon();

                return true;
            }
            else return false;
        }
        #endregion
    }

}
