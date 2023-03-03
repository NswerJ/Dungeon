using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public bool follow2;
    SpriteRenderer sp;
    public GameObject target;
    public Vector3 direction;
    public float velocity;
    public float accelaration;
    public GameObject bullet;
    public float spawnTime = 3f;
    float enemydie = 0f;

    private void Start()
    {
        follow2 = true;
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        spawnTime += Time.deltaTime;
        if(follow2 == true)
        {
            MoveToTarget();
        }
        if (enemydie == 3){
            Destroy(gameObject);
        }
    }

    public void MoveToTarget()
    {
        // Player�� ���� ��ġ�� �޾ƿ��� Object
        target = GameObject.Find("Player");
        // Player�� ��ġ�� �� ��ü�� ��ġ�� ���� ���� ����ȭ �Ѵ�.
        direction = (target.transform.position - transform.position).normalized;
        // �ʰ� �ƴ� �� ���������� ���ӵ� ����Ͽ� �ӵ� ����
        velocity = 0.008f;
        // Player�� ��ü ���� �Ÿ� ���
        float distance = Vector3.Distance(target.transform.position, transform.position);
        // �����Ÿ� �ȿ� ���� ��, �ش� �������� ����
        if (distance <= 10.0f)
        {
            if (spawnTime > 3)
            {
                Instantiate(bullet, transform.position, Quaternion.identity);
                spawnTime = 0f;
                enemydie++;
            }

            this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
                                                   transform.position.y + (direction.y * velocity),
                                                     transform.position.z);
        }
        // �����Ÿ� �ۿ� ���� ��, �ӵ� �ʱ�ȭ 
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
}
