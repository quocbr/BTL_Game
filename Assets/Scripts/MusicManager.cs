using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicType
{
    Main = 0,
    GameOver = 1,
}

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;

    public static MusicManager Instance
    {
        get => _instance;
    }

    [SerializeField] protected AudioSource audioFx;

    protected virtual void Awake()
    {
        MusicManager._instance = this;
    }

    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.GetComponent<AudioSource>();
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
    
    public virtual void SetMusic(bool set)
    {
        if(set) audioFx.Pause();
        else audioFx.UnPause();
    }

    public virtual void OnPlayMusic(MusicType musicType)
    {
        var audio = Resources.Load<AudioClip>($"Musics/{musicType.ToString()}");

        audioFx.loop = true;
        audioFx.clip = audio;
        audioFx.Play();
    }
}