using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldScript : MonoBehaviour
{
    
    public int LvlIndex = 1;
    public SaveSystem SS;
    public string Level2;
    public string Level3;
    public string Level4;
    public string Level5;
    public string Level6;

    // Start is called before the first frame update
    void Start()
    {
        SS = new SaveSystem();
        //int CurrentLvl = PlayerPrefs.GetInt("CurrentLvl", 1);
        PlayerPrefs.SetInt("CurrentLvl", LvlIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("CurrentLvl") == 2)
        {
            SS.Lev2 = true;
            SceneManager.LoadScene("Level2");
        }
        else if (PlayerPrefs.GetInt("CurrentLvl") == 3)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
//            SS.Lev2 = true;
            PlayerPrefs.SetInt("CurrentLvl", LvlIndex + 1);
        }
    }
}
