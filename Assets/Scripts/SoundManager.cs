using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    button = 0,
    sungluc = 1,
    sungtruong = 2,
    shotgun = 3,
    levelup = 4,
    choose = 5,
    playerdead = 6,
    ghostdead = 7,
}
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get => _instance; }

    [SerializeField] protected AudioSource audioFx;

    protected virtual void Awake()
    {
        SoundManager._instance = this;
    }

    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.GetComponent<AudioSource>();
            audioFx.playOnAwake = false;
        }
    }

    public void SetVolume(float value)
    {
        audioFx.volume = value;
    }
    
    public void SetMute(bool value)
    {
        audioFx.mute = value;
    }
    
    public virtual void OnPlaySound(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>($"Sounds/{soundType.ToString()}");
        audioFx.PlayOneShot(audio);
    }
}
