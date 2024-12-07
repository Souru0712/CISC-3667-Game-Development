using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button highScoresButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        highScoresButton.onClick.AddListener(LoadHighScores);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadHighScores()
    {
        SceneManager.LoadScene("HighScores");
    }
}
