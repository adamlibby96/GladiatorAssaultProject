using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverMenuScript : MonoBehaviour {
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject loadingScreenCanvas;
    [SerializeField] private Slider loadBar;
    [SerializeField] private TextMeshProUGUI loadTextPercentage;
    [SerializeField] private TextMeshProUGUI timeTxt;
    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        gameOverCanvas.SetActive(true);
        loadingScreenCanvas.SetActive(false);
        if (PlayerPrefs.HasKey("Fastest Time"))
        {
            timeTxt.text = "Fastest Time: " + PlayerPrefs.GetFloat("Fastest Time");
        } else
        {
            timeTxt.enabled = false;
        }
        
    }


    public void GoToMainMenu(string name)
    {
        gameOverCanvas.SetActive(false);
        loadingScreenCanvas.SetActive(true);
        StartCoroutine(loadMainMenu(name));
    }

    public IEnumerator loadMainMenu(string name)
    {
        AsyncOperation loader = SceneManager.LoadSceneAsync(name);
        while (!loader.isDone)
        {
            loadBar.value = loader.progress / 0.9f;
            loadTextPercentage.text = loadBar.value * 100.0f + "%";
            yield return null;
        }
    }

    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
