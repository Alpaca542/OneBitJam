using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public GameObject WhatIsConnected;
    public GameObject MyText;
    public bool AmILiftable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box" || collision.gameObject.tag == "Slime")
        {
            GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 20);
            if (MyText != null)
            {
                MyText.SetActive(false);
            }
            transform.localScale = new Vector2(transform.localScale.x, 0.05f);
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
        GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 4);
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box" || collision.gameObject.tag == "Slime")
        {
            if (MyText != null)
            {
                MyText.SetActive(true);
            }
            if (AmILiftable)
            {
                transform.localScale = new Vector2(transform.localScale.x, 0.4116f);
            }
            else
            {
                transform.localScale = new Vector2(transform.localScale.x, 0.1f);
            }
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
