using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour {
    [GetComponentHereAttribute]
    public Image Button;
    public Sprite ImageOn;
    public Sprite ImageOff;
    bool On = true;

    public void audioToggle()
    {//
      //  AudioSingleton.instance.ToggleAudio();
        if(On)
        {
            On = false;
            Button.sprite = ImageOff;
        } else
        {
            On = true;
            Button.sprite = ImageOn;
        }
    }
    public void MusicToggle()
    {
      //  AudioSingleton.instance.ToggleSoundtrack();
        if (On)
        {
            On = false;
            Button.sprite = ImageOff;
        }
        else
        {
            On = true;
            Button.sprite = ImageOn;
        }
    }
}
