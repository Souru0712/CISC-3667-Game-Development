using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victim : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool rightBound = false;
    //[SerializeField] bool leftBound = true;



    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        if (!rightBound)
        {
            rigid.velocity = new Vector2(5, 0);
            if (transform.position.x >= 12)
            {
                rightBound = true;
                Flip();
            }
        }
        if (rightBound)
        {
            rigid.velocity = new Vector2(-5, 0);
            if (transform.position.x <= -12)
            {
                rightBound = false;
                Flip();
            }
        }

    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
}
