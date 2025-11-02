using System;
using Unity.Collections;
using UnityEngine;

public class HealthCompponent : MonoBehaviour
{
    public Action OnDeath; 
    public int MaxHealth;
    [ReadOnly] private int _currentHealth;

    public void TakeOneDamage()
    {
        _currentHealth--;

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