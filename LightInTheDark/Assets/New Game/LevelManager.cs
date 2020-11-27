using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int LvlsUnlocked;
    public GameObject[] Buttons;
    public int LevelIndex1;

    // Start is called before the first frame update
    void Start()
    {
        LvlsUnlocked = PlayerPrefs.GetInt("LvlsUnlocked", 1);

        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i].active = false;
        }

        for (int i = 0; i < LvlsUnlocked; i++)
        {
            Buttons[i].active = true;
        }
    }

    internal void OnCollisionStay2D(Collision2D collision2D)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int LevelIndex)
    {
      
        SceneManager.LoadScene(LevelIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadLevel(LevelIndex1);
        }
    }


}
