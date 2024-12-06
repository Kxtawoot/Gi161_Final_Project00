using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int _health;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    
    public Animator Anim;
    public Rigidbody2D Rb;
    public HealthBar healthBar;
    public bool IsDead()
    {
        return Health <= 0;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.SetMinHealth(_health);
        Debug.Log($"Player took {damage} Damage, Remaining Health{Health}");
        if (IsDead())
        {
            Destroy(gameObject);
        }
    }

    public void Init(int newHealth)
    {
        Health = newHealth;
    }

    public void OnHitWith()
    {

    }
}