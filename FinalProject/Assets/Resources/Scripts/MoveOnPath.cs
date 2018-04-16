using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {
    public GenPathForGunSway pathtoFollow;
    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    //public float rotationSpeed = 5.0f;
    //public string pathName;

   // Vector3 firstPostion;
    //Vector3 lastPosition;
    //Vector3 currentPosition;

	// Use this for initialization
	void Start ()
    {
        reachDistance = Vector3.Distance(this.gameObject.transform.position, pathtoFollow.gameObject.transform.position);
       // firstPostion = transform.position;
        //lastPosition = transform.position;
        //pathtoFollow = GameObject.Find(pathName).GetComponent<GenPathForGunSway>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(pathtoFollow.path_objects[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, pathtoFollow.path_objects[CurrentWayPointID].position, Time.deltaTime * speed);

        if (distance <= reachDistance)
        {
            CurrentWayPointID++;
        }

        if (CurrentWayPointID >= pathtoFollow.path_objects.Count)
        {
            CurrentWayPointID = 0;
        }
	}
}
