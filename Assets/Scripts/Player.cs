using System.Collections;
using System.Collections.Generic;
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
    public bool AmIActive = false;
    public bool AmIFlying = false;
    private GameObject[] playerList;
    public Transform rayer;

    private Rigidbody2D rb;

    void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnEnable()
    {
        //cursor change
    }
    private void OnCollisionStay2D(Collision2D collision)
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
                if (moveHorizontal > 0.2 && transform.rotation != Quaternion.Euler(0, 0, 0))
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                else if (moveHorizontal < -0.2 && transform.rotation != Quaternion.Euler(0, -180, 0) && transform.rotation != Quaternion.Euler(0, 180, 0))
                    transform.rotation = Quaternion.Euler(0, 180, 0);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slime" && !AmIActive)
        {
            foreach (GameObject gmb in playerList)
            {
                if (gmb != gameObject)
                {
                    gmb.GetComponent<Light2D>().enabled = false;
                    gmb.GetComponent<Player>().AmIActive = false;
                }
            }
            GetComponent<Light2D>().enabled = true;
            AmIActive = true;
            Camera.main.gameObject.GetComponent<playerFollow>().player = gameObject;
            collision.gameObject.SetActive(false);
        }
    }
}
