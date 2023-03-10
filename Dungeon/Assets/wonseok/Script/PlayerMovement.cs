using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer rend;

    [Header("PlayerStat")]
    public float playerMoveSpeed;

    [Header("Position")]
    Vector3 movementVector;

    [Header("KeyCode")]
    KeyCode leftKey = KeyCode.LeftArrow;
    KeyCode rightKey = KeyCode.RightArrow;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movementVector = new Vector3().normalized;
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");
        Vector3 direction = (movementVector).normalized;
        rb.velocity = direction * playerMoveSpeed;

        if (movementVector.x == 0 && movementVector.y == 0)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }

        bool isLeftKey = Input.GetKey(leftKey);
        bool isRightKey = Input.GetKey(rightKey);

        if (isLeftKey)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (isRightKey)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
