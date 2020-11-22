using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public SaveSystem SS = new SaveSystem();
    public GameObject[] Buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SS.Lev2 == false)
        {
            Buttons[1].SetActive(false);
            Buttons[2].SetActive(false);
        }
    }
}
