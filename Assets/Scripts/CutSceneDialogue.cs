using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneDialogue : MonoBehaviour
{
    public Text Display;
    public Image Display2;
    public string[] sentences;
    public Sprite[] faces;
    public int[] stopIndexes;
    public int index;
    public GameObject btnContinue;
    public GameObject cnv;
    public GameObject cnvInGame;
    public GameObject explosion1;
    public float typingspeed = 0.02f;
    public GameObject finisher;
    public GameObject player;
    public GameObject slime;
    IEnumerator coroutine;

    IEnumerator Type()
    {
        if (Camera.main.GetComponent<playerFollow>().player.tag == "Player")
        {
            Camera.main.GetComponent<playerFollow>().player.GetComponent<Player>().enabled = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Slime").GetComponent<SlimeController>().enabled = false;
        }
        cnvInGame.SetActive(false);
        btnContinue.SetActive(false);
        Display.text = "";
        if (faces[index].name == "SlimeTexture")
        {
            Display2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 126);
        }
        else if (faces[index].name == "mantexturepng")
        {
            Display2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(256, 256);
        }
        Display2.sprite = faces[index];
        foreach (char letter1 in sentences[index].ToCharArray())
        {
            Display.text += letter1;
            yield return new WaitForSeconds(typingspeed);
        }
        btnContinue.SetActive(true);
    }
    private void Start()
    {
        cnv.SetActive(true);
        coroutine = Type();
        StartCoroutine(coroutine);
    }
    public void Stststtst()
    {
        cnv.SetActive(true);
        coroutine = Type();
        StartCoroutine(coroutine);
    }
    public void ContinueTyping()
    {
        index++;
        if (index == 5 && SceneManager.GetActiveScene().name == "Lvl1")
        {
            explosion1.SetActive(true);
            player.SetActive(false);
            slime.SetActive(true);
            Invoke(nameof(LastWords), 0.8f);
            btnContinue.SetActive(false);
            cnv.SetActive(false);
        }
        else if(index == 6 && SceneManager.GetActiveScene().name == "Lvl1")
        {
            btnContinue.SetActive(false);
            cnv.SetActive(false);
            finisher.GetComponent<LevelFinisher>().StopTheLevel();
        }
        else if (index == stopIndexes[0] && SceneManager.GetActiveScene().name == "Lvl6")
        {
            if (Camera.main.GetComponent<playerFollow>().player.tag == "Player")
            {
                Camera.main.GetComponent<playerFollow>().player.GetComponent<Player>().enabled = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Slime").GetComponent<SlimeController>().enabled = true;
            }

            cnvInGame.SetActive(true);
            btnContinue.SetActive(false);
            cnv.SetActive(false);
        }
        else if (index == stopIndexes[1] && SceneManager.GetActiveScene().name == "Lvl6")
        {
            cnv.SetActive(false);
            explosion1.SetActive(true);
            Invoke(nameof(finishlevel), 0.8f);
        }
        else
        {
            coroutine = Type();
            StartCoroutine(coroutine);
        }
        if(SceneManager.GetActiveScene().name == "Lvl6")
        {

            if (faces[index].name == "whatToDo")
            {
                Display2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(256, 256);
            }
        }
    }
    public void LastWords()
    {
        cnv.SetActive(true);
        coroutine = Type();
        StartCoroutine(coroutine);
    }
    public void finishlevel()
    {
        finisher.GetComponent<LevelFinisher>().StopTheLevel();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            StopCoroutine(coroutine);
            Display.text = sentences[index];
            btnContinue.SetActive(true);
        }
    }
}