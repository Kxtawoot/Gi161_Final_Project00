using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Weapon
{
    public Rigidbody2D rb2d;
    [SerializeField] private float destroyTime = 5f; // ���ҷ����
    public int Damage { get; private set; } = 10; // ��˹���� Damage

    public override void Move()
    {
        // ����ͧ����͹���, ���������ç�����ǧ�Ѵ���
        Debug.Log("Block �١�����ŧ��");
    }

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, destroyTime); // ����µ���ͧ��ѧ���ҷ���˹�
        Move();
    }

    // ��Ǩ�Ѻ��ê��Ѻ Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ��Ǩ�ͺ����͡Ѻ Player �������
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            // ��� Player �Ѻ����������¨ҡ Block
            player.TakeDamage(Damage);

            // ����� Block ��ѧ��
            Destroy(gameObject);
        }
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
            character.TakeDamage(this.Damage);
    }
}