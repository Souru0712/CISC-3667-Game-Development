using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    //[SerializeField] bool isFacingRight = true;
    //[SerializeField] bool rightBound = false;
    [SerializeField] bool upperBound = false;

    [SerializeField] int level;
    [SerializeField] string difficulty;

    const float DEFAULT_POINTS = 10000;
    [SerializeField] AudioSource deathSFX;
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
        InvokeRepeating("GrowObject", 0.8f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        Movement();
        SelfDestroy();
    }
    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
    private void Movement()
    {
        if (level == 1 && difficulty == "Easy")
        {
            rigid.velocity = Vector2.zero;
        }
        if (level == 2 && difficulty == "Easy")
        {
            rigid.velocity = Vector2.zero;
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
                rigid.velocity = new Vector2(0, -7.5f);
                if (transform.position.y <= -3.3)
                {
                    upperBound = true;
                }
            }
            else
            {
                rigid.velocity = new Vector2(0, 7.5f);
                if (transform.position.y >= 3.3)
                {
                    upperBound = false;
                }
            }
        }
        if (level == 2 && difficulty == "Hard")
        {

        }
        if (level == 3 && difficulty == "Hard")
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            AudioSource.PlayClipAtPoint(deathSFX.clip, new Vector3(0,0,1));
            Destroy(gameObject);
            float size = gameObject.transform.localScale.x; //or y
            Scorekeeper.Instance.AddPoints(Mathf.RoundToInt(DEFAULT_POINTS / size));
            Scorekeeper.Instance.PlayNextLevel();
        }
    }
    private void GrowObject()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0);

    }
    void SelfDestroy()
    {
        if(transform.localScale.x > 8.0f)
        {
            Debug.Log("Target exploded.");
            AudioSource.PlayClipAtPoint(deathSFX.clip, new Vector3(0,0,1));
            Scorekeeper.Instance.ReloadLevel();
        }
    }
}
