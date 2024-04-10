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
            Display2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 190);
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
        if (Array.IndexOf(stopIndexes, index) == -1)
        {
            coroutine = Type();
            StartCoroutine(coroutine);
        }
        else
        {
            if (Camera.main.GetComponent<playerFollow>().player.tag == "Player")
            {
                Camera.main.GetComponent<playerFollow>().player.GetComponent<Player>().enabled = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("Slime").GetComponent<SlimeController>().enabled = true;
            }
            explosion1.SetActive(true);
            Invoke(nameof(GoToMenu), 0.8f);
            btnContinue.SetActive(false);
            cnv.SetActive(false);
        }
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("LvlMenu");
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