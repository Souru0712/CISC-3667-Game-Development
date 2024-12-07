using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//using UnityEngine.UIElements;
using UnityEngine.EventSystems;
public class BackButton : MonoBehaviour
{

    void Start()
    {
        Button backButton = gameObject.GetComponent<Button>();

        backButton.onClick.AddListener(LoadMenu);

    }

    public void LoadMenu()
    {
        Debug.Log("You went back to the menu!");
        PersistentData.Instance.setName("");
        PersistentData.Instance.setScore(0);
        Scorekeeper.Instance.setScore(0);
        Scorekeeper.Instance.setLevel(1);
        SceneManager.LoadScene("MainMenu");
    }
}