using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LineThatFollows : MonoBehaviour
{
    public GameObject WhatToFollow;
    void Update()
    {
        transform.right = WhatToFollow.transform.position - transform.position;
        transform.localScale = new Vector2(Mathf.Sqrt(Mathf.Pow(WhatToFollow.transform.position.y - transform.position.y, 2) + Mathf.Pow(WhatToFollow.transform.position.x - transform.position.x, 2)), 0.41f);
    }
}
