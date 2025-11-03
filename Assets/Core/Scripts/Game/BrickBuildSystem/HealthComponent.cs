using System;
using UnityEngine;

public class HealthCompponent : MonoBehaviour
{
    public Action OnDeath;
    public Action OnTakeDamage;
    public int MaxHealth;
    public int CurrentHealth;

    public void OnEnable()
    {
        CurrentHealth = MaxHealth;        
    }

    public void TakeOneDamage()
    {
        CurrentHealth--;
        OnTakeDamage?.Invoke();
        if (CurrentHealth < 1)
        {
            Die();
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }

    // public void OnDisable()
    // {
    //     OnTakeDamage = null;
    //     OnDeath = null;
    // }
}