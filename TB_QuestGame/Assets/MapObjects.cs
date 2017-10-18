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
                CommonName = "Aion Base Lab",
                LocationID = 1,
                Date = 386759,
                MapLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Norlon Corporation research facility located in " +
                    "the city of Heraklion on the north coast of Crete and the top secret " +
                    "research lab for the Aion Project.\n",
                GeneralContents =  "The lab is a large, well lit room, and staffed " +
                    "by a small number of scientists, all wearing light blue uniforms with the " +
                    "hydra-like Norlan Corporation logo. \n",
                Accessable = true,
                ExperiencePoints = 10
            },

            new Location
            {
                CommonName = "Felandrian Plains",
                LocationID = 2,
                Date = 386759,
                MapLocation = "P-2, SS-85, G-2976, LS-3976",
                Description = "The Felandrian Plains are a common destination for tourist. " +
                    "Located just north of the equatorial line on the planet of Corlon, they " +
                    "provide excellent habitat for a rich ecosystem of flora and fauna.",
                GeneralContents = "- stuff in the room -",
                Accessable = true,
                ExperiencePoints = 10
            },

            new Location
            {
                CommonName = "Xantoria Market",
                LocationID = 3,
                Date = 386759,
                MapLocation = "P-6, SS-3978, G-2976, LS-3976",
                Description = "The Xantoria market, once controlled by the Thorian elite, is now an " +
                              "open market managed by the Xantorian Commerce Coop. It is a place " +
                              "where many races from various systems trade goods.",
                GeneralContents ="- stuff in the room -" ,
                Accessable = false,
                ExperiencePoints = 20
            },

            new Location
            {
                CommonName = "Norlon Corporate Headquarters",
                LocationID = 4,
                Date = 386759,
                MapLocation = "P-3, SS-278, G-2976, LS-3976",
                Description = "The Norlon Corporation Headquarters is located in just outside of Detroit Michigan." +
                              "Norlon, founded in 1985 as a bio-tech company, is now a 36 billion dollar company " +
                              "with huge holdings in defense and space research and development.",
                GeneralContents = "Having Learned your lesson the first time you avoid the tack. The Room is pretty uninteresting otherwise",
                Accessable = true,
                ExperiencePoints = -10,
                Events = new List<Events>() { Events.Death },
                EventTypes = new List<EventTypes>() { EventTypes.FirstTimeOnly },
                EventDescription = "You step on a tack and die."
            },

            new Location
            {
                CommonName = "Your Room",
                LocationID = 5,
                Date = 1,
                MapLocation = "1",
                Description = "Your room. You live here.",
                GeneralContents = "- stuff in the room -",
                Accessable = true,
                ExperiencePoints = 10
            }
        };
    }
}
