using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulture : Enemy, IShootable
{
    [SerializeField] private float attackRange;
    public Player player;
    
    [field: SerializeField] public Transform SpawnPoint { get; set; }
    [field: SerializeField] public GameObject Bullet { get; set; }
    public bool FacingRight { get; }

    [field: SerializeField] public float ReloadTime { get; set; }
    [field: SerializeField] public float WaitTime { get; set; }

    private void Update()
    {
        WaitTime -= Time.deltaTime;

        Behaviour();

        if (WaitTime < 0f)
        {
            WaitTime = ReloadTime;
        }

    }

    public override void Behaviour()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        if (distance < attackRange)
        {
            Shoot();
        }
    }
    public void Start()
    {
        Init(10);
    }
    public void Shoot()
    {
        if (WaitTime <= 0)
        {
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Block block = obj.GetComponent<Block>();
            block.Init(20, this);

        }
    }
}