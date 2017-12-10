using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public abstract class Npc : Character
    {
        public abstract int Id { get; set; }

        public abstract string Description { get; set; }

    }

    interface ISpeak
    {
        List<string> Messages { get; set; }
        int CurrentMessageNum { get; set; }
        string Speak();
    }

    interface ITrade
    {
        Dictionary<int, int> Inventory { get; set; }//key is the price, value is the object
    }
}
