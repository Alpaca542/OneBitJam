using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject WhatIsConnected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            transform.localScale = new Vector2(0.6f, 0.05f);
            if (WhatIsConnected.tag == "Elevator")
            {
                WhatIsConnected.GetComponent<ElevatorScript>().DoWeGoUp = true;
            }
            else if (WhatIsConnected.tag == "Door")
            {
                WhatIsConnected.GetComponent<DoorScript>().DoWeGoUp = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            transform.localScale = new Vector2(0.6f, 0.1f);
            if (WhatIsConnected.tag == "Elevator")
            {
                WhatIsConnected.GetComponent<ElevatorScript>().DoWeGoUp = false;
            }
            else if (WhatIsConnected.tag == "Door")
            {
                WhatIsConnected.GetComponent<DoorScript>().DoWeGoUp = false;
            }
        }
    }
}
