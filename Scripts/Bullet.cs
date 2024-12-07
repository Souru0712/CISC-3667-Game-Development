using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject controller;
    [SerializeField] AudioSource throwSFX;

    const float DEFAULT_POINTS = 10000;

    // Start is called before the first frame update
    void Start()
    {

        if (projectile == null)
        {
            projectile = GameObject.FindGameObjectWithTag("Projectile");
        }
        if (throwSFX == null)
        {
            throwSFX = GetComponent<AudioSource>();
        }
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AudioSource.PlayClipAtPoint(throwSFX.clip, new Vector3(0,0,1));
        if (collision.gameObject.tag == "Target")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Victim")
        {
            Destroy(gameObject);
        }
    }

    public void Fire()
    {
        if (controller.GetComponent<Movement>().isFacingRight == true)
        {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        } else {
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
            Destroy(gameObject, 2.5f);
    }
    private void OnDestroy()
    {
        controller.GetComponent<Shoot>().shot = false;

    }
}
