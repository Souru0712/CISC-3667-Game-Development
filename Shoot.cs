using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] bool fire = false;
    [SerializeField] public bool shot = false;



    // Start is called before the first frame update
    void Start()
    {
        if (bullet != null)
        {
            bullet = GameObject.FindGameObjectWithTag("Projectile");
        }
    }

    // Update is called once per frame
    void Update()
    {
        fire = Input.GetButton("Fire1");

    }

    //1. hit fire
    //2. a projectile is launched horizontally from the player's spot
    //3. destroy condition

    private void FixedUpdate() { 
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        if (fire && !shot)
        {
            shot = true;
            GameObject rock = Instantiate(bullet, position, Quaternion.identity);
            rock.GetComponent<Bullet>().Fire();
        }

    }

    
}
