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
            // 加一些人质被获救的播放声音或者结算界面.

            
            Destroy(gameObject);
        }
    }
}
