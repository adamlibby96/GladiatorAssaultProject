using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitGame : MonoBehaviour {
    [SerializeField] private Text countDownTXT;
    [SerializeField] private int DefaultShotCount = 2;
    [Space(5)]
    [Header("Gun Speeds")]
    [SerializeField] private float crossbowSpeed = 60f;
    [SerializeField] private float flaregunSpeed = 50f;
    [SerializeField] private float blunderbussSpeed = 40f;
    [SerializeField] private float arSpeed = 60f;
    [SerializeField] private float sniperSpeed = 100f;
    [SerializeField] private float cannonFireRate = 0.8f;
    [SerializeField] private float totalTime = 90f;
    [Space(5)]
    [Header("Easy Difficulty Variable Adjustments")]
    [SerializeField] private int easyDifficultyShotCount = 4;
    [SerializeField] private float easyDifficultySpeedMultiplier = 1.2f;
    [SerializeField] private float easyDifficultyTimeMultiplier = 1.5f;
    [SerializeField] private float easyDifficultyCannonFireRateMultiplier = 1.25f;
    [Space(5)]
    [Header("Hard Difficulty Variable Adjustments")]
    [SerializeField] private int hardDifficultyShotCount = 1;
    [SerializeField] private float hardDifficultySpeedMultiplier = 0.8f;
    [SerializeField] private float hardDifficultyTimeMultiplier = 0.667f;
    [SerializeField] private float hardDifficultyCannonFireRateMultiplier = 0.625f;

    private int gameDifficulty;

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
                PlayerPrefs.SetFloat("CrossbowSpeed", crossbowSpeed);
                PlayerPrefs.SetFloat("FlaregunSpeed", flaregunSpeed);
                PlayerPrefs.SetFloat("BlunderbussSpeed", blunderbussSpeed);
                PlayerPrefs.SetFloat("ArSpeed", arSpeed);
                PlayerPrefs.SetFloat("SniperSpeed", sniperSpeed);
                PlayerPrefs.SetFloat("CannonFireRate", cannonFireRate);
                PlayerPrefs.SetFloat("TotalGameTime", totalTime);
                PlayerPrefs.SetInt("ShotCount", DefaultShotCount);
                break;
            case 1:
                // easy difficulty
                Debug.Log("Easy Difficulty");
                PlayerPrefs.SetFloat("CrossbowSpeed", crossbowSpeed * easyDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("FlaregunSpeed", flaregunSpeed * easyDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("BlunderbussSpeed", blunderbussSpeed * easyDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("ArSpeed", arSpeed * easyDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("SniperSpeed", sniperSpeed * easyDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("CannonFireRate", cannonFireRate * easyDifficultyCannonFireRateMultiplier);
                PlayerPrefs.SetFloat("TotalGameTime", totalTime * easyDifficultyTimeMultiplier);
                PlayerPrefs.SetInt("ShotCount", easyDifficultyShotCount);
                break;
            case 2:
                // hard difficulty
                Debug.Log("Hard Difficulty");
                PlayerPrefs.SetFloat("CrossbowSpeed", crossbowSpeed * hardDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("FlaregunSpeed", flaregunSpeed * hardDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("BlunderbussSpeed", blunderbussSpeed * hardDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("ArSpeed", arSpeed * hardDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("SniperSpeed", sniperSpeed * hardDifficultySpeedMultiplier);
                PlayerPrefs.SetFloat("CannonFireRate", cannonFireRate * hardDifficultyCannonFireRateMultiplier);
                PlayerPrefs.SetFloat("TotalGameTime", totalTime * hardDifficultyTimeMultiplier);
                PlayerPrefs.SetInt("ShotCount", hardDifficultyShotCount);
                break;
            default:
                // normal difficulty
                Debug.Log("Default Difficulty");
                PlayerPrefs.SetFloat("CrossbowSpeed", crossbowSpeed);
                PlayerPrefs.SetFloat("FlaregunSpeed", flaregunSpeed);
                PlayerPrefs.SetFloat("BlunderbussSpeed", blunderbussSpeed);
                PlayerPrefs.SetFloat("ArSpeed", arSpeed);
                PlayerPrefs.SetFloat("SniperSpeed", sniperSpeed);
                PlayerPrefs.SetFloat("CannonFireRate", cannonFireRate);
                PlayerPrefs.SetFloat("TotalGameTime", totalTime);
                PlayerPrefs.SetInt("ShotCount", DefaultShotCount);
                break;
        }
        //Messenger.Broadcast(GameEvent.INIT_GUN_SPEEDS);
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
