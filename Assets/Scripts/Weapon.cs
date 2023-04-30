using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform firePos;
    [SerializeField] protected float SpeedFire = 0.2f;
    [SerializeField] protected float bulletForce = 5f;
    [SerializeField] protected GameObject muzzle;
    
    
    private float speedFire;

    protected void Start()
    {
        speedFire = SpeedFire;
    }

    protected void Update()
    {
        RotateGun();

        speedFire -= Time.deltaTime;
        if (Input.GetMouseButton(0) && speedFire < 0)
        {
            FireBullet();
        }
    }

    protected virtual void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimDir = (mousePos - this.transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        this.transform.localScale = new Vector3(Mathf.Sign(aimDir.x), Mathf.Sign(aimDir.x), 1);
    }
    
    void FireBullet()
    {
        speedFire = SpeedFire;
        GameObject bulletInstantiate = Instantiate(this.bullet, firePos.position, Quaternion.identity);
        GameObject muzzleInstantiate = Instantiate(this.muzzle, firePos.position, transform.rotation, transform);
        Rigidbody2D rb = bulletInstantiate.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right*bulletForce,ForceMode2D.Impulse);
        
        Destroy(bulletInstantiate,2f);
        Destroy(muzzleInstantiate,0.2f);
    }
}
