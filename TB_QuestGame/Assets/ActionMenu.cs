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
                { '2', CitizenAction.LookAround },
                { '3', CitizenAction.Interact },
                { '4', CitizenAction.Inventory },
                { '5', CitizenAction.Travel },
                { '6', CitizenAction.AdminMenu },
                { '0', CitizenAction.Exit }
            }
        };

        public static Menu ObjectMenu = new Menu()
        {
            MenuName = "ObjectMenu",
            MenuTitle = "Object Menu",
            MenuChoices = new Dictionary<char, CitizenAction>()
            {
                { '1', CitizenAction.PickUpItem },
                { '0', CitizenAction.ReturnToMainMenu }
            }
        };

        public static Menu NpcMenu = new Menu()
        {
            MenuName = "NpcMenu",
            MenuTitle = "NPC Menu",
            MenuChoices = new Dictionary<char, CitizenAction>()
            {
                { '1', CitizenAction.Talk },
                //{ '2', CitizenAction.Trade },
                { '0', CitizenAction.ReturnToMainMenu }
            }
        };

        public static Menu InventoryMenu = new Menu()
        {
            MenuName = "InventoryMenu",
            MenuTitle = "Inventory Menu",
            MenuChoices = new Dictionary<char, CitizenAction>()
            {
                { '1', CitizenAction.LookAt },
                { '2', CitizenAction.PutDownItem },
                { '0', CitizenAction.ReturnToMainMenu }
            }
        };

        public static Menu AdminMenu = new Menu()
        {
            MenuName = "AdminMenu",
            MenuTitle = "Admin Menu",
            MenuChoices = new Dictionary<char, CitizenAction>()
            {
                { '1', CitizenAction.ListDestinations },
                { '2', CitizenAction.ListItems },
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
                { ' ', CitizenAction.None }
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
