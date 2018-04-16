using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour {
    [SerializeField] private Canvas sniperC;
    [SerializeField] private Canvas mainC;
	// Use this for initialization
	void Start () {
        sniperC.enabled = false;
        mainC.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
