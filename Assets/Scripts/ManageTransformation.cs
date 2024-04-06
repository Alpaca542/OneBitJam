using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class ManageTransformation : MonoBehaviour
{
    public GameObject[] playerList;
    public int currentindex = 0;
    public void OnTransformPressed()
    {
        playerList[currentindex].GetComponent<Light2D>().enabled = false;
        playerList[currentindex].GetComponent<Player>().AmIActive = false;
        currentindex++;
        if(currentindex >= 3)
        {
            currentindex = 0;
        }
        playerList[currentindex].GetComponent<Light2D>().enabled = true;
        playerList[currentindex].GetComponent<Player>().AmIActive = true;
    }
}
