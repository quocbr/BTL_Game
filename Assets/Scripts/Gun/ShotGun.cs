using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShotGun : Weapon
{
    private static ShotGun _instance;
    private Weapon _weaponImplementation;

    public static ShotGun Instance
    {
        get => _instance;
    }
    protected virtual void Awake()
    {
        ShotGun._instance = this;
    }

    public override void SoundHit()
    {
        SoundManager.Instance.OnPlaySound(SoundType.shotgun);
    }

    protected override void FireBullet()
    {
        speedFire = SpeedFire;

        GameObject bulletInstantiate = Instantiate(this.bullet, firePos.position, Quaternion.identity);
        GameObject bulletInstantiate1 = Instantiate(this.bullet, firePos.position, Quaternion.identity);
        GameObject bulletInstantiate2 = Instantiate(this.bullet, firePos.position, Quaternion.identity);
        Rigidbody2D rb = bulletInstantiate.GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = bulletInstantiate1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bulletInstantiate2.GetComponent<Rigidbody2D>();
        bulletInstantiate.GetComponent<DamageSender>().SetDamage(damage);
        bulletInstantiate1.GetComponent<DamageSender>().SetDamage(damage);
        bulletInstantiate2.GetComponent<DamageSender>().SetDamage(damage);
        
        Vector3 s1 = Quaternion.Euler(0f, 0f, 10f) * transform.right;
        Vector3 s2 = Quaternion.Euler(0f, 0f, -10f) * transform.right;
        
        rb.AddForce(transform.right* bulletForce, ForceMode2D.Impulse);
        rb1.AddForce(s1 * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(s2 * bulletForce, ForceMode2D.Impulse);
        
        Destroy(bulletInstantiate, 2f);
        Destroy(bulletInstantiate1, 2f);
        Destroy(bulletInstantiate2, 2f);
        
        GameObject muzzleInstantiate = Instantiate(this.muzzle, firePos.position, transform.rotation, transform);

        Destroy(muzzleInstantiate, 0.2f);
    }
}
