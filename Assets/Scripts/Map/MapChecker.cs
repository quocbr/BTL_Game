using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChecker : MonoBehaviour
{
    [SerializeField] protected MapInfinity currentMap;
    [SerializeField] protected MapCode mapCode;
    [SerializeField] protected MapCode mapCodeRelate;

    [SerializeField] protected MapInfinity test;
    protected virtual void Awake()
    {
        this.LoadCurrentMap();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Map"))
        {
            Debug.Log(this.transform.parent.name + " Trigger "+ other.transform.name);
                        MapInfinity newMap = other.transform.parent.GetComponent<MapInfinity>();
                        if (newMap == null) return;
                                
                        this.currentMap.Set(this.mapCode, newMap);
                        newMap.Set(this.mapCodeRelate, this.currentMap);
        }

        
        
    }

    protected virtual void LoadCurrentMap()
    {
        this.currentMap = transform.parent.GetComponent<MapInfinity>();
    }
}
