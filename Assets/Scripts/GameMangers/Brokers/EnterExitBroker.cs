///////////////////////////////////////////////////////////////////////////
//FileName: EnterExitBroker.cs
//Author : Greggory Reed
//Description : Publisher/Subscriber Broker for Entering and Exiting the building
////////////////////////////////////////////////////////////////////////////

using System;

public class EnterExitBroker 
{
    public static event Action PlayerExitsBuilding;
    public static void PlayerExitsBuildingFunction() 
    {
        if(PlayerExitsBuilding != null)
        {
            PlayerExitsBuilding();
        }
    }
    public static event Action PlayerEntersBuilding;
    public static void PlayerEntersBuildingFunction()
    {
        if (PlayerEntersBuilding != null)
        {
            PlayerEntersBuilding();
        }
    }
}
