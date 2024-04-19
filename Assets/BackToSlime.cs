using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToSlime : MonoBehaviour
{
    public float force;

    GameObject slime;
    // Start is called before the first frame update
    void Awake()
    {
        
        slime = GameObject.FindWithTag("Slime");
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection((GameObject.FindWithTag("Slime").transform.position - transform.position) * 1f * force);
    }
}
