using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OpenLvl()
    {
        SceneManager.LoadScene("Lvl1");
    }
    public void OpenSettings()
    {
        //settings maybe
    }
}
