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

        //main menu
        LookAround,
        LookAt,
        PickUpItem,
        PutDownItem,
        Inventory,
        Travel,
        CitizenInfo,
        CitizenInventory,
        CitizenLocationsVisited,

        //admin menu
        AdminMenu,
        ListDestinations,
        ListItems,
        ListNpcs,
        ReturnToMainMenu,

        Exit
    }
}
