using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stopper : MonoBehaviour
{
    public LevelFinisher lvlfn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slime" || collision.gameObject.tag == "Player")
        {
            lvlfn.OnRestart();
        }
    }
}