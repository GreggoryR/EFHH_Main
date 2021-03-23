///////////////////////////////////////////////////////////////////////////
//FileName: NGHelper.cs
//Author : Newgrounds.io
//Description : Helps communicate with NG servers 
////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class NGHelper : MonoBehaviour
{
    [SerializeField] io.newgrounds.core ngio_core;
    void Start()
    {
        // Do this after the core has been initialized
        ngio_core.onReady(() => {

            // Call the server to check login status
            ngio_core.checkLogin((bool logged_in) => {

                if (logged_in)
                {
                    onLoggedIn();
                }
                else
                {
                    /*
                     * This is where you would ask them if the want to sign in.
                     * If they want to sign in, call requestLogin()
                     */
                }
            });
        });
    }

    void onLoggedIn()
    {
        // Do something. You can access the player's info with:
        io.newgrounds.objects.user player = ngio_core.current_user;
    }

    // call this method whenever you want to unlock a medal.
    public void unlockMedal(int medal_id)
    {
        // create the component
        io.newgrounds.components.Medal.unlock medal_unlock = new io.newgrounds.components.Medal.unlock();

        // set required parameters
        medal_unlock.id = medal_id;

        // call the component on the server, and tell it to fire onMedalUnlocked() when it's done.
        medal_unlock.callWith(ngio_core, onMedalUnlocked);
    }

    // this will get called whenever a medal gets unlocked via unlockMedal()
    public void onMedalUnlocked(io.newgrounds.results.Medal.unlock result)
    {
        io.newgrounds.objects.medal medal = result.medal;
        Debug.Log("Medal Unlocked: " + medal.name + " (" + medal.value + " points)");
    }

    void Update()
    {
        
    }
}
