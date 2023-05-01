using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    [SerializeField] protected MapCode mapCode;
    [SerializeField] protected MapInfinity currentMap;
    [SerializeField] protected MapInfinity newMapInfinity;
    [SerializeField] protected Vector3 spawnPosOffset = new Vector3(0,0,0);

    private MapInfinity _mapInfinity;
    protected virtual void Awake()
    {
        this.LoadCurrentMap();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string objTag = other.transform.tag;
        //Debug.Log(this.transform.name +"other.tag: "+ objTag);
        if(objTag == "Player") this.SpawnMap();
    }
    
    protected virtual void SpawnMap()
    {
        if (this.MapIsSpawned()) return;

        Vector3 spawnPos = this.currentMap.transform.position;
        spawnPos.x += this.spawnPosOffset.x;
        spawnPos.y += this.spawnPosOffset.y;
        spawnPos.z += this.spawnPosOffset.z;

        GameObject newMap = Instantiate(this.currentMap.gameObject);
        newMap.transform.position = spawnPos;
        newMap.name = this.currentMap.name;
        this.newMapInfinity = newMap.GetComponent<MapInfinity>();

        //this.currentMap.Set(this.mapCode, this.newMapInfinity);
    }

    protected virtual bool MapIsSpawned()
    {
        //_mapInfinity = this.transform.parent.GetComponent<MapInfinity>();
        return this._mapInfinity.Get(this.mapCode) != null;
    }

    protected virtual void LoadCurrentMap()
    {
       this._mapInfinity = transform.parent.GetComponent<MapInfinity>();
    }
}
