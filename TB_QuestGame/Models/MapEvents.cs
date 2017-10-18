using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    public enum Events
    {
        Death,
        MinorDamage,
        ModerateDamage,
        SevereDamage,
        AddNewItem
    }

    public enum EventTypes
    {
        FirstTimeOnly,
        OnEnter,
        OnLookAround
    };
}
