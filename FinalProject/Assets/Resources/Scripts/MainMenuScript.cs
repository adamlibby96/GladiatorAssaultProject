using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject optionsMenuCanvas;
    [SerializeField] private GameObject loadingScreenCanvas;
    [SerializeField] private Slider loadBar;
    [SerializeField] private TextMeshProUGUI loadTextPercentage;

    private void Start()
    {
        mainMenuCanvas.SetActive(true);
        optionsMenuCanvas.SetActive(false);
        loadingScreenCanvas.SetActive(false);
    }


    public void StartGame(string name)
    {
        mainMenuCanvas.SetActive(false);
        loadingScreenCanvas.SetActive(true);
        StartCoroutine(loadtheGame(name));
    }

    public IEnumerator loadtheGame(string name)
    {
        AsyncOperation loader = SceneManager.LoadSceneAsync(name);
        while (!loader.isDone)
        {
            loadBar.value = loader.progress / 0.9f;
            loadTextPercentage.text = loadBar.value * 100.0f + "%";
            yield return null;
        }
    }

    public void OptionsMenu()
    {
        mainMenuCanvas.SetActive(false);
        optionsMenuCanvas.SetActive(true);
    }

    public void goBack()
    {
        mainMenuCanvas.SetActive(true);
        optionsMenuCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


}
