﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowAimer : MonoBehaviour {

    [SerializeField] private Transform origPos;
    [SerializeField] private Transform aimPos;
    [SerializeField] private float duration = 1f;
    public bool canAim { get; set; }
    private bool isAim = false;
    private bool aiming = false;
    private float elapsed = 0f;
    private Vector3 moveDirection;

    private void Start()
    {
        transform.position = origPos.position;
        moveDirection = (aimPos.position - origPos.position);
    }

    // Update is called once per frame
    void Update () {
        if (canAim)
        {
            if (Input.GetMouseButtonDown(1) && !aiming)
            {
                if (!isAim)
                {
                    StartCoroutine(bowAimer(duration));
                }
                else
                {
                    StartCoroutine(bowAimer(duration));
                }
            }
        }
	}


    
    private IEnumerator bowAimer(float dur)
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
        isAim = !isAim;
        aiming = false;
    }
    
}