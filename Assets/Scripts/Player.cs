using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Parameters")]
    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("Debug")]
    public LayerMask grnd;
    private Rigidbody2D rb;
    public bool AmIActive = false;

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
            if (Input.GetKeyDown(KeyCode.Space) && Physics2D.Raycast(transform.position, Vector2.down, 0.6f, grnd))
            {
                rb.AddForce(Vector2.up * jumpForce);
            }
        }
    }
}
