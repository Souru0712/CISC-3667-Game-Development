using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    const float DEFAULT_POINTS = 3000;

    // Start is called before the first frame update
    void Start()
    {
        if (audio == null)
            audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //what should happen on collision?
        //1. score should increase
        //2. sound effect should play
        //3. coin should be removed from the scene

        if (collision.gameObject.tag == "GameController")
        {
            Debug.Log("A gem was collected.");
            Scorekeeper.Instance.AddPoints(3000);
            AudioSource.PlayClipAtPoint(audio.clip, new Vector3(0,0,1));
            //audio.play(); -- this is simpler but won't work if coin
            //gets destroyed before clip plays
            Destroy(gameObject);
            //Destroy(gameObject, 1); //takes an optional second parameter for number of seconds before the destroying
        }
       


    }
}
