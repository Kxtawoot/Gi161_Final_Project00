using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject);
                GameOver(); // เรียกใช้ฟังก์ชันจบเกม
            }
        }
    }

    // ฟังก์ชันสำหรับจบเกม
    private void GameOver()
    {
        // แสดงข้อความใน Console
        Debug.Log("You Win!");

        // หยุดเวลาในเกม
        Time.timeScale = 0; // หยุดการทำงานของเกม
    }
}

