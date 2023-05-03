using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    private static Weapon _instance;

    public static Weapon Instance
    {
        get => _instance;
    }

    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform firePos;
    [SerializeField] protected float SpeedFire = 0.2f;
    [SerializeField] protected float SpeedFireMax = 0.1f;
    [SerializeField] protected float bulletForce = 6f;
    [SerializeField] protected int damage = 1;
    [SerializeField] protected int damageMax = 100;
    [SerializeField] protected GameObject muzzle;

    protected float speedFire;

    protected virtual void Awake()
    {
        Weapon._instance = this;
    }

    protected virtual void Start()
    {
        speedFire = SpeedFire;
    }

    protected virtual void Update()
    {
        RotateGun();

        speedFire -= Time.deltaTime;
        if (speedFire < 0) //Input.GetMouseButton(0) &&
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

    protected virtual void FireBullet()
    {
        speedFire = SpeedFire;

        GameObject bulletInstantiate = Instantiate(this.bullet, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bulletInstantiate.GetComponent<Rigidbody2D>();
        bulletInstantiate.GetComponent<DamageSender>().SetDamage(damage);
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bulletInstantiate, 2f);
        GameObject muzzleInstantiate = Instantiate(this.muzzle, firePos.position, transform.rotation, transform);

        Destroy(muzzleInstantiate, 0.2f);
    }

    public virtual void AddDamage(int dmg = 1)
    {
        if (damageMax <= damage) return;
        this.damage += dmg;
    }

    public virtual void AddSpeedFire(float sf = 5f)
    {
        if(SpeedFire >= SpeedFireMax) return;
        this.SpeedFire -= (this.SpeedFire * sf / 100f);
    }
}