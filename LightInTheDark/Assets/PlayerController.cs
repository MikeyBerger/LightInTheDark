﻿using System.Collections;
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
    public bool IsJumping;
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
        RB.velocity = new Vector2(PlayerMovement.x, 0) * PlayerSpeed * Time.deltaTime;

        AnimatePlayer();
        MoveLight();
        Flip();
    }

    void AnimatePlayer()
    {
        if (PlayerMovement.x > 0 || PlayerMovement.x < 0)
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

        if(PlayerMovement.x > 0)
        {
            Scale.x = 1;
        }
        else if (PlayerMovement.x < 0)
        {
            Scale.x = -1;
        }

        transform.localScale = Scale;
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
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsJumping = true;
        }
    }
    #endregion

}
