using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationInteraction : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera gunCam;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject restingGun;
    [SerializeField] private GameObject shootingGun;
    private bool playerIn = false;
    private bool canWeaponFire = false;

    // Use this for initialization
    void Start()
    {
        shootingGun.SetActive(false);
        restingGun.SetActive(true);
        mainCam.enabled = true;
        gunCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn && Input.GetKeyDown(KeyCode.E))
        {
            shootingGun.SetActive(!shootingGun.activeSelf);
            restingGun.SetActive(!restingGun.activeSelf);
            mainCam.enabled = !mainCam.enabled;
            gunCam.enabled = !gunCam.enabled;
            canWeaponFire = gunCam.enabled;
            player.gameObject.SetActive(mainCam.enabled);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerIn = false;
        }
    }

    public bool canfire()
    {
        return canWeaponFire;
    }


}
