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
            new TreasureObject
            {
                Id = 1,
                Name = "Bag of Money",
                LocationId = 2,
                Description = "A small pouch filled with some coins.",
                Value = 45,
                IsVisible = true
            },

            new TreasureObject
            {
                Id = 2,
                Name = "Ruby",
                LocationId = 3,
                Description = "A bright red jewel, roughly the size of a robin's egg... \n Why is this on a space station?",
                Value = 100,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 3,
                Name = "Medicine",
                LocationId = 3,
                Description = "A small box containing a vial filled with a blue liquid.",
                Type = ObjectType.Medicine,
                CanInventory = false,
                IsConsumable = true,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 4,
                Name = "Contraband",
                LocationId = 3,
                Description = "Illegal items to be sold on the black market.",
                Type = ObjectType.Contraband,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 8,
                Name = "ID Card",
                LocationId = 0,
                Description =
                    "Your ID card. Everyone on the station has one.",
                Type = ObjectType.Information,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 9,
                Name = "Sandwich",
                LocationId = 0,
                Description =
                    "A delicious sandwich.",
                Type = ObjectType.Food,
                CanInventory = true,
                IsConsumable = true,
                IsVisible = true
            },

            new CitizenObject
            {
                Id = 10,
                Name = "Pillow",
                LocationId = -1,
                Description = 
                    "You can go back to sleep with this.",
                Type = ObjectType.Tool,
                CanInventory = true,
                IsConsumable = false,
                IsVisible = true
            }
        };
    }
}
