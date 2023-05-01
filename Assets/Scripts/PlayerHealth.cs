using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected int currentHealth;
    [SerializeField] protected HealthBar healthBar;

    public UnityEvent OnDeath;

    private void OnEnable()
    {
        OnDeath.AddListener(Death);
        OnDeath.AddListener(falling);
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth,maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        healthBar.UpdateBar(currentHealth,maxHealth);
    }

    protected void Death()
    {
        //Destroy(gameObject);
    }

    protected void falling()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
}
