using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuCursorScript : MonoBehaviour
{
    Vector2 Movement;
    bool ButtonPressed;
    private Rigidbody2D RB;
    public GameMaster GM = new GameMaster();
    public float Timer;
    public float Speed;
    public string Lev1;
    public string Lev2;

    IEnumerator StopPress()
    {
        yield return new WaitForSeconds(Timer);
        ButtonPressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(Movement.x, Movement.y) * Speed * Time.deltaTime;

        if (ButtonPressed && GM.Level == 1)
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Play" && GM.Level == 1)
        {
            SceneManager.LoadScene(Lev1);
        }
    }
}
