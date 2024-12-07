using System.Collections;
using System.Collections.Generic;
using UnityEngine.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //[SerializeField] float vertical_movement;
    [SerializeField] float horizontal_movement;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] const int SPEED = 7;
    [SerializeField] public bool isFacingRight = true;
    [SerializeField] bool jumpPressed = false;
    [SerializeField] float jumpForce = 200.0f;
    [SerializeField] bool isGrounded = true;

    [SerializeField] Animator animator;

    const int IDLE = 0;
    const int RUN = 1;
    const int JUMP = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if(animator == null)
            animator = GetComponent<Animator>();

        animator.SetInteger("motion", IDLE);
    }

    // Update is called once per frame --used for user input
    //do NOT use for physics & movement
    void Update()
    {
        horizontal_movement = Input.GetAxis("Horizontal");
        //vertical_movement = Input.GetAxis("Vertical");  
        if (Input.GetButtonDown("Jump"))
            jumpPressed = true;
    }

    //called potentially many times per frame
    //use for physics & movement
    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(SPEED * horizontal_movement, rigid.velocity.y);
        //rigid.velocity = new Vector2(rigid.velocity.x, SPEED * vertical_movement);
        if (horizontal_movement < 0 && isFacingRight || horizontal_movement > 0 && !isFacingRight)
        {
            Flip();
        }
        if (jumpPressed && isGrounded)
        {
            Jump();
        }
        else
        {
            jumpPressed = false;
            if (isGrounded)
            {
                if (horizontal_movement > 0 || horizontal_movement < 0)
                {
                    animator.SetInteger("motion", RUN);
                }
                else
                {
                    animator.SetInteger("motion", IDLE);
                }
            }
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void Jump()
    {
        animator.SetInteger("motion", JUMP);
        //rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(new Vector2(0, jumpForce));
        Debug.Log("jumped");
        jumpPressed = false;
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetInteger("motion", IDLE);
        }

        if (collision.gameObject.tag == "Killzone")
            Scorekeeper.Instance.ReloadLevel();

    }

}
