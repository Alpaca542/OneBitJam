using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class MachineScript : MonoBehaviour
{
    public bool AmIActivated;
    public bool used;
    public CutSceneDialogue csd;
    public GameObject slime;
    public GameObject man;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && AmIActivated && !used)
        {
            used = true;
            csd.Stststtst();
        }
    }
}
