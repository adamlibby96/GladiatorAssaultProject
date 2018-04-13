using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour {
    [SerializeField] private Text countDownTXT;

    private int gameDifficulty;

    void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_INIT, beginInitGame);        
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_INIT, beginInitGame);
    }

    private void beginInitGame()
    {
        switch (gameDifficulty)
        {
            case 0:
                // normal difficulty
                Debug.Log("Normal Difficulty");
                break;
            case 1:
                // easy difficulty
                Debug.Log("Easy Difficulty");
                break;
            case 2:
                // hard difficulty
                Debug.Log("Hard Difficulty");
                break;
            default:
                // normal difficulty
                Debug.Log("Default Difficulty");
                break;
        }

        StartCoroutine(startCounter());

    }

    private IEnumerator startCounter()
    {
        countDownTXT.enabled = true;
        float counter = 3f;
        while (counter >= 0)
        {
            countDownTXT.text = Mathf.Round(counter).ToString();
            counter -= Time.deltaTime;
            yield return null;
        }
        countDownTXT.text = "GO!";
        yield return new WaitForSeconds(1);
        countDownTXT.enabled = false;
        Messenger.Broadcast(GameEvent.GAME_START);
    }

    // Use this for initialization
    void Start () {
        Messenger.AddListener(GameEvent.GAME_INIT, beginInitGame);

        gameDifficulty = PlayerPrefs.GetInt("Difficulty");
        countDownTXT.enabled = false;
	}
}
