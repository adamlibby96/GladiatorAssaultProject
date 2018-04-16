using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDropScript : MonoBehaviour {
    private Vector3 origPosition;

    void Awake()
    {
        Messenger.AddListener(GameEvent.GAME_START, dropTheDoor);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.GAME_START, dropTheDoor);
    }

    private void dropTheDoor()
    {
        StartCoroutine(drop());
    }

    private IEnumerator drop()
    {
        float elapsed = 0;
        float duration = 0.5f;

        while (elapsed <= duration)
        {
            float pct = elapsed / duration;
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, -30, 45), pct);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = origPosition;
        this.gameObject.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        Messenger.AddListener(GameEvent.GAME_START, dropTheDoor);
        origPosition = transform.position;
	}
}
