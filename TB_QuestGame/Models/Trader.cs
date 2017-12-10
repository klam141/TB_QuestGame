using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    class Trader : Civilian, ITrade
    {
        public Dictionary<int, int> Inventory { get; set; }
    }
}
