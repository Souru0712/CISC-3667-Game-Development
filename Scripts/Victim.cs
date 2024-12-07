using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Victim : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject eagle;
    [SerializeField] bool isFacingRight = true;
    //[SerializeField] bool rightBound = false;
    //[SerializeField] bool isFacingUp = true;
    [SerializeField] bool upperBound = false;
    [SerializeField] int level;
    [SerializeField] string difficulty;

    [SerializeField] AudioSource deathSFX;
    public Vector2 batPosition;
    const int DEFAULT_POINTS = 5000;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
        {
            rigid = GetComponent<Rigidbody2D>();
        }
        if (deathSFX == null)
        {
            deathSFX = GetComponent<AudioSource>();
        }

        level = Scorekeeper.Instance.getLevel();
        difficulty = PersistentData.Instance.getDifficulty();
        batPosition = new Vector2(bat.transform.position.x, bat.transform.position.y);
        Position();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        Movement();

    }

    private void Position()
    {
        if (level != 1 && difficulty == "Easy")
        {
            gameObject.GetComponent<Transform>().position = new Vector2(batPosition.x+2, batPosition.y);
        }
    }
    private void Movement()
    {

        if (level == 1 && difficulty == "Easy")
        {
            Destroy(gameObject);
        }

        if (level == 2 && difficulty == "Easy")
        {
            if (!upperBound)
            {
                rigid.velocity = new Vector2(0, 5.0f);
                if (transform.position.y >= 3.3)
                {
                    upperBound = true;
                }
            }
            else
            {
                rigid.velocity = new Vector2(0, -5.0f);
                if (transform.position.y <= -3.3)
                {
                    upperBound = false;
                }
            }
        }

        if (level == 3 && difficulty == "Easy")
        {
            if (!upperBound)
            {
                rigid.velocity = new Vector2(0, 7.5f);
                if (transform.position.y >= 3.3)
                {
                    upperBound = true;
                }
            }
            else
            {
                rigid.velocity = new Vector2(0, -7.5f);
                if (transform.position.y <= -3.3)
                {
                    upperBound = false;
                }
            }
        }

        if (level == 1 && difficulty == "Hard")
        {
            if (!upperBound)
            {
                rigid.velocity = new Vector2(0, 5.0f);
                if (transform.position.y >= 3.3)
                {
                    upperBound = true;
                }
            }
            else
            {
                rigid.velocity = new Vector2(0, -5.0f);
                if (transform.position.y <= -3.3)
                {
                    upperBound = false;
                }
            }

        }
        if (level == 2 && difficulty == "Hard")
        {
            if (!upperBound)
            {
                rigid.velocity = new Vector2(0, 7.5f);
                if (transform.position.y >= 3.3)
                {
                    upperBound = true;
                }
            }
            else
            {
                rigid.velocity = new Vector2(0, -7.5f);
                if (transform.position.y <= -3.3)
                {
                    upperBound = false;
                }
            }
        }
        if (level == 3 && difficulty == "Hard")
        {
            Vector3 topLeft = new Vector3(batPosition.x - 2, batPosition.y + 2, 0);
            Vector3 topRight = new Vector3(batPosition.x + 2, batPosition.y + 2, 0);
            Vector3 botLeft = new Vector3(batPosition.x - 2, batPosition.y - 2, 0);
            Vector3 botRight = new Vector3(batPosition.x + 2, batPosition.y - 2, 0);

            if (transform.position == topRight)
            {
                rigid.velocity = new Vector2(-5.0f, 0);
            }
            if (transform.position == topLeft)
            {
                rigid.velocity = new Vector2(0, -5.0f);
            }
            if (transform.position == botLeft)
            {
                rigid.velocity = new Vector2(5.0f, 0);
            }
            if (transform.position == botRight)
            {
                rigid.velocity = new Vector2(0, 5.0f);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            AudioSource.PlayClipAtPoint(deathSFX.clip, new Vector3(0, 0, 1));
            Debug.Log("You murdered a bird! Be careful!");
            Scorekeeper.Instance.ReducePoint(DEFAULT_POINTS);
            Destroy(gameObject);
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

}
