using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayer : MonoBehaviour
{
    public GameObject plr;
    public GameObject blt;
    void Update()
    {
        if (!plr.GetComponent<Player>().enabled)
        {
            Vector3 diff = Camera.main.GetComponent<playerFollow>().player.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            if (plr.transform.rotation == Quaternion.Euler(0, 180, 0) || plr.transform.rotation == Quaternion.Euler(0, -180, 0))
            {
                float realangle = (180 - rot_z);
                if (realangle > 180f)
                    realangle -= 360f;
                transform.localRotation = Quaternion.Euler(0f, 0f, 180 - rot_z);
                if (realangle > 50)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 50);
                }
                if (realangle < -40)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, -40);
                }
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, rot_z);
                if ((rot_z) > 50)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 50);
                }
                if ((rot_z) < -40)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, -40);
                }

            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject projectile = Instantiate(blt, transform.position, transform.rotation);
                projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * 500f);
            }
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

            if(plr.transform.rotation == Quaternion.Euler(0, 180, 0) || plr.transform.rotation == Quaternion.Euler(0, -180, 0))
            {
                float realangle = (180 - rot_z);
                if (realangle > 180f)
                    realangle -= 360f;

                transform.localRotation = Quaternion.Euler(0f, 0f, 180-rot_z);
                if (realangle > 50)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 50);
                }
                if (realangle < -40)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, -40);
                }
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0f, 0f, rot_z);
                if ((rot_z) > 50)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 50);
                }
                if ((rot_z) < -40)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, -40);
                }

            }
            if ((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - plr.transform.position.x)<-0.2 && Input.GetAxis("Horizontal") == 0)
            {
                plr.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if((Camera.main.ScreenToWorldPoint(Input.mousePosition).x - plr.transform.position.x) > 0.2 && Input.GetAxis("Horizontal") == 0)
            {
                plr.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
}
