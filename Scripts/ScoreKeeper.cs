using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Unity.VisualScripting;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] public int score = 0;
    [SerializeField] public int level;
    const int DEFAULT_POINTS = 1;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI levelText;

    public static Scorekeeper Instance;

    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

    }

    void Start()
    {
        name = PersistentData.Instance.getName();
        score = PersistentData.Instance.getScore();
        level = SceneManager.GetActiveScene().buildIndex+1;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DisplayName();
        DisplayScore();
        DisplayLevel();

    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log("score: " + score);
    }
    public void ReducePoint()
    {
        ReducePoint(DEFAULT_POINTS);
    }
    public void ReducePoint(int points)
    {
        score -= points;
        Debug.Log("score: " + score);
    }

    private void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void DisplayLevel()
    {
        levelText.text = "Level: " + level; 
    }
    private void DisplayName()
    {
        nameText.text = "Name: " + PersistentData.Instance.getName();
    }

    public void PlayNextLevel()
    {
        level += 1;
        PersistentData.Instance.setScore(score);
        SceneManager.LoadScene(level);
    }

    public void ReloadLevel()
    {
        score = PersistentData.Instance.getScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int getLevel()
    {
        return level;
    }

    public void setScore(int s)
    {
        score = s;
    }

    public void setLevel(int l)
    {
        level = l;
    }
}
