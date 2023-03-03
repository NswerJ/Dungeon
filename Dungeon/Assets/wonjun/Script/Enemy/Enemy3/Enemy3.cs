using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public bool follow3;
    SpriteRenderer sp;
    public GameObject target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;
    public GameObject boom;


    private void Start()
    {
        follow3 = true;
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (follow3)
        {
            MoveToTarget();
        }
    }

    public void MoveToTarget()
    {
        // Player의 현재 위치를 받아오는 Object
        target = GameObject.Find("Player");
        // Player의 위치와 이 객체의 위치를 빼고 단위 벡터화 한다.
        direction = (target.transform.position - transform.position).normalized;
        // 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
        velocity = 0.05f;
        // Player와 객체 간의 거리 계산
        float distance = Vector3.Distance(target.transform.position, transform.position);
        // 일정거리 안에 있을 시, 해당 방향으로 무빙
        if (distance <= 7.0f)
        {


            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                   transform.position.y + (direction.y * velocity),
                                                     transform.position.z);
        }
        // 일정거리 밖에 있을 시, 속도 초기화 
        else
        {
            velocity = 0.0f;
        }

        if (direction.x < 0)
        {
            sp.flipX = false;
        }
        else if (direction.x > 0)
        {
            sp.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
