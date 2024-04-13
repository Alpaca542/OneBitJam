using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDialogueStarter : MonoBehaviour
{
    public bool activated = false;
    public DialogueScript dialoguemng;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.gameObject.tag == "Player" || collision.gameObject.tag == "Slime") && !activated)
        {
            dialoguemng.Stststtst();
            activated = true;
        }
    }
}
