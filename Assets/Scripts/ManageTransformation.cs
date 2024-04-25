using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class ManageTransformation : MonoBehaviour
{
    public GameObject[] playerList;
    public GameObject lightParticles;
    public GameObject[] BtnList;
    public GameObject[] ObjList;
    public GameObject slime;
    public GameObject line;
    public GameObject ln;
    public GameObject TransformCanvas;
    Coroutine crtn;
    public GameObject slimeBtn;
    public LayerMask defaultlayer;
    public LayerMask playerlayer;
    public void OnChosenInPanel(int BtnNumber)
    {
        if (Camera.main.GetComponent<playerFollow>().player != playerList[BtnNumber])
        {
            foreach (GameObject gmb in BtnList)
            {
                gmb.GetComponent<Image>().color = new Color32(255, 255, 255, Convert.ToByte(0.4f * 255));
            }
            slimeBtn.GetComponent<Image>().color = new Color32(255, 255, 255, Convert.ToByte(0.4f * 255));
            BtnList[BtnNumber].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            if (ln != null)
                Destroy(ln);
            foreach (GameObject gmb in playerList)
            {
                gmb.GetComponent<Light2D>().enabled = false;
                gmb.GetComponent<Player>().enabled = false;
            }
            if (Camera.main.GetComponent<playerFollow>().player.tag == "Slime")
            {
                slime.GetComponent<SlimeController>().enabled = false;
                slime.layer = 1;
                slime.GetComponent<Animation>().Play();
                if (crtn != null)
                {
                    StopCoroutine(crtn);
                }
                crtn = StartCoroutine(InvokeStopBlooming(BtnNumber, 0.4f));
            }
            else
            {
                if(crtn != null)
                {
                    StopCoroutine(crtn);
                }
                crtn = StartCoroutine(InvokeStopBlooming(BtnNumber, 0));
            }
        }
    }
    public IEnumerator InvokeStopBlooming(int BtnNumber, float waittime)
    {
        yield return new WaitForSeconds(waittime);
        ln = Instantiate(line, slime.transform.position, Quaternion.identity);
        ln.GetComponent<LineThatFollows>().WhatToFollow = playerList[BtnNumber];
        playerList[BtnNumber].GetComponent<Light2D>().enabled = true;
        playerList[BtnNumber].GetComponent<Player>().enabled = true;
        Camera.main.GetComponent<playerFollow>().player = playerList[BtnNumber];
        Invoke(nameof(InvokeStopTwo), 0.3f);
    }
    public void InvokeStopTwo()
    {
        slime.layer = 6;
    }
    public void OnChosenSlimel()
    {
        foreach (GameObject gmb in BtnList)
        {
            gmb.GetComponent<Image>().color = new Color32(255, 255, 255, Convert.ToByte(0.3f * 255));
        }
        slimeBtn.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        if (Camera.main.GetComponent<playerFollow>().player.tag != "Slime")
        {
            Transform pltr = Camera.main.GetComponent<playerFollow>().player.transform;
            GameObject lights = Instantiate(lightParticles, pltr.position, pltr.rotation);
            if (ln != null)
                Destroy(ln);
            foreach (GameObject gmb in playerList)
            {
                gmb.GetComponent<Light2D>().enabled = false;
                gmb.GetComponent<Player>().enabled = false;
            }
            slime.GetComponent<SlimeController>().enabled = true;
            Camera.main.GetComponent<playerFollow>().player = slime;
        }
    }
    public void Awake()
    {
        slime = GameObject.FindGameObjectWithTag("Slime");
        playerList = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < playerList.Length; i++)
        {
            ObjList[i].SetActive(true);
        }
    }
    private void Update()
    {
        if (TransformCanvas.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && ObjList[0].activeSelf)
            {
                OnChosenInPanel(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2) && ObjList[1].activeSelf)
            {
                OnChosenInPanel(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3) && ObjList[2].activeSelf)
            {
                OnChosenInPanel(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && ObjList[3].activeSelf)
            {
                OnChosenInPanel(3);
            }
        }
    }
}
