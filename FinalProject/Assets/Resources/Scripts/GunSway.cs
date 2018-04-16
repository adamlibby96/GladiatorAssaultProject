using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSway : MonoBehaviour {
    private Vector3 originalPosition;
    private bool swayed = false;
    private bool canSway = false; 

	// Use this for initialization
	void Start () {
        originalPosition = transform.position;
        canSway = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (canSway)
        {
            StartCoroutine(sway(2));
        }
        else if (swayed)
        {
            StartCoroutine(swayBack(2));
        }

    }

    private IEnumerator swayBack(float duration)
    {
        canSway = false;
        float elapsed = 0f;

        while (elapsed <= duration)
        {
            float pct = elapsed / (duration);
            transform.position = Vector3.Lerp(transform.position, originalPosition, pct);
            elapsed += Time.deltaTime;
            yield return null;

            //if (Vector3.Distance(transform.position, originalPosition) < 0.001)
            //{
            //    break;
            //}
        }

        transform.position = originalPosition;
        swayed = false;
        canSway = true;
    }

    private IEnumerator sway(float duration)
    {
        canSway = false;

        float randX = Random.Range(transform.position.x -0.1f, transform.position.x + 0.1f);
        float randY = Random.Range(transform.position.y - 0.1f, transform.position.y + 0.1f);
        Vector3 newPos = new Vector3(randX, randY, transform.position.z);
        float elapsed = 0f;

        while (elapsed <= duration)
        {
            float pct = elapsed / (duration);
            transform.position = Vector3.Lerp(transform.position, newPos, pct);
            elapsed += Time.deltaTime;
            yield return null;
            //if (Vector3.Distance(transform.position, newPos) < 0.001)
            //{
            //    break;
            //}
        }

        transform.position = newPos;
        swayed = true;
        canSway = false;
    }
}
