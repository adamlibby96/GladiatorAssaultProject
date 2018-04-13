using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using System;

public class MainMenuScript : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject optionsMenuCanvas;
    [SerializeField] private GameObject loadingScreenCanvas;
    [SerializeField] private Slider loadBar;
    [SerializeField] private Slider mouseSensitivity;
    [SerializeField] private TextMeshProUGUI loadTextPercentage;
    [SerializeField] private TextMeshProUGUI mouseSensitivityText;

    private void Start()
    {
        mainMenuCanvas.SetActive(true);
        optionsMenuCanvas.SetActive(false);
        loadingScreenCanvas.SetActive(false);
        mouseSensitivity.value = PlayerPrefs.GetFloat("Mouse Speed");
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

    public void SetMouseSpeed(float speed)
    {
        mouseSensitivityText.text = "Mouse Speed: " + Math.Round(speed, 2);
        PlayerPrefs.SetFloat("Mouse Speed", speed);
    }


    public void SetGameDifficulty(int val)
    {
        Debug.Log(val);
        PlayerPrefs.SetFloat("Difficulty", val);
    }

    public void ResetFastestTime()
    {
        PlayerPrefs.DeleteKey("Fastest Time");
    }

}
