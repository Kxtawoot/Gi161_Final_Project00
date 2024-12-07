using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : Weapon
{
    public Rigidbody2D rb2d;
    [SerializeField] private float destroyTime = 5f; // เวลาทำลาย
    public int Damage { get; private set; } = 10; // กำหนดค่า Damage

    public override void Move()
    {
        // ไม่ต้องเคลื่อนที่, ปล่อยให้แรงโน้มถ่วงจัดการ
        Debug.Log("Block ถูกปล่อยลงมา");
    }

    public void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, destroyTime); // ทำลายตัวเองหลังเวลาที่กำหนด
        Move();
    }

    // ตรวจจับการชนกับ Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่าเจอกับ Player หรือไม่
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            // ให้ Player รับความเสียหายจาก Block
            player.TakeDamage(Damage);

            // ทำลาย Block หลังชน
            Destroy(gameObject);
        }
    }

    public override void OnHitWith(Character character)
    {
        if (character is Player)
            character.TakeDamage(this.Damage);
    }
}