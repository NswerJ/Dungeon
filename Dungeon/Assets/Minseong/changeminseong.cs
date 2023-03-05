using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class changeminseong : MonoBehaviour
{
    [SerializeField] PlayerMovement[] players;
    [SerializeField] CinemachineVirtualCamera vcam;

    private void Start()
    {
        players[1].enabled = false;
        players[0].enabled = true;
    }

    public void ChangePlayer01()
    {
        vcam.Follow = players[0].transform;
        players[1].enabled = false;
        players[0].enabled = true;
    }

    public void ChangePlayer02()
    {
        vcam.Follow = players[1].transform;
        players[0].enabled = false;
        players[1].enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            ChangePlayer01();

        if (Input.GetKeyDown(KeyCode.R))
            ChangePlayer02();
    }
}
