using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldScript : MonoBehaviour
{
    public int CurrentLvl;
    public int LvlIndex = 1;
    public SaveSystem SS = new SaveSystem();

    // Start is called before the first frame update
    void Start()
    {
        CurrentLvl = PlayerPrefs.GetInt("CurrentLvl", LvlIndex);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("CurrentLvl") == 2)
        {
            SS.Lev2 = true;
        }   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SS.Lev2 = true;

        }
    }
}
