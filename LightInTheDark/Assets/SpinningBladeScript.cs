using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningBladeScript : MonoBehaviour
{
    public float SpinSpeed;
    public float JumpForce;
    private float Timer;
    public float Limit;
    private Rigidbody2D RB;
    public bool IsJumping;
   // public Transform Graphic;
    

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        Vector2 CurrentPos = transform.position;

       // Graphic.transform.Rotate(0, 0, SpinSpeed);
        /*

        Timer += Time.deltaTime;

        if (Timer >= Limit)
        {
            IsJumping = true;
        }

        if (IsJumping)
        {
            RB.AddForce(new Vector2(0, JumpForce));
            IsJumping = false;
            Timer = 0;
        }

        if (!IsJumping)
        {
            CurrentPos = Location.position;
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Up")
        {
            transform.Translate(0, -1, 0);
        }

        if (collision.gameObject.tag == "Down")
        {
            transform.Translate(0, 1, 0);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Up")
        {
            transform.Translate(0, -1, 0);
        }

        if (collision.gameObject.tag == "Down")
        {
            transform.Translate(0, 1, 0);
        }

        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
