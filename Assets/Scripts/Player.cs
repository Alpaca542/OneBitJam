using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject myplayerbody;
    public Animator myAnimator;
    [Header("Parameters")]
    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Debug")]
    public LayerMask WhatToCheckOnJump;
    public bool AmIActive = false;
    public bool AmIFlying = false;
    public Transform rayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AmIFlying = false;
    }
    void Update()
    {
        if (AmIActive && !AmIFlying)
        {
            //Move
            
            float moveHorizontal = Input.GetAxis("Horizontal");
            if(moveHorizontal!=0)
            {
                if (moveHorizontal > 0)
                    myplayerbody.transform.rotation = Quaternion.Euler(0, 0, 0);
                else
                    myplayerbody.transform.rotation = Quaternion.Euler(0, 180, 0);
                myAnimator.SetBool("walkAnimation", true);
            }
            else
            {
                myAnimator.SetBool("walkAnimation", false);
            }
            
            rb.velocity = new Vector2(moveHorizontal*speed, rb.velocity.y);

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && Physics2D.Raycast(rayer.position, Vector2.down, 0.001f, WhatToCheckOnJump))
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }
        if (rb.velocity == Vector2.zero)
        {
            myAnimator.SetBool("walkAnimation", false);
        }
    }
}
