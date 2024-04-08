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
    public GameObject slime;
    public void OnChosenInPanel(int BtnNumber)
    {
        if (Camera.main.GetComponent<playerFollow>().player != playerList[BtnNumber])
        {
            slime.SetActive(true);
            slime.transform.position = Camera.main.GetComponent<playerFollow>().player.transform.position;
            Camera.main.GetComponent<playerFollow>().player = slime;
            slime.GetComponent<SlimeController>().TransformTo(playerList[BtnNumber]);
        }
    }
    public void OnChosenSlimel()
    {
        slime.SetActive(true);
        slime.transform.position = Camera.main.GetComponent<playerFollow>().player.transform.position;
        foreach (GameObject gmb in playerList)
        {
            gmb.GetComponent<Light2D>().enabled = false;
            gmb.GetComponent<Player>().AmIActive = false;
        }
        slime.GetComponent<SlimeController>().BeAwake();
        Camera.main.GetComponent<playerFollow>().player = slime;
    }
    private void Awake()
    {
        slime = GameObject.FindGameObjectWithTag("Slime");
        playerList = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerList.Length; i++)
        {
            BtnList[i].SetActive(true);
            BtnList[i].GetComponent<Image>().sprite = playerList[i].GetComponent<SpriteRenderer>().sprite;
            BtnList[i].GetComponent<Image>().color = playerList[i].GetComponent<SpriteRenderer>().color;
        }
    }
}
