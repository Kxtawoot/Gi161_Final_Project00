using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Weapon
{
    public Rigidbody2D rb2d;
    private Vector2 force;

    public override void Move()
    {
        rb2d.AddForce(force, ForceMode2D.Impulse);
    }

    public void Start()
    {
        force = new Vector2(GetShootDirection() * 2, 10);
        rb2d = GetComponent<Rigidbody2D>();
        Move();
        Damage = 20;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(Damage);
            Destroy(player);
        }
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
            character.TakeDamage(this.Damage);
    }
}