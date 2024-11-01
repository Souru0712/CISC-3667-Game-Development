using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    const int NUM_GEMS = 3;
    [SerializeField] GameObject gem;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        Instantiate(gem, new Vector2(9, 2), Quaternion.identity);
        Instantiate(gem, new Vector2(0, 0), Quaternion.identity);
        Instantiate(gem, new Vector2(9, -2), Quaternion.identity);

    }
}
