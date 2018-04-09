using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station1FireWeapon : MonoBehaviour {
    [SerializeField] private Transform BulletSpawnLoc;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private StationInteraction interact;
    [SerializeField] private BowAimer bow;

    private int shotCount = 10;

   
    private Rigidbody rb;

    public float Vi = 40f;


    // Update is called once per frame
    void Update () {

        if (interact.canfire())
        {
            bow.canAim = true;
            if (Input.GetMouseButtonDown(0))
            {
                if (shotCount > 0)
                {
                    StartCoroutine(shootArrow());
                    shotCount--;
                }
            }
        }
	}



    private IEnumerator shootArrow()
    {
        GameObject bullet;
        bool collide = false;
        bullet = Instantiate(bulletPrefab) as GameObject;

        bullet.transform.position = BulletSpawnLoc.position;
        bullet.transform.rotation = BulletSpawnLoc.rotation;

        rb = bullet.GetComponent<Rigidbody>();
        rb.useGravity = true;
        // rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        rb.velocity = BulletSpawnLoc.transform.forward * Vi;

        while (!collide)
        {
            //bullet.transform.forward = Vector3.Slerp(bullet.transform.forward, rb.velocity.normalized, Time.deltaTime);
            collide = bullet.GetComponent<PlayerProjectileScript>().collide;

            yield return null;
        }
    }
}
