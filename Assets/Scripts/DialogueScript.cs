using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
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
    public float typingspeed = 0.02f;
    IEnumerator coroutine;

    IEnumerator Type()
    {
        gameObject.GetComponent<soundManager>().sound.loop = true;
        gameObject.GetComponent<soundManager>().PlaySound(1);
        if (Camera.main.GetComponent<playerFollow>().player.tag == "Player")
        {
            Camera.main.GetComponent<playerFollow>().player.GetComponent<Player>().enabled = false;
            Camera.main.GetComponent<playerFollow>().player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Slime").GetComponent<SlimeController>().enabled = false;
            GameObject.FindGameObjectWithTag("Slime").GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
        else if (faces[index].name == "whatToDo")
        {
            Display2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(256, 256);
        }
        Display2.sprite = faces[index];
        foreach (char letter1 in sentences[index].ToCharArray())
        {
            Display.text += letter1;
            yield return new WaitForSeconds(typingspeed);
        }
        gameObject.GetComponent<soundManager>().sound.loop = false;
        btnContinue.SetActive(true);
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Lvl2" || SceneManager.GetActiveScene().name == "Lvl5")
        {
            cnv.SetActive(true);
            coroutine = Type();
            StartCoroutine(coroutine);
            gameObject.GetComponent<soundManager>().PlaySound(0);
        }
    }
    public void Stststtst()
    {
        cnv.SetActive(true);
        coroutine = Type();
        StartCoroutine(coroutine);
    }
    public void ContinueTyping()
    {
        if (cnv.activeSelf)
        {
            if (sentences[index] != "I need to leave the room myself, not in a human body")
            {
                index++;
            }
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
                cnvInGame.SetActive(true);
                btnContinue.SetActive(false);
                cnv.SetActive(false);
            }
        }
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return)) && cnv.activeSelf)
        {
            gameObject.GetComponent<soundManager>().sound.loop = false;
            StopCoroutine(coroutine);
            Display.text = sentences[index];
            btnContinue.SetActive(true);
        }
    }
}