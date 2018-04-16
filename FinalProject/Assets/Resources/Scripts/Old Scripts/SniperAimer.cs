using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAimer : MonoBehaviour {
    [SerializeField] private Camera gunCam;
    [SerializeField] private Canvas sniperCanvas;
    [SerializeField] private Transform origPos;
    [SerializeField] private Transform aimPos;
    [SerializeField] private float duration = 1f;
    [SerializeField] private float cameraZoom = 15f;
    public bool canAim { get; set; }
    private bool isAim = false;
    private bool aiming = false;
    private float origZoom;
    
    private void Start()
    {
        origZoom = gunCam.fieldOfView;
        sniperCanvas.enabled = false; 
        transform.position = origPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAim)
        {
            if (Input.GetMouseButtonDown(1) && !aiming)
            {
                if (!isAim)
                {
                    StartCoroutine(sniperAimer(duration));
                }
                else
                {
                    gunCam.fieldOfView = origZoom;
                    gameObject.GetComponent<MeshRenderer>().enabled = true;
                    sniperCanvas.enabled = false;
                    StartCoroutine(sniperAimer(duration));
                }
            }
        }


    }

    private IEnumerator sniperAimer(float dur)
    {
        aiming = true;
        float elapsed = 0f;
        while (elapsed <= dur)
        {
            float pct = elapsed / dur;
            if (isAim)
            {
                transform.position = Vector3.Lerp(aimPos.position, origPos.position, pct);
            }
            else
            {
                transform.position = Vector3.Lerp(origPos.position, aimPos.position, pct);
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        if (isAim)
        {
            transform.position = origPos.position;
        }
        else
        {
            transform.position = aimPos.position;
            gunCam.fieldOfView = cameraZoom;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            sniperCanvas.enabled = true;
        }

        isAim = !isAim;
        aiming = false;
    }
}
