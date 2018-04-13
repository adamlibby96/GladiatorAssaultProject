using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameSwitch : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject interactArea;
    [SerializeField] private GameObject switchObj;

   // private Vector3 switchPos;

    private bool activated = false;

    void Start()
    {
     //   switchPos = transform.position;
        
    }

    // Update is called once per frame
    void Update ()
    {   
        if (interactArea.GetComponent<interactSwitch>().canActivate)
        {
            if (Input.GetKeyDown(KeyCode.E) && !activated)
            {
                StartCoroutine(activateSwitch());
            }
        }
	}

    private IEnumerator activateSwitch()
    {
        activated = true;

        float elapsed = 0f;
        float duration = 1f;
        //Vector3 newPos = new Vector3(switchPos.x, 0.15f, switchPos.z);
        while (elapsed < duration)
        {
            float pct = elapsed / duration;
            switchObj.transform.rotation = Quaternion.Slerp(switchObj.transform.rotation, new Quaternion(-60f, switchObj.transform.rotation.y, switchObj.transform.rotation.z, switchObj.transform.rotation.w), pct);
            //switchObj.transform.position = Vector3.Lerp(switchObj.transform.position, newPos, pct);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Messenger.Broadcast(GameEvent.GAME_INIT);
    }
}
