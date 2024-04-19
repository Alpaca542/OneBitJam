using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public GameObject sounder;
    private void Awake()
    {
        Invoke(nameof(DieInThreeSeconds), 2f);
        Instantiate(sounder, transform.position,transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 500f);
            collision.gameObject.GetComponent<Player>().AmIFlying = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Slime")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 500f);
            collision.gameObject.GetComponent<SlimeController>().AmIFlying = true;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Box")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.right * 500f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DieInThreeSeconds()
    {
        Destroy(gameObject);
    }
}
