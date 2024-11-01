using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] AudioSource audio;
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
        if(audio == null)
        {
            audio = GetComponent<AudioSource>();
        }

        InvokeRepeating("GrowObject", 2.0f, 0.2f);

    }

    // Update is called once per frame
    void Update()
    {
        SelfDestroy();
    }
    private void FixedUpdate()
    {
        if (!rightBound)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                rigid.velocity = new Vector2(5, 0);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1) {
                rigid.velocity = new Vector2(7.5f, 0);
            }
            else
            {
                rigid.velocity = new Vector2(10, 0);
            }
            if (transform.position.x >= 12)
            {
                rightBound = true;
                Flip();
            }
        }

        if (rightBound)
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                rigid.velocity = new Vector2(-5, 0);
            }
            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                rigid.velocity = new Vector2(-7.5f, 0);
            }
            else
            {
                rigid.velocity = new Vector2(-10, 0);
            }
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
    private void GrowObject()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0);

    }
    void SelfDestroy()
    {
        if(transform.localScale.x > 6.0f)
        {
            Debug.Log("Target exploded.");
            AudioSource.PlayClipAtPoint(audio.clip, new Vector3(0,0,1));
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
