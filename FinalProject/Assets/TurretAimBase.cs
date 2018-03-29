using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAimBase : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private BallLauncher launcher;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (launcher.landLocation() == Vector3.zero)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.LookAt(launcher.landLocation());
        }
    }

}
