using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    private void Awake()
    {
        Invoke(nameof(DieInThreeSeconds), 3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up);
            collision.gameObject.GetComponent<Player>().AmIFlying = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Slime")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up);
            collision.gameObject.GetComponent<SlimeController>().AmIFlying = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Box")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up);
            Destroy(gameObject);
        }
    }
    public void DieInThreeSeconds()
    {
        Destroy(gameObject);
    }
}
