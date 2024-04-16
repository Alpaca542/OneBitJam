using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ButtonScript : MonoBehaviour
{
    public GameObject WhatIsConnected;
    public GameObject trmng;
    public GameObject MyText;
    public bool AmILiftable;
    public GameObject[] WhoShouldAppear;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box" || collision.gameObject.tag == "Slime")
        {
            if (AmILiftable)
            {
                GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 50);
            }
            else
            {
                GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 20);
            }
            if (WhoShouldAppear.Length != 0)
            {
                foreach (GameObject gmb in WhoShouldAppear)
                {
                    gmb.tag = "Player";
                }
                trmng.GetComponent<ManageTransformation>().Awake();
            }
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
            else if (WhatIsConnected.tag == "Machine")
            {
                WhatIsConnected.GetComponent<Light2D>().enabled = true;
                WhatIsConnected.GetComponent<MachineScript>().AmIActivated = true;
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
            else if (WhatIsConnected.tag == "Machine")
            {
                WhatIsConnected.GetComponent<Light2D>().enabled = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.GetComponent<soundManager>().PlaySound(0);
    }
}
