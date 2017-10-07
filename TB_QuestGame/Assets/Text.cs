using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            "You are a citizen aboard the space station Nimbus 12.\n" +
            "You have been living on the Nimbus ever since you moved " + 
            "from the Tiny Dog Planet 3 years ago. \n" +
            "You are currently sleeping in your quarters near plaza 3 \n" +
            " \n" +
            "You may press escape to exit the game at any time. \n"
            ;

            return messageBoxText;
        }

        public static string CurrrentLocationInfo()
        {
            string messageBoxText =
            "You are standing in your quarters. The light is off and you cannot see.";

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

        public static string InitializeMissionGetTravelerName()
        {
            string messageBoxText =
                "What was your name again?";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerAge(Citizen gameTraveler)
        {
            string messageBoxText =
                "Thats right. And how old are you?";

            return messageBoxText;
        }

        public static string InitializeMissionGetTravelerPlanet(Citizen gameTraveler)
        {
            string messageBoxText =
                "Where are you from again?";

            return messageBoxText;
        }

        /* Unused
        public static string InitializeMissionGetTravelerRace(Citizen gameTraveler)
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

        public static string InitializeMissionEchoTravelerInfo(Citizen gameTraveler)
        {
            string messageBoxText =
                "You remember now. \n" +
                $"Your name is {gameTraveler.Name}. \n" +
                $"You are {gameTraveler.Age} years old. \n" +
                $"You are from {gameTraveler.HomePlanet}.";

            return messageBoxText;
        }

        #endregion

        #endregion

        #region MAIN MENU ACTION SCREENS

        public static string TravelerInfo(Citizen gameTraveler)
        {
            string messageBoxText =
                $"Name: { gameTraveler.Name} \n" +
                $"Age: {gameTraveler.Age} \n" +
                $"Home Planet: {gameTraveler.HomePlanet} \n" +
                " \n" +
                $"Traveler Greeting: {gameTraveler.Greeting()} \n" +
                " \n";


            return messageBoxText;
        }

        //public static string Travel(int currentSpaceTimeLocationId, List<SpaceTimeLocation> spaceTimeLocations)
        //{
        //    string messageBoxText =
        //        $"{gameTraveler.Name}, Aion Base will need to know the name of the new location.\n" +
        //        " \n" +
        //        "Enter the ID number of your desired location from the table below.\n" +
        //        " \n";


        //    string spaceTimeLocationList = null;

        //    foreach (SpaceTimeLocation spaceTimeLocation in spaceTimeLocations)
        //    {
        //        if (race != Character.RaceType.None)
        //        {
        //            raceList += $"\t{race}\n";
        //        }
        //    }

        //    messageBoxText += raceList;

        //    return messageBoxText;
        //}

        #endregion
    }
}
