using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{
    [SerializeField] private Vector2 velocity;
    [SerializeField] private Transform[] movePoints;

    private void Start()
    {
        Init(100);
        Behaviour();
    }
    private void FixedUpdate()
    {
        Behaviour();
    }
    
    public override void Behaviour()
    {
        Rb.MovePosition(Rb.position + velocity * Time.fixedDeltaTime);

        if (Rb.position.x <= movePoints[0].position.x && velocity.x < 0)
            FilpCharacter();

        else if (Rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            FilpCharacter();
        }
    }

    private void FilpCharacter()
    {
        velocity *= -1;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}