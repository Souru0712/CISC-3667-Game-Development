using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject target;
    [SerializeField] GameObject victim;
    [SerializeField] GameObject controller;
    [SerializeField] AudioSource throwSFX;
    [SerializeField] AudioSource deathSFX;


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
        if (deathSFX == null)
        {
            deathSFX = GetComponent<AudioSource>();
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
            AudioSource.PlayClipAtPoint(deathSFX.clip, new Vector3(0, 0, 1));
            if (collision.gameObject.transform.localScale.x < 4.0f)
            {
                Debug.Log("Small target. Nice Shot!");
                controller.GetComponent<Scorekeeper>().AddPoints(3);

            }
            else if (collision.gameObject.transform.localScale.x > 4.0f &&
                collision.gameObject.transform.localScale.x < 5.0f)
            {
                Debug.Log("Medium target. Could be faster.");
                controller.GetComponent<Scorekeeper>().AddPoints(2);
            }
            else
            {
                Debug.Log("Big target. Try harder next time.");
                controller.GetComponent<Scorekeeper>().AddPoints();
            }
            Destroy(gameObject);
            Destroy(target);
            if (SceneManager.GetActiveScene().buildIndex < 2)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        if (collision.gameObject.tag == "Victim")
        {
            AudioSource.PlayClipAtPoint(deathSFX.clip, new Vector3(0, 0, 1));
            Debug.Log("You murdered a bird! Be careful!");
            controller.GetComponent<Scorekeeper>().ReducePoint();
            Destroy(gameObject);
            Destroy(victim);
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
        if (gameObject != null)
        {
            controller.GetComponent<Shoot>().shot = false;
        }

    }
}
