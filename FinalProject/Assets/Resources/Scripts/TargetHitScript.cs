using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitScript : MonoBehaviour {

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerProjectileScript>())
        {
            Messenger.Broadcast(GameEvent.GAME_WIN);
        }
    }

    
}
