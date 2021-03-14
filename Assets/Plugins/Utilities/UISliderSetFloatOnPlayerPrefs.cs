using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UISliderSetFloatOnPlayerPrefs : MonoBehaviour
{
    [GetComponentHere]
    public Slider slider;
    public string Key;

    void Start()
    {
        if (PlayerPrefs.HasKey(Key))
        {
            slider.value = PlayerPrefs.GetFloat(Key);
        }
        else
        {
            slider.value = 1f;
            PlayerPrefs.SetFloat(Key, 1f);
        }
    }

    public void SetFloat()
    {
        PlayerPrefs.SetFloat(Key, slider.value);
        AudioSingleton.instance.LoadPrefs();
    }
}
