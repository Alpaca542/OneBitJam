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

    void FixedUpdate()
    {
        Vector3 difference = GameObject.FindWithTag("Slime").transform.position - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ -90f);
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(Vector2.up * force);
    }

}
