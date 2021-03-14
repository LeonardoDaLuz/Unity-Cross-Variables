using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class AudioSingleton : MonoBehaviour
{
    private static AudioSingleton _instance;
    public bool debugAudio;
    public AudioSource musicChannel;
    public AudioSource[] Channels;
    private static float GlobalEffectsVolume = 1f;
    private static float GlobalMusicVolume = 1f;
    [ReadOnlyInPlayMode]
    public int CurrentChannel = -1;
    //private AudioSingleton()
    //{
    //    Require();
    //}

    public static AudioSingleton instance
    {
        get
        {
            if (_instance == null)
            {
                var AudioSingletonPrefab = (GameObject)FileUtility.LoadFile("AudioSingletonPrefab");
                var obj = Instantiate(AudioSingletonPrefab, Vector3.zero, Quaternion.identity);
                _instance = obj.GetComponent<AudioSingleton>();
                if (Camera.main != null)
                {
                    //       _instance.transform.parent = Camera.main.transform;
                    //     _instance.transform.localPosition = Vector3.zero;
                }
            }
            return _instance;
        }
    }

    public void OnEnable()
    {
        _instance = this;
        LoadPrefs();

    }

    public void LoadPrefs()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
            GlobalMusicVolume = PlayerPrefs.GetFloat("MusicVolume");

        if (PlayerPrefs.HasKey("EffectsVolume"))
            GlobalEffectsVolume = PlayerPrefs.GetFloat("EffectsVolume");

        musicChannel.volume = GlobalMusicVolume;
    }
    public void PlaySFX(AudioClip clip, Vector3 Position, float Volume)
    {


        CurrentChannel++;
        if (CurrentChannel > Channels.Length - 1)
            CurrentChannel = 0;

        Channels[CurrentChannel].volume = Volume * GlobalEffectsVolume;
        Channels[CurrentChannel].transform.position = Position;
        Channels[CurrentChannel].clip = clip;
        Channels[CurrentChannel].Play();

#if UNITY_EDITOR
        if (debugAudio)
        {
            Debug.Log("PlaySfx(" + clip.name + "," + Position + "," + Volume + ") on channel " + CurrentChannel);
        }
#endif
    }

    public void PlaySFX(AudioClip[] RandomClip, Vector3 Position, float Volume)
    {
        if (RandomClip.Length == 0)
            return;

        PlaySFX(RandomClip[Random.Range(0, RandomClip.Length - 1)], Position, Volume);
    }

}
