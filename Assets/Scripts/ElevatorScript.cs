using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform TopPos;
    public Transform BottomPos;
    public bool DoWeGoUp;
    public float speed = 10f;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void GoUp()
    {
        if (transform.position != TopPos.position)
        {
            rb.velocity = (TopPos.position - transform.position) * speed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    public void GoDown()
    {
        if (transform.position != BottomPos.position)
        {
            rb.velocity = (BottomPos.position - transform.position)*speed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    private void Update()
    {
        if (!DoWeGoUp)
        {
            GoDown();
        }
        else
        {
            GoUp();
        }
    }
}
