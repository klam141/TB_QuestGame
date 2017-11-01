using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class MapObjects
    {
        public static List<GameObject> gameObjects = new List<GameObject>()
        {
            new CitizenObject
            {
                Id = 1,
                Name = "Bag of Gold",
                LocationId = 2,
                Description = "A small leather pouch filled with 9 gold coins.",
                Type = ObjectType.Currency,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 2,
                Name = "Ruby of Saron",
                LocationId = 3,
                Description = "A bright red jewel, roughly the size of a robin's egg.",
                Type = ObjectType.Currency,
                Value = 45,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 3,
                Name = "Rotogenic Medicine",
                LocationId = 3,
                Description = "A wooden box containing a small vial filled with a blue liquid.",
                Type = ObjectType.Medicine,
                Value = 45,
                CanInventory = false,
                IsConsumable = true,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 4,
                Name = "Norlan Document ND-3075",
                LocationId = 3,
                Description =
                    "Memo: Origin Errata" + "/n" +
                    "Universal Date: 378598" + "/n" +
                    "/n" +
                    "It appears a potential origin for the technology is based on Plenatia 5 in the Star Reach Galaxy.",
                Type = ObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 8,
                Name = "Aion Tracker",
                LocationId = 0,
                Description =
                    "Standard issue device worn around wrist that allows for tracking and messaging.",
                Type = ObjectType.Information,
                Value = 0,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 9,
                Name = "RatPak 47",
                LocationId = 0,
                Description =
                    "Standard issue ration package contain nutrients for 72 hours.",
                Type = ObjectType.Food,
                Value = 0,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            }
            /*
            new LocationObject
            {
                Id = 5,
                Name = "Boldendorian Chest",
                LocationId = 2,
                Description = "A large wooden chest adorned with jewels.",
                IsDeadly = true
            },

            new LocationObject
            {
                Id = 6,
                Name = "Silver Mirror",
                LocationId = 2,
                Description = "A small silver mirror hanging on the wall next to a small window.",
                IsDeadly = true
            }
            */
        };
    }
}
