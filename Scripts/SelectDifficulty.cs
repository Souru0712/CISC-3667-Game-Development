using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button easyButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        Button hardButton = gameObject.transform.GetChild(1).GetComponent<Button>();

        easyButton.onClick.AddListener(LoadEasy);
        hardButton.onClick.AddListener(LoadHard);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadEasy()
    {
        PersistentData.Instance.setDifficulty("Easy");
        LoadGame();
    }

    public void LoadHard()
    {
        PersistentData.Instance.setDifficulty("Hard");
        LoadGame();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
