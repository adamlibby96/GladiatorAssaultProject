using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Messenger.Broadcast(GameEvent.GAME_OVER);
        }
        StartCoroutine(killMe());
    }

    private IEnumerator killMe()
    {
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }
}
