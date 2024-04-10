using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinisher : MonoBehaviour
{
    public GameObject panelForTheEnd;
    public GameObject SmokeEffect;
    public void StopTheLevel()
    {
        panelForTheEnd.SetActive(true);
        PlayerPrefs.SetInt("CurentLevel", System.Convert.ToInt32(SceneManager.GetActiveScene().name.Replace("Lvl", "")));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StopTheLevel();
    }
    public void OnNextPressed()
    {
        SmokeEffect.SetActive(true);
        Invoke(nameof(InvokeOpenLastLevel), 1f);
    }
    public void OnLevelsPresed()
    {
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
