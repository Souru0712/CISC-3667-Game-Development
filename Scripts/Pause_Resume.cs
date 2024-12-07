using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause_Resume : MonoBehaviour
{

    [SerializeField] Button resume;
    [SerializeField] Button home;
    GameObject[] pauseMode;
    GameObject[] playMode;

    // Start is called before the first frame update
    void Start()
    {          
        Time.timeScale = 1.0f;
        pauseMode = GameObject.FindGameObjectsWithTag("PauseItems");
        playMode = GameObject.FindGameObjectsWithTag("PlayItems");

        if(resume == null) resume = gameObject.transform.GetChild(1).GetChild(0).GetComponent<Button>();
        if(home == null) home = gameObject.transform.GetChild(1).GetChild(1).GetComponent<Button>();

        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        resume.onClick.AddListener(Resume);
        home.onClick.AddListener(LoadMenu);


        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Pause();
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        PersistentData.Instance.setName("");
        PersistentData.Instance.setScore(0);
        Scorekeeper.Instance.setScore(0);
        Scorekeeper.Instance.setLevel(1);
        AudioSource music = Bgmusic.instance.GetComponent<AudioSource>();

        music.Play();
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;

        foreach (GameObject g in pauseMode)
            g.SetActive(true);

        foreach (GameObject g in playMode)
            g.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;

        foreach (GameObject g in pauseMode)
            g.SetActive(false);

        foreach (GameObject g in playMode)
            g.SetActive(true);

    }
}
