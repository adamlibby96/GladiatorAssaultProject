using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour {
    [SerializeField] private Text timerTXT;
    private bool gameOver = false;
    private float timerVal = 60f;
    private float originalTime = 60f;

    //void Awake()
    //{
    //    Messenger.AddListener(GameEvent.GAME_START, startTimer);
    //    Messenger.AddListener(GameEvent.GAME_WIN, saveTime);
    //    Messenger.AddListener(GameEvent.GAME_OVER, stopTimer);
    //}

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_START, startTimer);
        Messenger.RemoveListener(GameEvent.GAME_WIN, saveTime);
        Messenger.RemoveListener(GameEvent.GAME_OVER, stopTimer);
    }

    private void stopTimer()
    {
        gameOver = true;
        StopCoroutine(timer());
        StartCoroutine(loadGameOverScreen());
    }

    private void saveTime()
    {
        gameOver = true;
        StopCoroutine(timer());
        if (!PlayerPrefs.HasKey("Fastest Time"))
        {
            PlayerPrefs.SetFloat("Fastest Time", originalTime - timerVal);
        }
        else
        {
            float temp = PlayerPrefs.GetFloat("Fastest Time");
            if (timerVal < temp)
            {
                PlayerPrefs.SetFloat("Fastest Time", originalTime - timerVal);
            }
        }

        StartCoroutine(loadGameOverScreen());
    }

    public IEnumerator loadGameOverScreen()
    {
        yield return new WaitForSeconds(0.5f);

        AsyncOperation loader = SceneManager.LoadSceneAsync("GameOverScene");
        while (!loader.isDone)
        {
            Debug.Log("Game Over!");
            yield return null;
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void startTimer()
    {
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        while (timerVal >= 0 && !gameOver)
        {
            timerTXT.text = "Time: " + Mathf.Round(timerVal);
            timerVal -= Time.deltaTime;
            yield return null;
        }
        Messenger.Broadcast(GameEvent.GAME_OVER);
    }

    // Use this for initialization
    void Start () {
        Messenger.AddListener(GameEvent.GAME_START, startTimer);
        Messenger.AddListener(GameEvent.GAME_WIN, saveTime);
        Messenger.AddListener(GameEvent.GAME_OVER, stopTimer);


        if (PlayerPrefs.HasKey("Time"))
        {
            timerVal = PlayerPrefs.GetFloat("Time");
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver)
        {
           // Time.timeScale = 0.2f;
        }
	}
}
