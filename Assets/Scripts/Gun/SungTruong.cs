using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SungTruong : Weapon
{
    private static SungTruong _instance;
    private Weapon _weaponImplementation;

    public static SungTruong Instance
    {
        get => _instance;
    }
    
    protected virtual void Awake()
    {
        SungTruong._instance = this;
    }

    public override void SoundHit()
    {
        SoundManager.Instance.OnPlaySound(SoundType.sungtruong);
    }
}
