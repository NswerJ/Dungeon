using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    BoxCollider2D boxCollider;

    bool activePlayer;

    bool cd = false;
    float gameoverCountdown = 5f;
    float curCountdown;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        curCountdown = gameoverCountdown;
    }

    void Update()
    {
        if (cd)
        {
            curCountdown -= Time.deltaTime;
        }
        if (curCountdown <= 0)
        {
            if (activePlayer)
                GameObject.Find("Controller").GetComponent<changeminseong>().ChangePlayer01();
            else if (!activePlayer)
                GameObject.Find("Controller").GetComponent<changeminseong>().ChangePlayer02();

            Debug.Log("change view");
            cd = false;
            curCountdown = gameoverCountdown;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            if (!cd)
                cd = true;
            else
            {
                if (curCountdown > 0)
                {
                    Debug.Log("gameover");
                }
            }
        }
    }
}
