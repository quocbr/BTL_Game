using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using Unity.VisualScripting;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] protected LayerMask expLayer;
    [SerializeField] protected float range;
    [SerializeField] protected float moveSpeed;

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
}
