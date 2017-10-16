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
        private Map _gameMap;
        private bool _playingGame;

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
            _gameMap = new Map();
            _gameConsoleView = new ConsoleView(_gameCitizen, _gameMap);
            _playingGame = true;

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
            _gameConsoleView.DisplayGamePlayScreen("Mission Intro", Text.MissionIntro(), ActionMenu.MissionIntro, "");
            _gameConsoleView.GetContinueKey();

            //
            // initialize the mission Citizen
            // 
            InitializeMission();

            //
            // prepare game play screen
            //
            _gameConsoleView.DisplayGamePlayScreen("Current Location", Text.CurrrentLocationInfo(), ActionMenu.MainMenu, "");

            //
            // game loop
            //
            while (_playingGame)
            {
                CitizenActionChoice = _gameConsoleView.GetActionMenuChoice(ActionMenu.MainMenu);
                

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

                    case CitizenAction.ListDestinations:
                        _gameConsoleView.DisplayListOfLocations();
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
            _gameCitizen.Race = Citizen.Race;
            _gameCitizen.HomePlanet = Citizen.HomePlanet;
        }

        #endregion
    }
}
