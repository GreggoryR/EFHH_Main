///////////////////////////////////////////////////////////////////////////
//FileName: GameManager.cs
//Author : Greggory Reed
//Description : Singleton Pattern--Found in many managers
//              GameManager stores basic information
//              that needs to be persisted from lvl to lvl
///////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    #region Singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Inventory
    [HideInInspector] public int itemID = 0;
    public int space = 20;
    public List<ItemSO> itemList;
    public InventorySlot[] slots;
    public enum StoryItemsInGame { Screwdriver, Newspaper, Key }
    List<int> storyItemFound = new List<int>() { 0, 0, 0 };
    public enum HealthItemsInGame { ZERO_Small, ONE_Small, ONE_Coffee}
    List<int> healthItemsFound = new List<int>() { 0, 0, 0 };
    #endregion

    #region Story
    [SerializeField] public int chapter = 0; //keep track moving scene to scene
    public List<List<int>> chapterWithSections; //keep track moving scene to scene

    #endregion

    #region Player
    public readonly int playerMaxHealth = 5;
    [SerializeField] public int playerHealth = 5;
    public bool canMove = true;
    [HideInInspector] public bool isTalking = false;
    [HideInInspector] public bool beingChased = false;
    [SerializeField] public bool talkedToAfua = false;
    [SerializeField] public bool talkedToJose = false;
    [SerializeField] public bool sawAlien = false;
    public float playerMoveX = 0;
    public float playerMoveY = 0;
    #endregion

    #region NPC
    public NPCInformationSO currentNPC;
    [SerializeField] public bool nextToNPC = false;
    #endregion

    #region Enemy
    [HideInInspector] public List<GameObject> theChasers = new List<GameObject>();
    public delegate void NotChasingAnymore();
    public NotChasingAnymore onNotChasingAnymore;
    #endregion

    #region Doors
    public GameObject currentDoor;
    #endregion

    #region Level
    [HideInInspector] public Scene prevLevel;
    public string test = "";
    public enum Location { first, basement, outside};
    public Location location;
    #endregion

    #region Mini-Games
    public float currentWheelRotation;
    #endregion

    #region Newgrounds Medals
    [SerializeField] NGHelper ngHelper;
    Dictionary<string, int> medalNums = new Dictionary<string, int>()
    {
        {"start", 62064}, {"runaway", 62065}, {"punchone", 62066}, {"finishpro", 62067}, {"findscrew", 62077}, {"getnews", 62078},
        {"getmatch", 62079},{"getbeer", 62080},{"getwheel", 62081},{"getflower", 62082},{"getoxy", 62083},{"getrope", 62084},
        {"gettele", 62085},{"getkey", 62086},{"hide",0 },{"findufo",0 },{"finishone", 62068},{"finishtwo", 62069},
        {"finishthree", 62070},{"finishfour", 62071},{"finishfive", 62072},{"punchall", 62073},{"finishgame", 62074},{"finishunder5", 62075},{"befriend", 62076}
    };

    //5 Points - start game 
    //5 Points - Run Away!
    //5 Points - Punch an Orderly 
    //5 Points - Finish Prologue
    //5 Points(Secret) - Find Screwdriver 
    //5 Points(Secret) - Get Newspaper
    //5 Points(Secret) - Get Matches 
    //5 Points(Secret) - Get Beer
    //5 Points(Secret) - Get Wheel
    //5 Points(Secret) - Get Flower
    //5 Points(Secret) - Get Oxygen Tank
    //5 Points(Secret) - Get Rope
    //5 Points(Secret) - Get Telescope
    //5 Points(Secret) - Get Keys
    //10 Points(Secret) - Hide!
    //10 Points(Secret) - Find the UFO!
    //25 Points - Finish Chapter One
    //25 Points - Finish Chapter Two
    //25 Points - Finish Chapter Three
    //25 Points - Finish Chapter Four
    //25 Points - Finish Chapter Five
    //50 Points - Punch Every Orderly
    //50 Points - Finish the Game! 
    //100 Points - Finish the Game in under 5 Minutes! (will change time depending on how it plays)
    //100 Points - Be a Friend(hint: it's okay just be present sometimes) - (will unlock if they stand next to Kwan for 60 seconds without talking or moving)
    #endregion

    #region DEV
    [SerializeField] Text info1;
    [SerializeField] Text info2;
    [SerializeField] Text info3;
    [SerializeField] Text info4;
    [SerializeField] Text info5;
    [SerializeField] Text info6;
    #endregion

    public void Start()
    {
        location = Location.first;


    }
    public void GameOver()
    {
        Debug.Log("Game Over");
    }
    public void StopChasing()
    {
        if (onNotChasingAnymore != null && beingChased)
        {
            onNotChasingAnymore.Invoke();
        }
    }
}
