using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station1FireWeapon : MonoBehaviour {
    [SerializeField] private Transform BulletSpawnLoc;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Station1InteractCamera interact;

    private GameObject bullet;
    private Rigidbody rb;

    public float Vi = 3f;
	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && interact.canfire())
        {
            bullet = Instantiate(bulletPrefab) as GameObject;
            bullet.transform.position = BulletSpawnLoc.position;
            bullet.transform.rotation = BulletSpawnLoc.rotation;

            rb = bullet.GetComponent<Rigidbody>();
            rb.useGravity = true;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

            rb.velocity = BulletSpawnLoc.transform.forward * Vi;
        }
	}
}
