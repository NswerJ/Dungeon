using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeView : MonoBehaviour
{
    [SerializeField] PlayerMovement[] players;
    [SerializeField] CinemachineVirtualCamera vcam;

    public float maxDelayTime = 1f; //쿨타임 조정 하려면 이 변수 바꾸셈
    public float delayTime;

    private void Start()
    {
        delayTime = 1f;
        players[1].enabled = false;
        players[0].enabled = true;
    }

    private void ChangePlayer01()
    {
        vcam.Follow = players[0].transform;
        players[1].enabled = false;
        players[0].enabled = true;


        players[1].rb.bodyType = RigidbodyType2D.Static;
        players[0].rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void ChangePlayer02()
    {
        vcam.Follow = players[1].transform;
        players[0].enabled = false;
        players[1].enabled = true;

        players[0].rb.bodyType = RigidbodyType2D.Static;
        players[1].rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void Update()
    {
        delayTime += Time.deltaTime;

        if (delayTime >= maxDelayTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ChangePlayer01();
                delayTime = 0f;
            }
        }

        if (delayTime >= maxDelayTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangePlayer02();
                delayTime = 0f;
            }
        }
    }
}
