using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{

    Vector2 PlayerMovement;
    Vector2 LightMovement;
    public float PlayerSpeed;
    public float LightSpeed;
    public float JumpForce;
    public float GravityMultiplier;
    public bool IsJumping;
    public bool IsGrounded;
    public bool FacingRight = true;
    private Rigidbody2D RB;
    private Transform Light;
    private Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        Light = GameObject.FindGameObjectWithTag("Light").GetComponent<Transform>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (IsGrounded)
        {
            RB.velocity = new Vector2(PlayerMovement.x, 0) * PlayerSpeed * Time.deltaTime;
        }
        else if (!IsGrounded)
        {
            RB.velocity = new Vector2(PlayerMovement.x, 0) * PlayerSpeed * Time.deltaTime;
        }
        

        AnimatePlayer();
        MoveLight();
        Flip();
        Jump();
    }

    void AnimatePlayer()
    {
        if (PlayerMovement.x > 0  && IsGrounded || PlayerMovement.x < 0 && IsGrounded)
        {
            Anim.SetBool("IsMoving", true);
        }
        else
        {
            Anim.SetBool("IsMoving", false);
        }
    }

    void MoveLight()
    {
        Light.transform.Translate(new Vector3(LightMovement.x, LightMovement.y, 0) * LightSpeed * Time.deltaTime);
    }

    void Flip()
    {
        Vector3 Scale = transform.localScale;

        if(PlayerMovement.x > 0 && !FacingRight || PlayerMovement.x < 0 && FacingRight)
        {
            FacingRight = !FacingRight;
            Scale.x *= -1;
        }

        transform.localScale = Scale;
    }

    void Jump()
    {
        if (IsJumping && IsGrounded)
        {
            RB.AddForce(new Vector2(PlayerMovement.x, JumpForce));
            IsJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
            Anim.SetBool("IsJumping", false);
            RB.gravityScale = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = false;
            Anim.SetBool("IsJumping", true);
            RB.gravityScale = RB.gravityScale * GravityMultiplier;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Danger")
        {
            Destroy(gameObject);
        }
    }

    #region InputActions
    public void OnPlayerMove(InputAction.CallbackContext ctx)
    {
        PlayerMovement = ctx.ReadValue<Vector2>();
    }

    public void OnLightMove(InputAction.CallbackContext ctx)
    {
        LightMovement = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed && IsGrounded)
        {
            IsJumping = true;
        }
    }
    #endregion

}
