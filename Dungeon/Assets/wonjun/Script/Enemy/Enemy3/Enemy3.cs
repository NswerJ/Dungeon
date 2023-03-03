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
        // Player�� ���� ��ġ�� �޾ƿ��� Object
        target = GameObject.Find("Player");
        // Player�� ��ġ�� �� ��ü�� ��ġ�� ���� ���� ����ȭ �Ѵ�.
        direction = (target.transform.position - transform.position).normalized;
        // �ʰ� �ƴ� �� ���������� ���ӵ� ����Ͽ� �ӵ� ����
        velocity = 0.05f;
        // Player�� ��ü ���� �Ÿ� ���
        float distance = Vector3.Distance(target.transform.position, transform.position);
        // �����Ÿ� �ȿ� ���� ��, �ش� �������� ����
        if (distance <= 7.0f)
        {


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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
