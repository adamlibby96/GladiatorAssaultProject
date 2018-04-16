using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimerScript : MonoBehaviour {
    [SerializeField] private Transform origPos;
    [SerializeField] private Transform aimPos;
    [SerializeField] private float duration = 1f;
    [Space(5)]
    [Header("Sniper Object")]
    [SerializeField] private bool isSniper = false; // default value is false
    [SerializeField] private Camera sniperCamera;
    [SerializeField] private Canvas sniperCanvas;
    [SerializeField] private float cameraZoom;
    [SerializeField] private float originalZoom;
    

    public bool canAim { get; set; }
    private bool isAim = false;
    private bool aiming = false;


    void Start()
    {
        transform.position = origPos.position;

        if (isSniper)
        {
            sniperCanvas.enabled = false;
        }
    }

    // Update is called once per frame
    void Update () {
        if (canAim)
        {
            if (Input.GetMouseButtonDown(1) && !aiming)
            {
                if (!isAim)
                {
                    StartCoroutine(aimGun(duration));
                }
                else
                {
                    if (isSniper)
                    {
                        sniperCamera.fieldOfView = originalZoom;
                        gameObject.GetComponent<MeshRenderer>().enabled = true;
                        sniperCanvas.enabled = false;
                    }

                    StartCoroutine(aimGun(duration));
                }
            }
        }
    }

    private IEnumerator aimGun(float dur)
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
            if (isSniper)
            {
                sniperCamera.fieldOfView = cameraZoom;
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                sniperCanvas.enabled = true;
            }
        }

        isAim = !isAim;
        aiming = false;
    }
}
