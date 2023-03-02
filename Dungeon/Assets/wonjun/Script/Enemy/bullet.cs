using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class bullet : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected GameObject player;

    private protected Rigidbody2D rb;
    private protected Vector2 movement;
}
