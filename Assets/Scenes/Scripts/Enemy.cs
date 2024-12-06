using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    private int damageHit;
    public int DamageHit
    {
        get
        {
            return damageHit;
        }
        set
        {
            damageHit = value;
        }
    }
    private void Start()
    {
        Behaviour();
    }

    public abstract void Behaviour();
}