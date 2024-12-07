using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    const int NUM_GEMS = 3;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject eagle;
    [SerializeField] int level;
    [SerializeField] string difficulty;

    // Start is called before the first frame update
    void Start()
    {
        level = Scorekeeper.Instance.getLevel();
        difficulty = PersistentData.Instance.getDifficulty();
        SpawnGems();
        SpawnEagles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnGems()
    {
        int xMin = -2;
        int xMax = 10;
        int yMin = -3;
        int yMax = 2;
        for (int i = 0; i < NUM_GEMS; i++)
        {

            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(gem, position, Quaternion.identity);
        }
        //Instantiate(gem, new Vector2(9, 2), Quaternion.identity);
        //Instantiate(gem, new Vector2(0, 0), Quaternion.identity);
        //Instantiate(gem, new Vector2(9, -2), Quaternion.identity);
    }
    private void SpawnEagles()
    {

        if (level == 1 && difficulty == "Hard")
        {
            Vector2 position1 = new Vector2(bat.transform.position.x + 2, bat.transform.position.y);
            Instantiate(eagle, position1, new Quaternion(0, 180, 0, 0));
        }

            if (level == 2 && difficulty == "Hard")
        {
            Vector2 position1 = new Vector2(bat.transform.position.x + 1, bat.transform.position.y + 2);
            Instantiate(eagle, position1, new Quaternion(0, 180, 0, 0));
            Vector2 position2 = new Vector2(bat.transform.position.x + 1, bat.transform.position.y);
            Instantiate(eagle, position2, new Quaternion(0, 180, 0, 0));
            Vector2 position3 = new Vector2(bat.transform.position.x + 1, bat.transform.position.y - 2);
            Instantiate(eagle, position3, new Quaternion(0, 180, 0, 0));
        }
        if (level == 3 && difficulty == "Hard")
        {
            Vector2 position1 = new Vector2(bat.transform.position.x + 2, bat.transform.position.y + 2);
            Instantiate(eagle, position1, new Quaternion(0, 180, 0, 0));
            Vector2 position2 = new Vector2(bat.transform.position.x + 2, bat.transform.position.y - 2);
            Instantiate(eagle, position2, new Quaternion(0, 180, 0, 0));
            Vector2 position3 = new Vector2(bat.transform.position.x, bat.transform.position.y +0.5f);
            Instantiate(eagle, position3, new Quaternion(0, 180, 0, 0));
            Vector2 position4 = new Vector2(bat.transform.position.x, bat.transform.position.y - 0.5f);
            Instantiate(eagle, position4, new Quaternion(0, 180, 0, 0));
            Vector2 position5 = new Vector2(bat.transform.position.x - 2, bat.transform.position.y + 2);
            Instantiate(eagle, position5, new Quaternion(0, 180, 0, 0));
            Vector2 position6 = new Vector2(bat.transform.position.x +0.5f, bat.transform.position.y);
            Instantiate(eagle, position6, new Quaternion(0, 180, 0, 0));
            Vector2 position7 = new Vector2(bat.transform.position.x - 2, bat.transform.position.y - 2);
            Instantiate(eagle, position7, new Quaternion(0, 180, 0, 0));
            Vector2 position8 = new Vector2(bat.transform.position.x - 0.5f, bat.transform.position.y);
            Instantiate(eagle, position8, new Quaternion(0, 180, 0, 0));
        }
    }
}
