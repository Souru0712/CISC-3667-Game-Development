using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PersistentData : MonoBehaviour
{
    [SerializeField] string playerName;
    [SerializeField] int playerScore;
    [SerializeField] string difficulty;

    public static PersistentData Instance;

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
    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

 

    public void setScore(int s)
    {
        playerScore = s;
    }

    public void setName(string n)
    {
        playerName = n;
    }

    public void setDifficulty(string d)
    {
        difficulty = d;
    }

    public string getName()
    {
        return playerName;
    }

    public int getScore()
    {
        return playerScore;
    }

    public string getDifficulty()
    {
        return difficulty;
    }

}
