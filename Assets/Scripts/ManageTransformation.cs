using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class ManageTransformation : MonoBehaviour
{
    public GameObject[] playerList;
    public GameObject[] BtnList;
    public RectTransform panel;
    public void OnTransformPressed()
    {
        StartCoroutine(Openpanel());
    }
    IEnumerator Openpanel()
    {
        panel.localScale = new Vector2(1, 0f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0.2f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0.4f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0.6f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0.8f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 1);
    }
    IEnumerator CLosepanel()
    {
        panel.localScale = new Vector2(1, 1);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0.8f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0.6f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0.4f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0.2f);
        yield return new WaitForSeconds(0.02f);
        panel.localScale = new Vector2(1, 0);
    }
    public void OnChosenInPanel(int BtnNumber)
    {
        foreach(GameObject gmb in playerList)
        {
            gmb.GetComponent<Light2D>().enabled = false;
            gmb.GetComponent<Player>().AmIActive = false;
        }
        playerList[BtnNumber].GetComponent<Light2D>().enabled = true;
        playerList[BtnNumber].GetComponent<Player>().AmIActive = true;
        StartCoroutine(CLosepanel());
        Camera.main.gameObject.GetComponent<playerFollow>().ChoosePlayer();
    }
    private void Awake()
    {
        for (int i = 0; i < playerList.Length; i++)
        {
            BtnList[i].SetActive(true);
            BtnList[i].GetComponent<Image>().sprite = playerList[i].GetComponent<SpriteRenderer>().sprite;
            BtnList[i].GetComponent<Image>().color = playerList[i].GetComponent<SpriteRenderer>().color;
        }
        playerList[0].GetComponent<Light2D>().enabled = true;
        playerList[0].GetComponent<Player>().AmIActive = true;
    }
}
