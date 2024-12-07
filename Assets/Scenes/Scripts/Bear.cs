using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : Enemy
{
    [SerializeField] private Vector2 velocity;

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

    }

}