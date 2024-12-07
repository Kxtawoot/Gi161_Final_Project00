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
   
    public void TakeDamage(int damage)
    {
        
        Health -= damage;
        if (IsDead())
        {
            Destroy(gameObject);
        }
    }

    public bool IsDead()
    {
        return Health <= 0;
    }

    public void Init(int newHealth)
    {
        Health = newHealth;
    }

}