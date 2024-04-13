using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinisher : MonoBehaviour
{
    public GameObject panelForTheEnd;
    public GameObject panelForPause;
    public DialogueScript dlgmng;
    public GameObject SmokeEffect;
    public void StopTheLevel()
    {
        panelForTheEnd.SetActive(true);
        PlayerPrefs.SetInt("CurentLevel", System.Convert.ToInt32(SceneManager.GetActiveScene().name.Replace("Lvl", "")));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Slime")
        {
            StopTheLevel();
        }
        else if(collision.gameObject.tag == "Player")
        {
            dlgmng.Stststtst();
            dlgmng.index--;
        }
    }
    public void OnNextPressed()
    {
        Time.timeScale = 1;
        SmokeEffect.SetActive(true);
        Invoke(nameof(InvokeOpenLastLevel), 1f);
    }
    public void OnPause()
    {
        panelForPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnRestart()
    {
        Time.timeScale = 1;
        SmokeEffect.SetActive(true);
        Invoke(nameof(OnRestartInvoke), 1f);
    }
    public void OnRestartInvoke()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnResume()
    {
        panelForPause.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnLevelsPresed()
    {
        Time.timeScale = 1;
        SmokeEffect.SetActive(true);
        Invoke(nameof(InvokeOpenLvlMenu), 1f);
    }
    public void InvokeOpenLastLevel()
    {
        SceneManager.LoadScene("Lvl" + (PlayerPrefs.GetInt("CurentLevel")+1).ToString());
    }
    public void InvokeOpenLvlMenu()
    {
        SceneManager.LoadScene("LvlMenu");
    }
}
