using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour
{
    public Transform TopPos;
    public Transform BottomPos;
    public bool DoWeGoUp;
    public float speed = 10f;
    public GameObject platf;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = platf.GetComponent<Rigidbody2D>();
    }
    public void GoUp()
    {
        if (platf.transform.position != TopPos.position)
        {
            rb.velocity = (TopPos.position - platf.transform.position) * speed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    public void GoDown()
    {
        if (platf.transform.position != BottomPos.position)
        {
            rb.velocity = (BottomPos.position - platf.transform.position)*speed;
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
