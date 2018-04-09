using System.Collections;
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
                    StartCoroutine(bowAimer(transform.position, aimPos.position, duration));
                }
                else
                {
                    StartCoroutine(bowAimer(transform.position, origPos.position, duration));
                }
            }
        }
	}


    
    private IEnumerator bowAimer(Vector3 start, Vector3 end, float dur)
    {
        aiming = true;
        float elapsed = 0f;
        while (elapsed <= dur)
        {
            float pct = elapsed / dur;
            transform.position = Vector3.Lerp(start, end, pct);
            elapsed += Time.deltaTime;
            yield return null;
        }
        isAim = !isAim;
        aiming = false;
    }
    
}
