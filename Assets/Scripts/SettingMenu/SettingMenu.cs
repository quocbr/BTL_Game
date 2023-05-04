using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public void SetVolumeMusic(float volume)
    {
        MusicManager.Instance.SetVolume(volume);
    }
    
    public void SetMuteMusic(bool mute)
    {
        MusicManager.Instance.SetMute(mute);
    }
    
    public void SetVolumeSound(float volume)
    {
        SoundManager.Instance.SetVolume(volume);
    }
    
    public void SetMuteSound(bool mute)
    {
        SoundManager.Instance.SetMute(mute);
    }

    public void Back()
    {
        UIManager.Instance.DeActivePanelSetting();
        UIManager.Instance.SetActivePanelPause();
    }
}
