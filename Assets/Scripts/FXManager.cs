using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    private static FXManager _instance;
    public static FXManager Instance { get => _instance; }

    [SerializeField] protected GameObject fxEnemy;
    [SerializeField] protected GameObject fxLevelUp;
    [SerializeField] protected GameObject fxHit;
    protected virtual void Awake()
    {
        FXManager._instance = this;
    }

    public void GetFXEnemy(Vector3 position)
    {
        GameObject fx = Instantiate(fxEnemy, position, Quaternion.identity);
        Destroy(fx,0.5f);
    }
    
    public void GetFXLevelUp(Vector3 position)
    {
        GameObject fx = Instantiate(fxLevelUp, position, Quaternion.identity);
        Destroy(fx,0.5f);
    }
    public void GetFXHit(Vector3 position)
    {
        GameObject fx = Instantiate(fxHit, position, Quaternion.identity);
        Destroy(fx,0.5f);
    }
}
