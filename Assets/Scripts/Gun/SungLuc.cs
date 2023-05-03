using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SungLuc : Weapon
{
    private static SungLuc _instance;

    public static SungLuc Instance
    {
        get => _instance;
    }
    
    protected virtual void Awake()
    {
        SungLuc._instance = this;
    }
}
