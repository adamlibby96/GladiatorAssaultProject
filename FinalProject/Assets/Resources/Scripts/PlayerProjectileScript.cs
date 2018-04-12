using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileScript : MonoBehaviour {

    public bool collide { get; private set; }



	// Use this for initialization
	void Start () {
        collide = false;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (!collide)
        {
            transform.LookAt(transform.position + transform.GetComponent<Rigidbody>().velocity);
        }

       
        //transform.forward = Vector3.Slerp(transform.forward, transform.GetComponent<Rigidbody>().velocity.normalized, Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        collide = true;
        
        if (collision.gameObject.name == "TargetSpot")
        {
            Debug.Log("Won!");
        }

        transform.GetComponent<Rigidbody>().isKinematic = true;
        transform.GetComponent<Rigidbody>().useGravity = false; 
    }
}
