using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationCameraLook : MonoBehaviour {

    [SerializeField] private Camera gunCam;

    private float rotX;
    private float rotY;
    private Quaternion origRot;

    public float rotSpeed = 3.0f;
    public float maxRotX = 180f;
    public float minRotX = -180f;
    public float maxRotY = 90f;
    public float minRotY = 0f;

    
	// Use this for initialization
	void Start () {
        transform.localEulerAngles = new Vector3(0, 0, 0);
        origRot = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {

        if (gunCam.enabled)
        {

            rotY += Input.GetAxis("Mouse Y") * rotSpeed;
            rotX += Input.GetAxis("Mouse X") * rotSpeed;

            rotY = Mathf.Clamp(rotY, minRotY, maxRotY);
            rotX = Mathf.Clamp(rotX, minRotX, maxRotX);

            Quaternion newRot = new Quaternion();
            newRot.eulerAngles = new Vector3(origRot.x + rotY, origRot.y + rotX, 0);
            transform.localEulerAngles = newRot.eulerAngles;

            origRot = newRot;

        }

    }
}
