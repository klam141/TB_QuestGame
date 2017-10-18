using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static class MapObjects
    {
        public static List<Location> Locations = new List<Location>()
        {

            new Location
            {
                CommonName = "Your Room",
                LocationID = 1,
                Description = "Your room. You live here.",
                GeneralContents = "- stuff in the room -",
                CanAccess = new int[] { 2 },
                Accessable = true,
                ExperiencePoints = 10
            },

            new Location
            {
                CommonName = "Hallways",
                LocationID = 2,
                Description = "The hallways outside your room.",
                GeneralContents = "At the end of the hallway is plaza 3. There is also a small storage closet nearby.",
                CanAccess = new int[] { 1, 3, 4 },
                Accessable = true,
                ExperiencePoints = 10
            },

            new Location
            {
                CommonName = "Plaza 3",
                LocationID = 3,
                Description = "The plaza closest to your room",
                GeneralContents ="There are many shops here. You are also near a food court" ,
                CanAccess = new int[] { 2, 5 },
                Accessable = true,
                ExperiencePoints = 20
            },

            new Location
            {
                CommonName = "Storage Closet",
                LocationID = 4,
                Description = "It's a small storage closet.",
                GeneralContents = "Having Learned your lesson the first time you avoid the tack. The Room is pretty uninteresting otherwise",
                CanAccess = new int[] { 2 },
                Accessable = true,
                ExperiencePoints = -10,
                Events = new List<Events>() { Events.Death },
                EventTypes = new List<EventTypes>() { EventTypes.FirstTimeOnly },
                EventDescription = "You step on a tack and die."
            },

            new Location
            {
                CommonName = "Food Court",
                LocationID = 5,
                Description = "You can eat here",
                GeneralContents ="The food court is much smaller than the ones in the larger plazas, but it still has a large vareity of restaurants." ,
                CanAccess = new int[] { 3 },
                Accessable = true,
                ExperiencePoints = 20
            },


        };
    }
}
