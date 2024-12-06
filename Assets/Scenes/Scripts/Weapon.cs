using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected int _damage;
    public int Damage
    {
        get
        {
            return _damage;
        }
        set
        {
            _damage = value;
        }
    }

    protected IShootable shooter;

    public abstract void OnHitWith(Character character);
    public abstract void Move();
    public int GetShootDirection()
    {
        return shooter.FacingRight ? 1 : -1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnHitWith(other.GetComponent<Character>());
    }

    public void Init(int damage, IShootable owner)
    {
        Damage = damage;
        shooter = owner;
    }



}