using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hostage : MonoBehaviour
{
    public GameObject winPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��һЩ���ʱ���ȵĲ����������߽������.

            
            Destroy(gameObject);
        }
    }
}
