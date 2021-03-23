using System;

public class EnterExitBroker 
{
    public static event Action PlayerExitsBuilding; //subscribers subscribe to the action
    public static void PlayerExitsBuildingFunction() //this method is called by the publisher
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
