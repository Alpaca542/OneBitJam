using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forcer : MonoBehaviour
{
    public float Strength = 1500f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.TransformVector(new Vector2(1000, 1000)));
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().AmIFlying = true;
        }
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * Strength);
    }
}