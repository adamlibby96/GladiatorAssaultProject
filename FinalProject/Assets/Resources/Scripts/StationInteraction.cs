using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationInteraction : MonoBehaviour
{

    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera gunCam;
    [SerializeField] private GameObject player;
    [SerializeField] private Canvas stationCanvas;

    private bool playerIn = false;
    private bool canWeaponFire = false;

    // Use this for initialization
    void Start()
    {
        mainCam.enabled = true;
        gunCam.enabled = false;
        stationCanvas.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerIn && Input.GetKeyDown(KeyCode.E))
        {
            mainCam.enabled = !mainCam.enabled;
            gunCam.enabled = !gunCam.enabled;
            canWeaponFire = gunCam.enabled;
            //Debug.Log(canWeaponFire + ": can weapon fire?");
            stationCanvas.enabled = gunCam.enabled;
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
        //Debug.Log("canfire: " + canWeaponFire);
        return canWeaponFire;
    }


}
