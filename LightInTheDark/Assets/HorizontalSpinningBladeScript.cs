using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpinningBladeScript : MonoBehaviour
{
    private Rigidbody2D RB;
    public float MoveSpeed;
    public float Timer;
    public float Limit;
    public bool MoveLeft;
    public bool MoveRight;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= Limit && !MoveLeft && !MoveRight)
        {
            RB.velocity = new Vector2(MoveSpeed, 0) * 1;
            MoveLeft = true;
            Timer = 0;
        }

        if(Timer >= Limit && MoveLeft)
        {
            RB.velocity = new Vector2(MoveSpeed, 0) * -1;
            MoveLeft = false;
            MoveRight = true;
            Timer = 0;
        }

        if (Timer >= Limit && MoveRight)
        {
            RB.velocity = new Vector2(MoveSpeed, 0) * 1;
            MoveLeft = true;
            MoveRight = false;
            Timer = 0;
        }
    }
}
