using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    Enemy enemy;
    Enemy2 enemy2;
    Enemy3 enemy3;
    private void Start()
    {
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        enemy2 = GameObject.Find("Enemy 2").GetComponent<Enemy2>();
        enemy3 = GameObject.Find("Enemy 3").GetComponent<Enemy3>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemy.follow = false;
            enemy2.follow2 = false;
            enemy3.follow3 = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy.follow = true;
        enemy2.follow2= true;
        enemy3.follow3 = true;
    }
}
