using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public static partial class MapObjects
    {
        public static List<Npc> Npcs = new List<Npc>()
        {
            new Civilian
            {
                Id = 1,
                Name = "Shady Guy",
                LocationId = 2,
                Description = "You've never seen this guy before. He's wearing dark clothing and hes carrying a bag.",
                Messages = new List<string>
                {
                    "What are you looking at?",
                    "Leave me alone."
                }
            },

            new Civilian
            {
                Id = 2,
                Name = "Security Guard",
                LocationId = 3,
                Description = "One of the security guards on this ship.",
                Messages = new List<string>
                {
                    "Seen anything suspicious?",
                    "Have a nice day."
                }
            },

            new Civilian
            {
                Id = 3,
                Name = "Hungry Man",
                LocationId = 5,
                Description = "You've never seen this guy before. He's wearing dark clothing and hes carrying a bag.",
                Messages = new List<string>
                {
                    "What?",
                    "I'm trying to eat.",
                    "Go away."
                }
            },

            new Civilian
            {
                Id = 4,
                Name = "Janitor",
                LocationId = 2,
                Description = "One of the janitors aboard the ship.",
                Messages = new List<string>
                {
                    "Don't go in that closet.",
                    "You could get hurt. It's off limits."
                }
            },

            new Civilian
            {
                Id = 5,
                Name = "Nice Man",
                LocationId = 3,
                Description = "This guy seems nice.",
                Messages = new List<string>
                {
                    "Hi. How are you?",
                    "Have a nice day."
                }
            },

            new Trader
            {
                Id = 6,
                Name = "Merchant",
                LocationId = 3,
                Description = "This person sells mysterious things.",
                Messages = new List<string>
                {
                    "Take a look at my wares."
                },
                Inventory = new Dictionary<int, int>
                {
                    { 120, 10 }
                }
            }
        };
    }
}
