using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineThatFollows : MonoBehaviour
{
    public GameObject WhatToFollow;
    public LineRenderer lr;
    public bool AmISilent;
    public RectTransform cnv;
    public soundManager soundManager;
    public GameObject sounder;
    private void Start()
    {
        if (!AmISilent)
        {
            soundManager = GetComponent<soundManager>();
            gameObject.GetComponent<soundManager>().PlaySound(0);
        }
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }
    void Update()
    {

        lr.SetPosition(0, GameObject.FindGameObjectWithTag("Slime").transform.position);
        if (!AmISilent)
        {
            lr.SetPosition(1, new Vector2(WhatToFollow.transform.position.x, WhatToFollow.transform.position.y + 0.72f));
        }
        else
        {
            lr.SetPosition(1, new Vector2(WhatToFollow.transform.position.x, WhatToFollow.transform.position.y));
        }
    }
    private void OnDestroy()
    {
        Instantiate(sounder);
    }

}