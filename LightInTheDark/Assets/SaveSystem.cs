using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSystem
{
    public int SavedLevel;
    public int LevelNum = 1;
    private MenuCursorScript MCS;
    private PlayerController PC;
    //public bool Lev1;
    public bool Lev2;
    public string Level2;
    public GameObject[] Buttons;
    private GoldScript GS;

    // Start is called before the first frame update
    void Start()
    {
        PC = new PlayerController();
        //SavedLevel = PlayerPrefs.GetInt("SavedLevel", LevelNum);
        PlayerPrefs.SetInt("CurrentLvl", 1);
        GS = new GoldScript();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Lev2)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Buttons[1].active = false;
            Buttons[2].active = false;
#pragma warning restore CS0618 // Type or member is obsolete
        }

        if (Lev2)
        {
            Buttons[1].active = true;
            Buttons[0].active = false;
            Buttons[2].active = false;
            //PlayerPrefs.SetInt("CurrentLvl", GS.LvlIndex + 1);
        }
    }
}
