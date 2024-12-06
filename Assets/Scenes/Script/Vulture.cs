using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vulture : Enemy, IShootable
{
    [SerializeField] private float attackRange;
    public Player player;

    [field: SerializeField] public Transform SpawnPoint { get; set; }
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public float ReloadTime { get; set; }
    [field: SerializeField] public float WaitTime { get; set; }

    public bool FacingRight { get; set; } // �礷�ȷҧ�ͧ����ԧ
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>(); // ��˹� Animator �����㹤���
    }

    private void Update()
    {
        WaitTime -= Time.deltaTime; // Ŵ������
        Behaviour(); // ���¡�ĵԡ����ͧ�ѵ��

        // �����������������
        if (WaitTime < 0f)
        {
            WaitTime = ReloadTime;
        }
    }

    public override void Behaviour()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        // ��Ҽ����������������������ԧ
        if (distance < attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (WaitTime <= 0)
        {
            anim.SetTrigger("Shoot"); // ���¡�� trigger "Shoot" � Animator

            // �ӹǳ��ȷҧ����ԧ (����ѹ价ҧ������ͫ���)
            Vector3 shootDirection = FacingRight ? Vector3.right : Vector3.left;

            // ���ҧ Bullet ��� SpawnPoint
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);

            // ��駷�ȷҧ����ԧ
            obj.GetComponent<Rigidbody2D>().velocity = shootDirection * 10f;

            // �ҡ�� Block Component ��ӡ�á�˹����
            Block block = obj.GetComponent<Block>();
            if (block != null)
            {
                block.Init(20, this); // ��˹�����������
            }
            else
            {
                Debug.LogError("Bullet does not have Block component!");
            }

            WaitTime = ReloadTime; // ��������
        }
    }
}
