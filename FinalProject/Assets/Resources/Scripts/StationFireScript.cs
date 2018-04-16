using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StationFireScript : MonoBehaviour {
    private enum gunType { Bow, Flaregun, Blunder, AR, Sniper };
    [SerializeField] private gunType gunName;
    [SerializeField] private Transform bulletSpawnLocation;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private StationInteraction interact;
    [SerializeField] private AimerScript gun;

    //private string gunName;
    private int shotCount;
    private Rigidbody rb;
    private float Vi;

    void OnEnable()
    {
        initValues();
    }

    private void initValues()
    {
        switch (gunName)
        {
            case gunType.Bow:
                Vi = PlayerPrefs.GetFloat("CrossbowSpeed");
                break;
            case gunType.Flaregun:
                Vi = PlayerPrefs.GetFloat("FlaregunSpeed");
                break;
            case gunType.Blunder:
                Vi = PlayerPrefs.GetFloat("BlunderbussSpeed");
                break;
            case gunType.AR:
                Vi = PlayerPrefs.GetFloat("ArSpeed");
                break;
            case gunType.Sniper:
                Vi = PlayerPrefs.GetFloat("SniperSpeed");
                break;
            default:
                Debug.Log("No Vi found, default 50 is being used");
                Vi = 50f; 
                break;
        }
        shotCount = PlayerPrefs.GetInt("ShotCount");
    }

    // Update is called once per frame
    void Update () {
        if (interact.canfire())
        {
            gun.canAim = true;
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

        bullet.transform.position = bulletSpawnLocation.position;
        bullet.transform.rotation = bulletSpawnLocation.rotation;

        rb = bullet.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.velocity = bulletSpawnLocation.transform.forward * Vi;

        while (!collide)
        {
            collide = bullet.GetComponent<PlayerProjectileScript>().collide;

            yield return null;
        }
    }
}
