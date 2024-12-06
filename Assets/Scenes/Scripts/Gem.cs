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
                GameOver(); // ���¡��ѧ��ѹ����
            }
        }
    }

    // �ѧ��ѹ����Ѻ����
    private void GameOver()
    {
        // �ʴ���ͤ���� Console
        Debug.Log("You Win!");

        // ��ش�������
        Time.timeScale = 0; // ��ش��÷ӧҹ�ͧ��
    }
}

