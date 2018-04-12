using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARAimer : MonoBehaviour {

    [SerializeField] private Transform origPos;
    [SerializeField] private Transform aimPos;
    [SerializeField] private float duration = 1f;
    public bool canAim { get; set; }
    private bool isAim = false;
    private bool aiming = false;

    private void Start()
    {
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
                    StartCoroutine(arAimer(duration));
                }
                else
                {
                    StartCoroutine(arAimer(duration));
                }
            }
        }
    }

    private IEnumerator arAimer(float dur)
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
        }

        isAim = !isAim;
        aiming = false;
    }
}
