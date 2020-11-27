using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pass()
    {
        int CurrentLvl = SceneManager.GetActiveScene().buildIndex;

        if (CurrentLvl >= PlayerPrefs.GetInt("LvlsUnlocked"))
        {
            PlayerPrefs.SetInt("LvlsUnlocked", CurrentLvl + 1);
        }

        Debug.Log(CurrentLvl);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Pass();
            //Debug.Log("Level " + PlayerPrefs.GetInt("LevlsUnlocked") + " Cleared");
            
        }
    }
}
