using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Weapon : MonoBehaviour
{

    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform firePos;
    [SerializeField] protected float SpeedFire = 0.2f;
    [SerializeField] protected float SpeedFireMax = 0.1f;
    [SerializeField] protected float bulletForce = 6f;
    
    [SerializeField] protected Vector2 range;
    [SerializeField] protected LayerMask enemyLayer;
    [SerializeField] private GameObject _player;
    
    [SerializeField] protected int damage = 1;
    [SerializeField] protected int damageMax = 100;
    [SerializeField] protected GameObject muzzle;

    protected float speedFire;
    

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
            this.SoundHit();
        }
    }

    public abstract void SoundHit();
    
    //Move to mouse
    // protected virtual void RotateGun()
    // {
    //     Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //     Vector3 aimDir = (mousePos - this.transform.position).normalized;
    //     float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
    //     transform.eulerAngles = new Vector3(0, 0, angle);
    //     this.transform.localScale = new Vector3(Mathf.Sign(aimDir.x), Mathf.Sign(aimDir.x), 1);
    // }
    
    protected virtual void RotateGun()
    {
        Collider2D ePos = FindNearestEnemy();
        
        if(ePos == null) return;
        
        Vector3 mousePos = ePos.transform.position;

        Vector3 aimDir = (mousePos - this.transform.position).normalized;
        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
        
        _player.transform.localScale = new Vector3(Mathf.Sign(aimDir.x), 1, 1);
        this.transform.localScale = new Vector3(Mathf.Sign(aimDir.x), Mathf.Sign(aimDir.x), 1);
    }
    
    private Collider2D FindNearestEnemy()
    {
        Collider2D nearestEnemy = null;
        float nearestDistance = Mathf.Infinity;
        Vector3 currentPosition = _player.transform.position;

        Collider2D[] enemies = Physics2D.OverlapBoxAll(_player.transform.position, range,0.2f, enemyLayer);
        if (enemies != null && enemies.Length > 0)
        {

            foreach (Collider2D enemy in enemies)
            {
                Debug.Log(enemy.name);
                float distance = Vector3.Distance(currentPosition, enemy.transform.position);

                if (distance < nearestDistance)
                {
                    nearestEnemy = enemy;
                    nearestDistance = distance;
                }
            }
        }

        return nearestEnemy;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_player.transform.position,range);
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
        if(SpeedFire <= SpeedFireMax) return;
        this.SpeedFire -= (this.SpeedFire * sf / 100f);
    }
}