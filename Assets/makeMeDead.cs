using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeMeDead : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Animator myAnimator;
    public soundManager mySound;
    public Player myPlayer;

    void Start()
    {
        myAnimator = GetComponent<Player>().myAnimator;
        rb = GetComponent<Rigidbody2D>();
        mySound = GetComponent<soundManager>();
        myPlayer = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myPlayer.AmIActive)
        {
            if ((Mathf.Abs(rb.velocity.x) > 0.1) && (rb.velocity.y == 0))
            {
                gameObject.GetComponent<soundManager>().shouldILoop = true;
                gameObject.GetComponent<soundManager>().PlaySound(0);
            }
            else if ((rb.velocity.x == 0) && (rb.velocity.y == 0))
            {
                gameObject.GetComponent<soundManager>().sound.Stop();
            }
            else
            {
                gameObject.GetComponent<soundManager>().shouldILoop = false;
                gameObject.GetComponent<soundManager>().PlaySound(0);
            }
            float moveHorizontal = Input.GetAxis("Horizontal");
            if (moveHorizontal != 0)
            {

                myAnimator.SetBool("walkAnimation", true);
            }
            else
            {
                myAnimator.SetBool("walkAnimation", false);

            }
        }
    }
    public void MakeMeStopped()
    {
        
    }
}
