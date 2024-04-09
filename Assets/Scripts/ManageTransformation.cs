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
    public GameObject line;
    public GameObject ln;
    public void OnChosenInPanel(int BtnNumber)
    {
        if (Camera.main.GetComponent<playerFollow>().player != playerList[BtnNumber])
        {
            if (ln != null)
                Destroy(ln);
            foreach (GameObject gmb in playerList)
            {
                gmb.GetComponent<Light2D>().enabled = false;
                gmb.GetComponent<Player>().AmIActive = false;
            }
            slime.GetComponent<SlimeController>().AmIActive = false;
            slime.GetComponent<Light2D>().enabled = false;
            ln = Instantiate(line, slime.transform.position, Quaternion.identity);
            ln.GetComponent<LineThatFollows>().WhatToFollow = playerList[BtnNumber];
            playerList[BtnNumber].GetComponent<Light2D>().enabled = true;
            playerList[BtnNumber].GetComponent<Player>().AmIActive = true;
            Camera.main.GetComponent<playerFollow>().player = playerList[BtnNumber];
        }
    }
    public void OnChosenSlimel()
    {
        Destroy(ln);
        foreach (GameObject gmb in playerList)
        {
            gmb.GetComponent<Light2D>().enabled = false;
            gmb.GetComponent<Player>().AmIActive = false;
        }
        slime.GetComponent<SlimeController>().AmIActive = true;
        slime.GetComponent<Light2D>().enabled = true;
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
