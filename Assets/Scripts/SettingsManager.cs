using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class settingssettermanager : MonoBehaviour
{
    public Slider volumeslider;
    public Slider volumeslidermsc;
    public Toggle joysticktoggle;

    public void SetVolume(float volu)
    {
        PlayerPrefs.SetFloat("volume", volu);
    }
    public void ResetBtn()
    {
        PlayerPrefs.SetFloat("volume", 0);
        PlayerPrefs.SetString("sfx", "False");
        if (PlayerPrefs.GetString("sfx") == "True")
        {
            joysticktoggle.isOn = true;
        }
        else
        {
            joysticktoggle.isOn = false;
        }
        volumeslider.value = PlayerPrefs.GetFloat("volume");
    }
    public void SetJoystick(bool jst)
    {
        PlayerPrefs.SetString("sfx", jst.ToString());
    }
    public void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0);
        }
        if (!PlayerPrefs.HasKey("sfx"))
        {
            PlayerPrefs.SetString("sfx", "False");
        }


        volumeslider.value = PlayerPrefs.GetFloat("volume");
        if (PlayerPrefs.GetString("sfx") == "True")
        {
            joysticktoggle.isOn = true;
        }
        else
        {
            joysticktoggle.isOn = false;
        }
    }
}