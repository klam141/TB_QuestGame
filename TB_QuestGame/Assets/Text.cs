﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TB_QuestGame
{
    /// <summary>
    /// class to store static and to generate dynamic text for the message and input boxes
    /// </summary>
    public static class Text
    {
        public static List<string> HeaderText = new List<string>() { "Deep Space" };
        public static List<string> FooterText = new List<string>() { "David Gosma, 2017" };

        #region INTITIAL GAME SETUP

        public static string MissionIntro()
        {
            string messageBoxText =
            "You are a citizen of the space station The Nimbus 12.\n" +
            "You have been living on the Nimbus for 3 years now. \n" +
            "You are currently sleeping in your quarters near plaza 3 \n" +
            " \n" +
            "You may press escape to exit the game at any time. \n"
            ;

            return messageBoxText;
        }

        public static string CurrentLocationInfo(Location location)
        {
            string messageBoxText =
                $"Current Location: {location.CommonName}\n" +
                " \n" +
                location.Description;

            return messageBoxText;
        }

        #region Initialize Mission Text

        public static string InitializeMissionIntro()
        {
            string messageBoxText =
                "You wake up with a jolt. What a crazy dream, it felt like it went on forever... \n" +
                " \n" +
                "You try to remember who you are";

            return messageBoxText;
        }

        public static string InitializeMissionGetCitizenName()
        {
            string messageBoxText =
                "What was your name again?";

            return messageBoxText;
        }

        public static string InitializeMissionGetCitizenAge(Citizen gameCitizen)
        {
            string messageBoxText =
                "Thats right. And how old are you?";

            return messageBoxText;
        }

        public static string InitializeMissionGetCitizenPlanet(Citizen gameCitizen)
        {
            string messageBoxText =
                "Where are you from again?";

            return messageBoxText;
        }

        /* Unused
        public static string InitializeMissionGetCitizenRace(Citizen gameCitizen)
        {
            string messageBoxText =
                "TODO Text.cs 64";

            string raceList = null;

            foreach (Character.RaceType race in Enum.GetValues(typeof(Character.RaceType)))
            {
                if (race != Character.RaceType.None)
                {
                    raceList += $"\t{race}\n";
                }
            }

            messageBoxText += raceList;

            return messageBoxText;
        }*/

        public static string InitializeMissionEchoCitizenInfo(Citizen gameCitizen)
        {
            string messageBoxText =
                "You remember now. \n" +
                $"Your name is {gameCitizen.Name}. \n" +
                $"You are {gameCitizen.Age} years old. \n" +
                $"You are from {gameCitizen.HomePlanet}. \n \n" +
                "Your bed is really uncomfortable. You'll need a new pillow to go back to sleep.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string LocationTableHeader(bool showIsAccessable)
        {
            //Table header for listing locations
            string messageBoxText;

            string tableLine1 = "ID".PadRight(10) + "Name".PadRight(30);
            string tableLine2 = "---".PadRight(10) + "----------------------".PadRight(30);

            if(showIsAccessable)
            {
                tableLine1 += "Accessible".PadRight(10);
                tableLine2 += "-------".PadRight(10);
            }

            tableLine1 += "\n";
            tableLine2 += "\n";

            messageBoxText = tableLine1 + tableLine2;

            return messageBoxText;
        }

        public static string GameObjectTable(IEnumerable<GameObject> gameObjects, bool showType, bool showLocationId)
        {
            string messageBoxText = "";

            string tableLine1 = "ID".PadRight(10) + "Name".PadRight(30);
            string tableLine2 = "---".PadRight(10) + "----------------------".PadRight(30);

            if(showType)
            {
                tableLine1 += "Type".PadRight(10);
                tableLine2 += "----------------------".PadRight(10);
            }

            if(showLocationId)
            {
                tableLine1 += "LocationId".PadRight(10);
                tableLine2 += "----------------------".PadRight(10);
            }

            tableLine1 += "\n";
            tableLine2 += "\n";

            string objectList = null;
            foreach (GameObject gameObject in gameObjects)
            {
                objectList +=
                    $"{gameObject.Id}".PadRight(10) +
                    $"{gameObject.Name}".PadRight(30);
                
                if (showLocationId) objectList += $"{gameObject.LocationId}".PadRight(10);

                objectList += Environment.NewLine;
            }

            if (objectList != null)
            {
                messageBoxText = "Objects \n" + tableLine1 + tableLine2 + objectList;
            }

            return messageBoxText;
        }

        public static string NpcTable(IEnumerable<Npc> npcs, bool showLocationId)
        {
            string messageBoxText = "";

            string tableLine1 = "ID".PadRight(10) + "Name".PadRight(30);
            string tableLine2 = "---".PadRight(10) + "----------------------".PadRight(30);

            if (showLocationId)
            {
                tableLine1 += "LocationId".PadRight(10);
                tableLine2 += "----------------------".PadRight(10);
            }

            tableLine1 += "\n";
            tableLine2 += "\n";

            string npcList = null;
            foreach (Npc npc in npcs)
            {
                npcList +=
                    $"{npc.Id}".PadRight(10) +
                    $"{npc.Name}".PadRight(30);

                if (showLocationId) npcList += $"{npc.LocationId}".PadRight(10);

                npcList += Environment.NewLine;
            }

            if (npcList != null)
            {
                messageBoxText = "NPCs \n" + tableLine1 + tableLine2 + npcList;
            }

            return messageBoxText;
        }

        public static string CitizenInfo(Citizen gameCitizen)
        {
            string messageBoxText =
                $"Name: { gameCitizen.Name} \n" +
                $"Age: {gameCitizen.Age} \n" +
                $"Home Planet: {gameCitizen.HomePlanet} \n" +
                " \n" +
                $"Citizen Greeting: {gameCitizen.Greeting()} \n" +
                " \n";


            return messageBoxText;
        }

        public static List<string> StatusBox(Citizen gameCitizen, GameMap gameMap)
        {
            List<string> statusBoxText = new List<string>();
            
            statusBoxText.Add($"Lives: {gameCitizen.Lives}\n");
            statusBoxText.Add($"Health: {gameCitizen.Health}\n");
            statusBoxText.Add($"Money: {gameCitizen.Money}\n");
            statusBoxText.Add($"Experience Points: {gameCitizen.Exp}\n");

            return statusBoxText;
        }

        public static string LookAround(Location location, IEnumerable<GameObject> gameObjects, IEnumerable<Npc> npcs)
        {
            string messageBoxText = 
                $"Current Location: {location.CommonName}\n" +
                " \n" +
                location.GeneralContents +
                Environment.NewLine + Environment.NewLine +

                GameObjectTable(gameObjects, false, false) +
                Environment.NewLine + Environment.NewLine +
                NpcTable(npcs, false);

            return messageBoxText;
        }
        
        public static string ListLocations(IEnumerable<Location> Locations)
        {
            string messageBoxText =
                //Display Table Header
                LocationTableHeader(false);

            string LocationList = null;
            foreach (Location location in Locations)
            {
                LocationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            return messageBoxText += LocationList;
        }

        public static string InvalidAction()
        {
            return "I don't recognise that command.";
        }

        public static string Travel(Citizen gameCitizen, Location currentLocation, List<Location> locations)
        {
            string messageBoxText =
                $"Where do you want to go?\n" +
                " \n" +
                "Enter the ID number of your desired location from the table below.\n" +
                " \n" +
                //Display Table Header
                LocationTableHeader(true);


            string locationList = null;
            foreach (Location location in locations)
            {
                if (location.LocationID != gameCitizen.LocationId && currentLocation.CanAccess.Contains(location.LocationID))
                {
                    locationList +=
                        $"{location.LocationID}".PadRight(10) +
                        $"{location.CommonName}".PadRight(30) +
                        $"{location.Accessable}".PadRight(10) +
                        Environment.NewLine;
                }
            }

            messageBoxText += locationList;

            return messageBoxText;
        }

        public static string VisitedLocations(IEnumerable<Location> locations)
        {
            string messageBoxText = 
                "Locations Visited\n" +
                " \n" +
                LocationTableHeader(false);

            string locationList = null;
            foreach(Location location in locations)
            {
                locationList +=
                    $"{location.LocationID}".PadRight(10) +
                    $"{location.CommonName}".PadRight(30) +
                    Environment.NewLine;
            }

            messageBoxText += locationList;

            return messageBoxText;
        }

        //TODO: Use actual events
        public static string EventText(Location location)
        {
            string messageBoxText = location.EventDescription;

            return messageBoxText;
        }

        public static string ListGameObjects(IEnumerable<GameObject> gameObjects, bool showType, bool showLocationId)
        {
            string messageBoxText = "Objects: \n \n";

            messageBoxText += GameObjectTable(gameObjects, showType, showLocationId);

            return messageBoxText;
        }

        public static string ListNpcs(IEnumerable<Npc> npcs, bool showLocationId)
        {
            string messageBoxText = "Npcs: \n \n";

            messageBoxText += NpcTable(npcs, showLocationId);

            return messageBoxText;
        }

        public static string TalkTo(Civilian civilian)
        {
            string messageBoxText = civilian.Name + ":" + Environment.NewLine;

            messageBoxText += civilian.Speak();

            return messageBoxText;
        }

        public static string ListMapObjects(Dictionary<int, Object> mapObjects)
        {
            string messageBoxText = "";

            messageBoxText += 
                "ID".PadRight(10) + "Name".PadRight(30) + " \n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + " \n";

            string mapObjectList = null;
            foreach (KeyValuePair<int, object> mapObject in mapObjects)
            {
                mapObjectList += $"{mapObject.Key}".PadRight(10);

                //cast objects in dictionary so they have a name
                if(mapObject.Value is GameObject)
                {
                    mapObjectList += $"{(mapObject.Value as GameObject).Name}".PadRight(30);
                }
                if(mapObject.Value is Npc)
                {
                    mapObjectList += $"{(mapObject.Value as Npc).Name}".PadRight(30);
                }

                mapObjectList += Environment.NewLine;
            }

            return messageBoxText += mapObjectList;
        }

        public static string LookAt(dynamic gameObject)
        {

            string messageBoxText = 
                $"{gameObject.Name} \n \n" +
                $"{gameObject.Description} \n \n";

            if (gameObject is CitizenObject)
            {
                CitizenObject citizenObject = gameObject as CitizenObject;

                //Dont display caninventory if already in inventory
                if(citizenObject.LocationId != 0)
                {
                    messageBoxText += $"The {citizenObject.Name} ";

                    if (citizenObject.CanInventory) messageBoxText += "can be added to your inventory.";
                    else messageBoxText += "can not be added to your inventory.";
                }
            }
            else if(gameObject is TreasureObject)
            {
                TreasureObject treasureObject = gameObject as TreasureObject;

                messageBoxText += $"The {treasureObject.Name} has a value of {treasureObject.Value}";
            }     

            return messageBoxText;
        }

        public static string CurrentInventory(IEnumerable<CitizenObject> inventory)
        {
            string messageBoxText = "Inventory \n \n";

            messageBoxText += GameObjectTable(inventory, true, false);

            return messageBoxText;
        }

        public static string TradeMenu(Dictionary<int, KeyValuePair<int, GameObject>> tradeInventory)
        {
            string messageBoxText = "Items for sale: \n \n";

            messageBoxText +=
                "ID".PadRight(10) + "Item".PadRight(30) + "Price".PadRight(10) + " \n" +
                "---".PadRight(10) + "----------------------".PadRight(30) + "---".PadRight(10) + " \n";

            string tradeList = "";

            foreach(KeyValuePair<int, KeyValuePair<int, GameObject>> tradeItem in tradeInventory) {
                tradeList +=
                    tradeItem.Key.ToString().PadRight(10) +
                    tradeItem.Value.Value.Name.PadRight(30) +
                    tradeItem.Value.Key.ToString().PadRight(10) +
                    Environment.NewLine;
            }

            messageBoxText += tradeList;

            return messageBoxText;
        }

        public static string GameWon()
        {
            string messageBoxText = 
                "With your new pillow you can finally go back to sleep. \n" +
                "You lay down in your bed and doze off. \n \n" +
                "YOU WIN \n" +
                "Thanks For Playing!";

            return messageBoxText;
        }

        #endregion
    }
}
