using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationFireWeapon : MonoBehaviour {
    [SerializeField] private Transform BulletSpawnLoc;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private StationInteraction interact;

    private int shotCount = 2;

    private GameObject bullet;
    //private Rigidbody rb;

    //public float Vi = 3f;

	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("calling??");
		if (Input.GetMouseButtonDown(0) && interact.canfire() )
        {
            Debug.Log("fire");
            if (shotCount > 0)
            {
                bullet = Instantiate(bulletPrefab) as GameObject;
                Debug.Log(bullet.ToString());
                bullet.transform.position = BulletSpawnLoc.position;
                bullet.transform.rotation = BulletSpawnLoc.rotation;
                bullet.GetComponent<Bullet>().setSpeed(50f);
                bullet.GetComponent<Bullet>().fire();
                shotCount--;
            }

            // rb = bullet.GetComponent<Rigidbody>();
            // rb.useGravity = true;
            // rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            // rb.velocity = BulletSpawnLoc.transform.forward * Vi;
        }
	}
}
