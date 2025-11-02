using System;
using Unity.Collections;
using UnityEngine;

public class HealthCompponent : MonoBehaviour
{
    public Action OnDeath;
    public Action OnTakeDamage;
    public int MaxHealth;
    [ReadOnly] private int _currentHealth;

    public void TakeOneDamage()
    {
        _currentHealth--;
        OnTakeDamage?.Invoke();
        if (_currentHealth < 1)
        {
            Die();
        }
    } 
    
    public void Die()
    {
        gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
}