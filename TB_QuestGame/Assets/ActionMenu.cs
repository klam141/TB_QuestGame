using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// static class to hold key/value pairs for menu options
    /// </summary>
    public static class ActionMenu
    {

        public static Menu None = new Menu()
        {
            MenuName = "",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, CitizenAction>()
                    {
                        { ' ', CitizenAction.None }
                    }
        };

        public static Menu MissionIntro = new Menu()
        {
            MenuName = "MissionIntro",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, CitizenAction>()
                    {
                        { ' ', CitizenAction.None }
                    }
        };

        public static Menu InitializeMission = new Menu()
        {
            MenuName = "InitializeMission",
            MenuTitle = "Initialize Mission",
            MenuChoices = new Dictionary<char, CitizenAction>()
                {
                    { '1', CitizenAction.Exit }
                }
        };

        public static Menu MainMenu = new Menu()
        {
            MenuName = "MainMenu",
            MenuTitle = "Main Menu",
            MenuChoices = new Dictionary<char, CitizenAction>()
                {
                    { '1', CitizenAction.CitizenInfo },
                    { '2', CitizenAction.LookAround},
                    { '3', CitizenAction.LookAt},
                    { '4', CitizenAction.PickUpItem},
                    { '5', CitizenAction.PutDownItem},
                    { '6', CitizenAction.Inventory},
                    { '7', CitizenAction.Travel},
                    { '8', CitizenAction.CitizenLocationsVisited},
                    { '9', CitizenAction.AdminMenu},
                    { '0', CitizenAction.Exit }
        }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, CitizenAction>()
            {
                { '1', CitizenAction.ListDestinations },
                { '2', CitizenAction.ListItems},
                { '3', CitizenAction.ListNpcs },
                { '0', CitizenAction.ReturnToMainMenu}
            }
        };

        public static Menu ExitMenu = new Menu()
        {
            MenuName = "Exit",
            MenuTitle = "",
            MenuChoices = new Dictionary<char, CitizenAction>()
            {
                { ' ', CitizenAction.None}
            }
        };

        //public static Menu ManageCitizen = new Menu()
        //{
        //    MenuName = "ManageCitizen",
        //    MenuTitle = "Manage Citizen",
        //    MenuChoices = new Dictionary<char, PlayerAction>()
        //            {
        //                PlayerAction.MissionSetup,
        //                PlayerAction.CitizenInfo,
        //                PlayerAction.Exit
        //            }
        //};
    }
}
