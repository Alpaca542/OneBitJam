using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerFollow : MonoBehaviour
{
    public GameObject player;
    public GameObject secondCamera;
    private Vector3 playervector;
    public float speed;
    public void ChoosePlayer()
    {
        GameObject[] playerlist = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject playerFromList in playerlist)
        {
            if(playerFromList.GetComponent<Player>().enabled == true) {
                player = playerFromList;
            
            }
        }
    }
        private void LateUpdate()
        {
                playervector = player.transform.position;
                playervector.z = playervector.z - 10;
                transform.position = Vector3.Lerp(transform.position, playervector, speed * Time.deltaTime);
        }
    
}
