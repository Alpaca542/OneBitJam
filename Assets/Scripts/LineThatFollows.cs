using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LineThatFollows : MonoBehaviour
{
    public GameObject WhatToFollow;
    public LineRenderer lr;
    private void Start()
    {
        lr.positionCount = 2;
    }
    void Update()
    {
        lr.SetPosition(0, GameObject.FindGameObjectWithTag("Slime").transform.position);
        lr.SetPosition(1, WhatToFollow.transform.position);
    }
}