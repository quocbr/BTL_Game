using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SungTruong : Weapon
{
    private static SungTruong _instance;

    public static SungTruong Instance
    {
        get => _instance;
    }
    
    protected virtual void Awake()
    {
        SungTruong._instance = this;
    }
}
