using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(killMe());
    }

    private IEnumerator killMe()
    {
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);
    }
}
