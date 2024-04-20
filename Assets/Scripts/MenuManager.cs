using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject SmokeEffect;
    public GameObject CnvMain;
    public GameObject CnvSettings;
    public int lvl;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("CurentLevel"))
        {
            PlayerPrefs.SetInt("CurentLevel", 0);
        }
    }
    public void OpenLastLevel()
    {
        SmokeEffect.SetActive(true);
        Invoke(nameof(InvokeOpenLastLevel), 1f);
    }
    public void OpenLevel(int lvl1)
    {
        lvl = lvl1;
        SmokeEffect.SetActive(true);
        Invoke(nameof(InvokeOpenLevel), 1f);
    }
    public void OpenLvlMenu()
    {
        SmokeEffect.SetActive(true);
        Invoke(nameof(InvokeOpenLvlMenu), 1f);
    }
    public void OpenMenu()
    {
        SmokeEffect.SetActive(true);
        Invoke(nameof(InvokeOpenMenu), 1f);
    }
    public void OpenSettings()
    {
        CnvMain.SetActive(false);
        CnvSettings.SetActive(true);
    }
    public void CloseSettings()
    {
        CnvMain.SetActive(true);
        CnvSettings.SetActive(false);
    }
    public void InvokeOpenMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void InvokeOpenLvlMenu()
    {
        SceneManager.LoadScene("LvlMenu");
    }
    public void InvokeOpenLevel()
    {
        SceneManager.LoadScene("Lvl" + lvl.ToString());
    }
    public void InvokeOpenLastLevel()
    {
        SceneManager.LoadScene("Lvl" + (PlayerPrefs.GetInt("CurentLevel")).ToString());
    }
}
