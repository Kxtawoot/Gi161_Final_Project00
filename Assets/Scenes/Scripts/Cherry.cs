using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Cherry : Weapon
{
    [SerializeField] private float speed;

    void Start()
    {
        Damage = 10;
        speed = 4.0f * GetShootDirection();
    }
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime;
        float newY = transform.position.y;
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }

    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
            character.TakeDamage(this.Damage);

    }
    private void FixedUpdate()
    {
        Move();
    }

}