using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Weapon
{
    public Rigidbody2D rb2d;
    [SerializeField] private Vector2 force;

    public override void Move()
    {
        rb2d.AddForce(force, ForceMode2D.Impulse);
        Debug.Log("Rock เคลื่่อนที่ด้วย Rigiddbody force");
    }
    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Damage = 10;
        force = new Vector2(GetShootDirection() * 5, 10);
        Move();
    }
    public override void OnHitWith(Character character)
    {
        if (character is Player)
            character.TakeDamage(this.Damage);
    }
}