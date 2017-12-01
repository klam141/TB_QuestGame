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
        Travel,
        CitizenInfo,
        CitizenInventory,

        //inventory menu
        Inventory,
        LookAt,
        PutDownItem,

        //interacting with objects/npcs
        Interact,

        //object menu
        PickUpItem,

        //npc menu
        Talk,
        Trade,

        //admin menu
        AdminMenu,
        ListDestinations,
        ListItems,
        ListNpcs,

        ReturnToMainMenu,
        Exit
    }
}
