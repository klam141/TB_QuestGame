using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// view class
    /// </summary>
    public class ConsoleView
    {
        #region ENUMS

        private enum ViewStatus
        {
            TravelerInitialization,
            PlayingGame
        }

        #endregion

        #region FIELDS

        //
        // declare game objects for the ConsoleView object to use
        //
        Citizen _gameCitizen;
        Map _gameMap;

        ViewStatus _viewStatus;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Citizen gameCitizen, Map gameMap)
        {
            _gameCitizen = gameCitizen;
            _gameMap = gameMap;

            _viewStatus = ViewStatus.TravelerInitialization;

            InitializeDisplay();
        }

        #endregion

        #region METHODS
        /// <summary>
        /// display all of the elements on the game play screen on the console
        /// </summary>
        /// <param name="messageBoxHeaderText">message box header title</param>
        /// <param name="messageBoxText">message box text</param>
        /// <param name="menu">menu to use</param>
        /// <param name="inputBoxPrompt">input box text</param>
        public void DisplayGamePlayScreen(string messageBoxHeaderText, string messageBoxText, Menu menu, string inputBoxPrompt)
        {
            //
            // reset screen to default window colors
            //
            Console.BackgroundColor = ConsoleTheme.WindowBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.WindowForegroundColor;
            Console.Clear();

            ConsoleWindowHelper.DisplayHeader(Text.HeaderText);
            ConsoleWindowHelper.DisplayFooter(Text.FooterText);

            DisplayMessageBox(messageBoxHeaderText, messageBoxText);
            DisplayMenuBox(menu);
            DisplayInputBox();
            DisplayStatusBox();
        }

        /// <summary>
        /// wait for any keystroke to continue
        /// </summary>
        public void GetContinueKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// get a action menu choice from the user
        /// </summary>
        /// <returns>action menu choice</returns>
        public CitizenAction GetActionMenuChoice(Menu menu)
        {
            Console.CursorVisible = false;

            char[] validKeys = menu.MenuChoices.Keys.ToArray();
            char keyPressed;

            do
            {
                ConsoleKeyInfo kpi = Console.ReadKey(true);  //kpi is short for key pressed info
                keyPressed = kpi.KeyChar;
            } while (!validKeys.Contains(keyPressed));

            Console.CursorVisible = true;
            
            return menu.MenuChoices[keyPressed];
        }

        /// <summary>
        /// get a string value from the user
        /// </summary>
        /// <returns>string value</returns>2
        public string GetString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// get an integer value from the user
        /// </summary>
        /// <returns>integer value</returns>
        public bool GetInteger(string prompt, int minimumValue, int maximumValue, out int integerChoice)
        {
            bool validResponse = false;
            integerChoice = 0;

            DisplayInputBoxPrompt(prompt);
            while (!validResponse)
            {
                if (int.TryParse(Console.ReadLine(), out integerChoice))
                {
                    if (integerChoice >= minimumValue && integerChoice <= maximumValue)
                    {
                        validResponse = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                        DisplayInputBoxPrompt(prompt);
                    }
                }
                else
                {
                    ClearInputBox();
                    DisplayInputErrorMessage($"You must enter an integer value between {minimumValue} and {maximumValue}. Please try again.");
                    DisplayInputBoxPrompt(prompt);
                }
            }

            return true;
        }

        /* Unused
        /// <summary>
        /// get a character race value from the user
        /// </summary>
        /// <returns>character race value</returns>
        public Character.RaceType GetRace()
        {
            Character.RaceType raceType;
            Enum.TryParse<Character.RaceType>(Console.ReadLine(), out raceType);

            return raceType;
        }*/

        /// <summary>
        /// display splash screen
        /// </summary>
        /// <returns>player chooses to play</returns>
        public bool DisplaySpashScreen()
        {
            bool playing = true;
            ConsoleKeyInfo keyPressed;

            Console.BackgroundColor = ConsoleTheme.SplashScreenBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.SplashScreenForegroundColor;
            Console.Clear();
            Console.CursorVisible = false;


            Console.SetCursorPosition(0, 10);
            string tabSpace = new String(' ', 24); //24 comes from half the length of the strings below(112) subtracted from the console width(160) (160 - 112) / 2 = 24 
            Console.WriteLine(tabSpace + @"####        ########    ########    ######               ######     ######        ####        ####      ########");
            Console.WriteLine(tabSpace + @"|| ###      ||######    ||######    ||   ###            ##    ##    ||   ###     ######     ###  ###    ||######");
            Console.WriteLine(tabSpace + @"||   ##     ||          ||          ||    ##            ##    ##    ||    ##     ##  ##     ##    ##    ||      ");
            Console.WriteLine(tabSpace + @"||    ##    ||######    ||######    ||   ###             ####       ||   ###     ##  ##     ##          ||######");
            Console.WriteLine(tabSpace + @"||    ##    ||######    ||######    ||####                 ####     ||####      ########    ##          ||######");
            Console.WriteLine(tabSpace + @"||   ##     ||          ||          ||                  ##    ##    ||          ##    ##    ##    ##    ||      ");
            Console.WriteLine(tabSpace + @"|| ###      ||######    ||######    ||                  ##    ##    ||          ##    ##    ###  ###    ||######");
            Console.WriteLine(tabSpace + @"####        ########    ########    ##                   ######     ##          ##    ##      ####      ########");

            Console.SetCursorPosition(80, 25);
            Console.Write("Press any key to continue or Esc to exit.");
            keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.Escape)
            {
                playing = false;
            }

            return playing;
        }

        /// <summary>
        /// initialize the console window settings
        /// </summary>
        private static void InitializeDisplay()
        {
            //
            // control the console window properties
            //
            ConsoleWindowControl.DisableResize();
            ConsoleWindowControl.DisableMaximize();
            ConsoleWindowControl.DisableMinimize();
            Console.Title = "Deep Space";

            //
            // set the default console window values
            //
            ConsoleWindowHelper.InitializeConsoleWindow();

            Console.CursorVisible = false;
        }

        /// <summary>
        /// display the correct menu in the menu box of the game screen
        /// </summary>
        /// <param name="menu">menu for current game state</param>
        private void DisplayMenuBox(Menu menu)
        {
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuBorderColor;

            //
            // display menu box border
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MenuBoxPositionTop,
                ConsoleLayout.MenuBoxPositionLeft,
                ConsoleLayout.MenuBoxWidth,
                ConsoleLayout.MenuBoxHeight);

            //
            // display menu box header
            //
            Console.BackgroundColor = ConsoleTheme.MenuBorderColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 2, ConsoleLayout.MenuBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(menu.MenuTitle, ConsoleLayout.MenuBoxWidth - 4));

            //
            // display menu choices
            //
            Console.BackgroundColor = ConsoleTheme.MenuBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MenuForegroundColor;
            int topRow = ConsoleLayout.MenuBoxPositionTop + 3;

            foreach (KeyValuePair<char, CitizenAction> menuChoice in menu.MenuChoices)
            {
                if (menuChoice.Value != CitizenAction.None)
                {
                    string formatedMenuChoice = ConsoleWindowHelper.ToLabelFormat(menuChoice.Value.ToString());
                    Console.SetCursorPosition(ConsoleLayout.MenuBoxPositionLeft + 3, topRow++);
                    Console.Write($"{menuChoice.Key}. {formatedMenuChoice}");
                }
            }
        }

        /// <summary>
        /// display the text in the message box of the game screen
        /// </summary>
        /// <param name="headerText"></param>
        /// <param name="messageText"></param>
        private void DisplayMessageBox(string headerText, string messageText)
        {
            //
            // display the outline for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxBorderColor;
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.MessageBoxPositionTop,
                ConsoleLayout.MessageBoxPositionLeft,
                ConsoleLayout.MessageBoxWidth,
                ConsoleLayout.MessageBoxHeight);

            //
            // display message box header
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBorderColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, ConsoleLayout.MessageBoxPositionTop + 1);
            Console.Write(ConsoleWindowHelper.Center(headerText, ConsoleLayout.MessageBoxWidth - 4));

            //
            // display the text for the message box
            //
            Console.BackgroundColor = ConsoleTheme.MessageBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.MessageBoxForegroundColor;
            List<string> messageTextLines = new List<string>();
            messageTextLines = ConsoleWindowHelper.MessageBoxWordWrap(messageText, ConsoleLayout.MessageBoxWidth - 4);

            int startingRow = ConsoleLayout.MessageBoxPositionTop + 3;
            int endingRow = startingRow + messageTextLines.Count();
            int row = startingRow;
            foreach (string messageTextLine in messageTextLines)
            {
                Console.SetCursorPosition(ConsoleLayout.MessageBoxPositionLeft + 2, row);
                Console.Write(messageTextLine);
                row++;
            }

        }

        /// <summary>
        /// draw the status box on the game screen
        /// </summary>
        public void DisplayStatusBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            //
            // display the outline for the status box
            //
            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.StatusBoxPositionTop,
                ConsoleLayout.StatusBoxPositionLeft,
                ConsoleLayout.StatusBoxWidth,
                ConsoleLayout.StatusBoxHeight);

            //
            // display the text for the status box if playing game
            //
            if (_viewStatus == ViewStatus.PlayingGame)
            {
                //
                // display status box header with title
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("Game Stats", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;

                //
                // display stats
                //
                int startingRow = ConsoleLayout.StatusBoxPositionTop + 3;
                int row = startingRow;
                foreach (string statusTextLine in Text.StatusBox(_gameCitizen, _gameMap))
                {
                    Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 3, row);
                    Console.Write(statusTextLine);
                    row++;
                }
            }
            else
            {
                //
                // display status box header without header
                //
                Console.BackgroundColor = ConsoleTheme.StatusBoxBorderColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
                Console.SetCursorPosition(ConsoleLayout.StatusBoxPositionLeft + 2, ConsoleLayout.StatusBoxPositionTop + 1);
                Console.Write(ConsoleWindowHelper.Center("", ConsoleLayout.StatusBoxWidth - 4));
                Console.BackgroundColor = ConsoleTheme.StatusBoxBackgroundColor;
                Console.ForegroundColor = ConsoleTheme.StatusBoxForegroundColor;
            }
        }

        /// <summary>
        /// draw the input box on the game screen
        /// </summary>
        public void DisplayInputBox()
        {
            Console.BackgroundColor = ConsoleTheme.InputBoxBackgroundColor;
            Console.ForegroundColor = ConsoleTheme.InputBoxBorderColor;

            ConsoleWindowHelper.DisplayBoxOutline(
                ConsoleLayout.InputBoxPositionTop,
                ConsoleLayout.InputBoxPositionLeft,
                ConsoleLayout.InputBoxWidth,
                ConsoleLayout.InputBoxHeight);
        }

        /// <summary>
        /// display the prompt in the input box of the game screen
        /// </summary>
        /// <param name="prompt"></param>
        public void DisplayInputBoxPrompt(string prompt)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 1);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.Write(prompt);
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the error message in the input box of the game screen
        /// </summary>
        /// <param name="errorMessage">error message text</param>
        public void DisplayInputErrorMessage(string errorMessage)
        {
            Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + 2);
            Console.ForegroundColor = ConsoleTheme.InputBoxErrorMessageForegroundColor;
            Console.Write(errorMessage);
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// clear the input box
        /// </summary>
        private void ClearInputBox()
        {
            string backgroundColorString = new String(' ', ConsoleLayout.InputBoxWidth - 4);

            Console.ForegroundColor = ConsoleTheme.InputBoxBackgroundColor;
            for (int row = 1; row < ConsoleLayout.InputBoxHeight - 2; row++)
            {
                Console.SetCursorPosition(ConsoleLayout.InputBoxPositionLeft + 4, ConsoleLayout.InputBoxPositionTop + row);
                DisplayInputBoxPrompt(backgroundColorString);
            }
            Console.ForegroundColor = ConsoleTheme.InputBoxForegroundColor;
        }

        /// <summary>
        /// get the player's initial information at the beginning of the game
        /// </summary>
        /// <returns>Citizen object with all properties updated</returns>
        public Citizen GetInitialCitizenInfo()
        {
            Citizen Citizen = new Citizen();

            //
            // intro
            //
            DisplayGamePlayScreen("Your Quarters", Text.InitializeMissionIntro(), ActionMenu.MissionIntro, "");
            GetContinueKey();

            //
            // get Citizen's name
            //
            DisplayGamePlayScreen("Your Quarters", Text.InitializeMissionGetCitizenName(), ActionMenu.MissionIntro, "");
            DisplayInputBoxPrompt("Enter your name: ");
            Citizen.Name = GetString();

            //
            // get Citizen's age
            //
            DisplayGamePlayScreen("Your Quarters", Text.InitializeMissionGetCitizenAge(Citizen), ActionMenu.MissionIntro, "");
            int gameCitizenAge;

            GetInteger($"Enter your age, {Citizen.Name}: ", 0, 1000000, out gameCitizenAge);
            Citizen.Age = gameCitizenAge;

            //
            // get home planet
            //
            DisplayGamePlayScreen("Your Quarters", Text.InitializeMissionGetCitizenPlanet(Citizen), ActionMenu.MissionIntro, "");

            DisplayInputBoxPrompt($"Enter your home planet, {Citizen.Name}: ");
            Citizen.HomePlanet = GetString();

            //
            // echo the Citizen's info
            //
            DisplayGamePlayScreen("Your Quarters", Text.InitializeMissionEchoCitizenInfo(Citizen), ActionMenu.MissionIntro, "");
            GetContinueKey();

            // 
            // change view status to playing game
            //
            _viewStatus = ViewStatus.PlayingGame;


            return Citizen;
        }        

        public void DisplayEventText()
        {
            Location currentLocation = _gameMap.GetLocationById(_gameCitizen.LocationID);
            DisplayGamePlayScreen("", Text.EventText(currentLocation), ActionMenu.None, "");

            GetContinueKey();
        }

        #region ----- display responses to menu action choices -----

        public void DisplayCitizenInfo()
        {
            DisplayGamePlayScreen("Citizen Information", Text.CitizenInfo(_gameCitizen), ActionMenu.MainMenu, "");
            Console.Write(_gameCitizen.HomePlanet);
        }

        public void DisplayLookAround()
        {
            Location currentLocation = _gameMap.GetLocationById(_gameCitizen.LocationID);
            DisplayGamePlayScreen("Current Location", Text.LookAround(currentLocation), ActionMenu.MainMenu, "");
        }

        public void DisplayListOfLocations()
        {
            DisplayGamePlayScreen("Locations", Text.ListLocations(_gameMap.Locations), ActionMenu.MainMenu, "");
        }

        public int DisplayGetNextLocation()
        {
            int locationId = 0;
            bool validLocation = false;

            DisplayGamePlayScreen("Travel to a new Location", Text.Travel(_gameCitizen, _gameMap.Locations), ActionMenu.MainMenu, "");

            while(!validLocation)
            {
                //get an int from the player
                GetInteger($"Enter your new location {_gameCitizen.Name}: ", 1, _gameMap.GetMaxLocationId(), out locationId);

                //validate int
                if(_gameMap.isValidLocation(locationId))
                {
                    if(_gameMap.IsAccessibleLocation(locationId))
                    {
                        validLocation = true;
                    }
                    else
                    {
                        ClearInputBox();
                        DisplayInputErrorMessage("That is an inaccessible location. Please try again.");
                    }
                }
                else
                {
                    DisplayInputErrorMessage("That is an invalid location. Please try again.");
                }
            }
            
            return locationId;
        }

        public void DisplayLocationsVisited()
        {
            List<Location> visitedLocations = new List<Location>();
            foreach(int locationId in _gameCitizen.LocationsVisited)
            {
                visitedLocations.Add(_gameMap.GetLocationById(locationId));
            }

            DisplayGamePlayScreen("Locations Visited", Text.VisitedLocations(visitedLocations), ActionMenu.MainMenu, "");
        }


        public void DisplayExit() {
            DisplayGamePlayScreen("", "Thanks for playing!", ActionMenu.ExitMenu, "");
            GetContinueKey();
        }

        #endregion

        #endregion
    }
}
