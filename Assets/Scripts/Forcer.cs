using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour
{
    public float Strength = 1500f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box" || collision.gameObject.tag == "Slime")
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<Player>().AmIFlying = true;
            }
            if (collision.gameObject.tag == "Slime")
            {
                collision.gameObject.GetComponent<SlimeController>().AmIFlying = true;
            }

            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * Strength);
        }
    }
}