using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SlimeController : MonoBehaviour
{
    public float speed = 5f;
    public bool Stopped = true;
    public bool AmIActive = true;
    private Rigidbody2D rb;
    public ParticleSystem prt;
    void Update()
    {
        if (AmIActive)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            if (moveHorizontal != 0)
            {
                if (Stopped)
                {
                    Stopped = false;
                    prt.Play();
                }
                if (moveHorizontal > 0.2 && transform.rotation != Quaternion.Euler(0, 0, 0))
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                if (moveHorizontal < -0.2 && transform.rotation != Quaternion.Euler(0, 180, 0) && transform.rotation != Quaternion.Euler(0, -180, 0))
                    transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                Stopped = true;
                prt.Stop();
            }

            rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void TransformTo(GameObject ToWho)
    {
        AmIActive = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
        rb.AddForce((ToWho.transform.position - transform.position) * 150f);
    }
    public void BeAwake()
    {
        AmIActive = true;
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}