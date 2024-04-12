using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : MonoBehaviour
{
    public GameObject rayer2;
    public GameObject blt;
    public LayerMask whattohit;
    public bool shtng = false;
    private void Update()
    {
        if (!gameObject.GetComponent<Player>().AmIActive)
        {
            if (Physics2D.Raycast(rayer2.transform.position, rayer2.transform.right, 5f, whattohit))
            {
                if (!shtng)
                {
                    shtng = true;
                    InvokeRepeating(nameof(InvokeShoot), 0, 2f);
                }
            }
            else
            {
                shtng = false;
                CancelInvoke(nameof(InvokeShoot));
            }
        }
        else
        {
            CancelInvoke(nameof(InvokeShoot));
        }
    }
    public void InvokeShoot()
    {
        GameObject projectile = Instantiate(blt, rayer2.transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(rayer2.transform.right*500f);
    }
}
