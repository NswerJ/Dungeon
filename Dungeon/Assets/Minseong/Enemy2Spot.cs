using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spot : MonoBehaviour
{
    bool follow;
    void Start()
    {

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 5)
            follow = false;
        else /*if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) <= 10)*/
            follow = true;


        GetComponent<Enemy2>().follow2 = follow;
    }
}
