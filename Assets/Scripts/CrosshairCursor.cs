using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    
    void Update()
    {
        Vector2 mousrPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousrPos;
    }
}
