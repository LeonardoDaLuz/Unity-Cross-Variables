using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnimationEvents : MonoBehaviour {
    public float volume=1f;
 //   public float delay=0f;
    Vector3 position;
    [Header("RandomSfx Lists")]
    public randomList[] List;

    [System.Serializable]
    public class randomList
    {
        public string name;
        public AudioClip[] Clips;
    }

    public void SetSFXVolume(float _volume)
    {
        volume = _volume;
    }
    public void SetSFXPositionToTransformPosition()
    {
        position = transform.position;
    }
    public void PlaySFX(AudioClip clip)
    {
       AudioSingleton.instance.PlaySFX(clip, position, volume);
    }

    public void PlayRandomSFX(int ListIndex)
    {
        AudioSingleton.instance.PlaySFX(List[ListIndex].Clips, position, volume);
    }
}
