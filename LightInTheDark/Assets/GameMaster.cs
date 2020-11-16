using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster
{
    public int Level;
    private PlayerController PC;

    // Start is called before the first frame update
    void Start()
    {
        PC = new PlayerController();
    }

    // Update is called once per frame
    void Update()
    {
        Level = 1;


        //PC.OnCollisionEnter2D();
    }

    
}
