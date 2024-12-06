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

    public bool FacingRight { get; set; } // เช็คทิศทางของการยิง
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>(); // กำหนด Animator ที่ใช้ในคลาส
    }

    private void Update()
    {
        WaitTime -= Time.deltaTime; // ลดเวลารอ
        Behaviour(); // เรียกพฤติกรรมของศัตรู

        // ถ้าหมดเวลาให้รีเซ็ต
        if (WaitTime < 0f)
        {
            WaitTime = ReloadTime;
        }
    }

    public override void Behaviour()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;

        // ถ้าผู้เล่นอยู่ในระยะโจมตีให้ยิง
        if (distance < attackRange)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        if (WaitTime <= 0)
        {
            anim.SetTrigger("Shoot"); // เรียกใช้ trigger "Shoot" ใน Animator

            // คำนวณทิศทางการยิง (ถ้าหันไปทางขวาหรือซ้าย)
            Vector3 shootDirection = FacingRight ? Vector3.right : Vector3.left;

            // สร้าง Bullet ที่ SpawnPoint
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);

            // ตั้งทิศทางการยิง
            obj.GetComponent<Rigidbody2D>().velocity = shootDirection * 10f;

            // หากมี Block Component ก็ทำการกำหนดค่า
            Block block = obj.GetComponent<Block>();
            if (block != null)
            {
                block.Init(20, this); // กำหนดค่าเริ่มต้น
            }
            else
            {
                Debug.LogError("Bullet does not have Block component!");
            }

            WaitTime = ReloadTime; // รีเซ็ตเวลา
        }
    }
}
