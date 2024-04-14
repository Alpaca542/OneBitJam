using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMeDeadSlime : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Animator myAnimator;
    public soundManager mySound;
    public SlimeController myPlayer;
    bool ifalled = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySound = GetComponent<soundManager>();
        myPlayer = GetComponent<SlimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Mathf.Abs(rb.velocity.x) > 0.1) && (rb.velocity.y == 0) && myPlayer.enabled)
        {
            gameObject.GetComponent<soundManager>().sound.mute = false;
        }
        else
        {
            if (!ifalled)
            {
                if (mySound.sound.isPlaying)
                {
                    gameObject.GetComponent<soundManager>().sound.mute = true;
                }

            }
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal != 0 && myPlayer.enabled)
        {

            myAnimator.SetBool("walkAnimation", true);
        }
        else
        {
            myAnimator.SetBool("walkAnimation", false);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Physics2D.Raycast(myPlayer.rayer.position, Vector2.down, 0.001f, myPlayer.WhatToCheckOnJump))
        {
            ifalled = true;
            Invoke(nameof(MakeMeNotFalled), 0.2f);
            gameObject.GetComponent<soundManager>().sound.mute = false;
            gameObject.GetComponent<soundManager>().PlaySound(0);
        }
    }
    public void MakeMeNotFalled()
    {
        ifalled = false;
    }
}
