using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ResetHighScores : MonoBehaviour
{
    [SerializeField] Button resetButton;

    [SerializeField] const int NUM_HIGH_SCORES = 5;
    [SerializeField] const string NAME_KEY = "HighScoreName";
    [SerializeField] const string SCORE_KEY = "HighScore";

    [SerializeField] string difficulty;

    // Start is called before the first frame update
    void Start()
    {
        if (resetButton == null)
        {
            resetButton = GetComponent<Button>();
        }
        difficulty = PersistentData.Instance.getDifficulty();
        resetButton.onClick.AddListener(ResetScores);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetScores()
    {
        PlayerPrefs.DeleteAll();
    }

}
