using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Rayer : MonoBehaviour
{
    public Player plr;
    void Update()
    {
        if (!plr.AmIActive)
        {
            Vector3 diff = Camera.main.GetComponent<playerFollow>().player.transform.position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
            //Debug.Log(rayer2.transform.rotation.z);
            //Debug.Log(rayer2.transform.localRotation.z);
            float realangle = transform.eulerAngles.z;
            if (transform.eulerAngles.z > 180)
            {
                realangle = -(360-transform.eulerAngles.z);
            }
            if (realangle > 50)
            {
                transform.rotation = Quaternion.Euler(0, 0, 50);
            }
            if (realangle < -40)
            {
                transform.rotation = Quaternion.Euler(0, 0, -40);
            }
        }
    }
}
