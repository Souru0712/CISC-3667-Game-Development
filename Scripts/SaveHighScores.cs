using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SaveHighScores : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] topNames;
    [SerializeField] TextMeshProUGUI[] topScores;

    [SerializeField] const int NUM_HIGH_SCORES = 5;
    [SerializeField] const string NAME_KEY = "HighScoreName";
    [SerializeField] const string SCORE_KEY = "HighScore";

    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] string difficulty;

    public static SaveHighScores Instance;

    // Start is called before the first frame update
    void Start()
    {
        playerName = PersistentData.Instance.getName();
        playerScore = PersistentData.Instance.getScore();
        difficulty = PersistentData.Instance.getDifficulty();
        
        if(playerName == "")
        {
            playerName = "Nameless";
        }
        SaveScores();
        DisplayHighScores();
    }



    // Update is called once per frame
    void Update()
    {

    }
    private void SaveScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            string nameKey = NAME_KEY+i;
            string scoreKey = SCORE_KEY+i;

            if (PlayerPrefs.HasKey(scoreKey))
            {
                int highScore = PlayerPrefs.GetInt(scoreKey);

                if (playerScore >= highScore)
                {
                    int tempScore = highScore;
                    PlayerPrefs.SetInt(scoreKey, playerScore);
                    playerScore = tempScore; //swap current with top

                    string tempName = PlayerPrefs.GetString(nameKey);
                    PlayerPrefs.SetString(nameKey, playerName);
                    playerName = tempName; //swap current name with top
                }
            }//previous HighScore is now player, which will check for the rest of the tops
            else
            {
                PlayerPrefs.SetString(nameKey, playerName );
                PlayerPrefs.SetInt(scoreKey, playerScore);
                return;
            }
            
        }
    }

    public void DisplayHighScores()
    {
        for (int i = 0; i < NUM_HIGH_SCORES; i++)
        {
            topNames[i].text = PlayerPrefs.GetString(NAME_KEY + i);
            topScores[i].text = PlayerPrefs.GetInt(SCORE_KEY + i).ToString();
        }
    }
}