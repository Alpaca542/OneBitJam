using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Debug")]
    public LayerMask WhatToCheckOnJump;
    public bool AmIActive = false;
    public Transform rayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (AmIActive)
        {
            //Move
            float moveHorizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(moveHorizontal, 0f);
            rb.AddForce(new Vector2(moveHorizontal * speed, 0f));

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && Physics2D.Raycast(rayer.position, Vector2.down, 0.3f, WhatToCheckOnJump))
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }
    }
}
