using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private static Magnet _instance;

    public static Magnet Instance
    {
        get => _instance;
    }
    [SerializeField] protected LayerMask expLayer;
    [SerializeField] protected float range;
    [SerializeField] protected float moveSpeed;

    protected void Awake()
    {
        Magnet._instance = this;
    }
    
    private void Update()
    {
        TheHandle();
    }

    protected void TheHandle()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, expLayer);
        if (colliders != null && colliders.Length > 0)
        {
            foreach (Collider2D collider in colliders) 
            {
                if (collider)
                {
                    collider.transform.position = Vector3.MoveTowards(
                        collider.transform.position,
                        transform.position, moveSpeed * Time.deltaTime);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,range);
    }

    public void AddRange(float r = 0.1f)
    {
        this.range += r;
    }
}
