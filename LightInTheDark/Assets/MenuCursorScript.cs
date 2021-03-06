﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuCursorScript : MonoBehaviour
{
    Vector2 Movement;
    public bool ButtonPressed;
    private Rigidbody2D RB;
    public GameMaster GM = new GameMaster();
    public float Timer;
    public float Speed;
    public string Lev1;
    public string Lev2;
    private SaveSystem SS;

    IEnumerator StopPress()
    {
        yield return new WaitForSeconds(Timer);
        ButtonPressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SS = new SaveSystem();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(Movement.x, Movement.y) * Speed * Time.deltaTime;

        if (ButtonPressed)
        {
            StartCoroutine(StopPress());
            //Debug.Log("F*CK OFF");
            SceneManager.LoadScene(Lev1);
        }
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }

    public void OnPress(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            ButtonPressed = true;
        }
    }

    void ActiveButton()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Level1" /*&& GM.Level == 1*/)
        {
            SceneManager.LoadScene(Lev1);
            //Debug.Log(Lev2);
        }

        if (collision.gameObject.tag == "Level2" /*&& GM.Level == 1*/)
        {
            SceneManager.LoadScene("Level2");
            //Debug.Log(Lev2);
        }
    }
}
