using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private Animator myAnim;
    public float playerMoveSpeed;
    public Vector3 direction;
    SpriteRenderer sp;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        direction = new Vector2(x, y);
        /*playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical")) * playerMoveSpeed * Time.deltaTime;*/

        
        if (direction.x < 0)
        {
            sp.flipX = false;
            myAnim.SetBool("Run", true);
        }
        else if (direction.x > 0)
        {
            sp.flipX = true;
            myAnim.SetBool("Run", true);
        }
        else if(direction.x == 0)
        {
            myAnim.SetBool("Run", false);
        }
    }
}
