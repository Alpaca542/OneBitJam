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
    public GameObject explosion1;
    public void StopTheLevel()
    {
        if(SceneManager.GetActiveScene().name != "Lvl1" && SceneManager.GetActiveScene().name != "Lvl6")
        {
            GameObject.FindGameObjectWithTag("Slime").SetActive(false);
            explosion1.SetActive(true);
            if (SceneManager.GetActiveScene().name == "Lvl2" || SceneManager.GetActiveScene().name == "Lvl3")
                Camera.main.GetComponent<Camera>().orthographicSize = 10f;
            if (SceneManager.GetActiveScene().name == "Lvl4")
                Camera.main.GetComponent<Camera>().orthographicSize = 10f;
            if (SceneManager.GetActiveScene().name == "Lvl5")
                Camera.main.GetComponent<Camera>().orthographicSize = 15f;
            Camera.main.GetComponent<playerFollow>().enabled = false;
            Camera.main.transform.position = new Vector3(explosion1.transform.position.x, explosion1.transform.position.y, -10);

            Invoke(nameof(StopTheLevelInvoke), 0.8f);
        }
        else
        {
            StopTheLevelInvoke();
        }
    }
    public void StopTheLevelInvoke()
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
