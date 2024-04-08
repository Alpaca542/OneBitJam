using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public GameObject Panel;
    public float typingspeed = 0.02f;
    IEnumerator coroutine;

    IEnumerator Type()
    {
        btnContinue.SetActive(false);
        Display.text = "";
        if (faces[index].name == "SlimeTexture")
        {
            Display2.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(300, 190);
            Display2.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
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
        coroutine = Type();
        StartCoroutine(coroutine);
    }
    public void ContinueTyping()
    {
        index++;
        if(Array.IndexOf(stopIndexes, index) == -1)
        {
            coroutine = Type();
            StartCoroutine(coroutine);
        }
        else
        {
            btnContinue.SetActive(false);
            Panel.SetActive(false);
        }
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