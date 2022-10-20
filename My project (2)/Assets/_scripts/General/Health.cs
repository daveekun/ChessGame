using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public void Heal(int amount)
    {
        if (CurrentHealth + amount > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
        else
        {
            CurrentHealth += amount;
        }
    }
    public void TakeDamage(int amount)
    {
        if (CurrentHealth - amount < 0)
        {
            CurrentHealth = 0;
        }
        else
        {
            CurrentHealth -= amount;
        }
    }
}
