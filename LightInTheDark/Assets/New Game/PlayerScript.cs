using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    Vector2 Movement;
    public bool IsPressed;
    public bool HasCollided;
    //LevelManager LM;
    private Rigidbody2D RB;
    public float Speed;
    int LvlsUnlocked;
    public GameObject[] Buttons;
    int Lev1;
    int Lev2;
    int Lev3;
    int Lev4;
    int Lev5;
    int Lev6;
    int Lev7;
    int Lev8;
    int Lev9;
    int Lev10;

    // Start is called before the first frame update
    void Start()
    {
        //LM = new LevelManager();
        RB = GetComponent<Rigidbody2D>();


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


    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(Movement.x, Movement.y) * Time.deltaTime * Speed;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnPress(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed && HasCollided)
        {
            IsPressed = true;
            //LM.LoadLevel(LM.LevelIndex1);
        }
    }

    /*
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Level1" && IsPressed)
        {
            SceneManager.LoadScene(Lev1);
        }
        else if (collision.gameObject.tag == "Level2" && IsPressed)
        {
            SceneManager.LoadScene(Lev2);
        }
        else if (collision.gameObject.tag == "Level3" && IsPressed)
        {
            SceneManager.LoadScene(Lev3);
        }
        else if (collision.gameObject.tag == "Level4" && IsPressed)
        {
            SceneManager.LoadScene(Lev4);
        }
        else if (collision.gameObject.tag == "Level5" && IsPressed)
        {
            SceneManager.LoadScene(Lev5);
        }
        else if (collision.gameObject.tag == "Level6" && IsPressed)
        {
            SceneManager.LoadScene(Lev6);
        }
        else if (collision.gameObject.tag == "Level7" && IsPressed)
        {
            SceneManager.LoadScene(Lev7);
        }
        else if (collision.gameObject.tag == "Level8" && IsPressed)
        {
            SceneManager.LoadScene(Lev8);
        }
        else if (collision.gameObject.tag == "Level9" && IsPressed)
        {
            SceneManager.LoadScene(Lev9);
        }
        else if (collision.gameObject.tag == "Level10" && IsPressed)
        {
            SceneManager.LoadScene(Lev10);
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level1" && IsPressed)
        {
            SceneManager.LoadScene(Lev1);
        }
        else if (collision.gameObject.tag == "Level2" && IsPressed)
        {
            SceneManager.LoadScene(Lev2);
        }
        else if (collision.gameObject.tag == "Level3" && IsPressed)
        {
            SceneManager.LoadScene(Lev3);
        }
        else if (collision.gameObject.tag == "Level4" && IsPressed)
        {
            SceneManager.LoadScene(Lev4);
        }
        else if (collision.gameObject.tag == "Level5" && IsPressed)
        {
            SceneManager.LoadScene(Lev5);
        }
        else if (collision.gameObject.tag == "Level6" && IsPressed)
        {
            SceneManager.LoadScene(Lev6);
        }
        else if (collision.gameObject.tag == "Level7" && IsPressed)
        {
            SceneManager.LoadScene(Lev7);
        }
        else if (collision.gameObject.tag == "Level8" && IsPressed)
        {
            SceneManager.LoadScene(Lev8);
        }
        else if (collision.gameObject.tag == "Level9" && IsPressed)
        {
            SceneManager.LoadScene(Lev9);
        }
        else if (collision.gameObject.tag == "Level10" && IsPressed)
        {
            SceneManager.LoadScene(Lev10);
        }
    }
}
