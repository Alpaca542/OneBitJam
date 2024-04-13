using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Stretchers : MonoBehaviour
{
    public IEnumerator Openpanel()
    {
        if (transform.localScale != new Vector3(1, 1, 1))
        {
            transform.localScale = new Vector2(0f, 0f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0.2f, 0.2f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0.4f, 0.4f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0.6f, 0.6f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0.8f, 0.8f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(1, 1);

        }
    }
    public IEnumerator CLosepanel()
    {
        if (transform.localScale != new Vector3(0, 0, 1))
        {
            transform.localScale = new Vector2(1, 1);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0.8f, 0.8f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0.6f, 0.6f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0.4f, 0.4f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0.2f, 0.2f);
            yield return new WaitForSeconds(0.02f);
            transform.localScale = new Vector2(0, 0);
        }
    }
}
