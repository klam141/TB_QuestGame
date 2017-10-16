using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB_QuestGame
{
    /// <summary>
    /// enum of all possible player actions
    /// </summary>
    public enum CitizenAction
    {
        None,
        MissionSetup,
        LookAround,
        LookAt,
        PickUpItem,
        PickUpTreasure,
        PutDownItem,
        PutDownTreasure,
        Travel,
        CitizenInfo,
        CitizenInventory,
        CitizenTreasure,
        CitizenLocationsVisited,
        ListDestinations,
        ListItems,
        ListTreasures,
        Exit
    }
}
