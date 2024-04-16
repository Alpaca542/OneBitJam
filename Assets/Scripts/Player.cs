using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public GameObject myplayerbody;
    public Animator myAnimator;
    [Header("Parameters")]
    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Debug")]
    public LayerMask WhatToCheckOnJump;
    public bool AmIFlying = false;
    public Transform rayer;
    public Texture2D cursorTexture;
    public bool AmIActive;
    private Rigidbody2D rb;
    public Transform rayer1;
    public Transform rayer3;
    public GameObject mySlime;
    public LayerMask playerlayer;

    void Start()
    {
        mySlime = GameObject.FindWithTag("Slime");
        rb = GetComponent<Rigidbody2D>();
    }
    private void Awake()
    {

        mySlime = GameObject.FindWithTag("Slime");
    }
    private void OnEnable()
    {
        if (gameObject.name.Contains("Player2"))
        {
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }

        
    }
    public void aftertrans()
    {
        mySlime.gameObject.layer = 6;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        AmIFlying = false;
    }
    void Update()
    {
       
        if (!AmIFlying)
        {
            
            //Move

            float moveHorizontal = Input.GetAxis("Horizontal");
            if(moveHorizontal!=0)
            {
                if (moveHorizontal > 0.2 && transform.rotation != Quaternion.Euler(0, 0, 0))
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                else if (moveHorizontal < -0.2 && transform.rotation != Quaternion.Euler(0, -180, 0) && transform.rotation != Quaternion.Euler(0, 180, 0))
                    transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            
            rb.velocity = new Vector2(moveHorizontal*speed, rb.velocity.y);

            //Jump
            if (Input.GetKeyDown(KeyCode.Space) && (Physics2D.Raycast(rayer.position, Vector2.down, 0.001f, WhatToCheckOnJump) || Physics2D.Raycast(rayer1.position, Vector2.down, 0.001f, WhatToCheckOnJump) || Physics2D.Raycast(rayer3.position, Vector2.down, 0.001f, WhatToCheckOnJump)))
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
