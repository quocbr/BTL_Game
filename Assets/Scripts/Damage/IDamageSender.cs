using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamageSender : MonoBehaviour
{
    [SerializeField] protected float damage = 1;

    public void SetDamage(float d)
    {
        damage = d;
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        
    }
}
