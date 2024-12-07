using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using TMPro;
public class MenuButton : MonoBehaviour
{
    [SerializeField] TMP_InputField PlayerName;
    GameObject[] MenuMode;
    GameObject[] DifficultyMode;
    void Start()
    {
        Button playButton = gameObject.transform.GetChild(0).GetComponent<Button>();
        Button instructionButton = gameObject.transform.GetChild(1).GetComponent<Button>();
        Button optionsButton = gameObject.transform.GetChild(2).GetComponent<Button>();

        playButton.onClick.AddListener(LoadDifficulty);
        instructionButton.onClick.AddListener(LoadInstructions);
        optionsButton.onClick.AddListener(LoadOptions);

        MenuMode = GameObject.FindGameObjectsWithTag("MainMenu");
        DifficultyMode = GameObject.FindGameObjectsWithTag("Difficulty");

        foreach (GameObject g in DifficultyMode)
            g.SetActive(false);
    }

    private void Update()
    {
        
    }
    public void LoadDifficulty()
    {
        string s = PlayerName.text;
        PersistentData.Instance.setName(s);
        foreach (GameObject g in DifficultyMode)
            g.SetActive(true);

        foreach (GameObject g in MenuMode)
            g.SetActive(false);
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

}