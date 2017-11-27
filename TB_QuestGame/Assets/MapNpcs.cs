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
            }
        };
    }
}
