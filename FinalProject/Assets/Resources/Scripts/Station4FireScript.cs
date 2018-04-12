using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station4FireScript : MonoBehaviour {
    [SerializeField] private Transform BulletSpawnLoc;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private StationInteraction interact;
    [SerializeField] private ARAimer arAimer;

    private int shotCount = 10;


    private Rigidbody rb;

    public float Vi = 40f;


    // Update is called once per frame
    void Update()
    {

        if (interact.canfire())
        {
            arAimer.canAim = true;
            if (Input.GetMouseButtonDown(0))
            {
                if (shotCount > 0)
                {
                    StartCoroutine(shootBullet());
                    shotCount--;
                }
            }
        }
    }



    private IEnumerator shootBullet()
    {
        GameObject bullet;
        bool collide = false;
        bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.GetComponent<TrailRenderer>().Clear();
        bullet.transform.position = BulletSpawnLoc.position;
        bullet.transform.rotation = BulletSpawnLoc.rotation;
        
        rb = bullet.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.velocity = BulletSpawnLoc.transform.forward * Vi;

        while (!collide)
        {
            collide = bullet.GetComponent<PlayerProjectileScript>().collide;
            yield return null;
            //bullet.transform.GetComponent<TrailRenderer>().enabled = true;
        }
    }
}
