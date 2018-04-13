using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactSwitch : MonoBehaviour {

    public bool canActivate { get; private set; }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            canActivate = true;
        }
    }
}
