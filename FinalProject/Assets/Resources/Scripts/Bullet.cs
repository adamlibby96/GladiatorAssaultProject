using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float speed = 50f;
   // private int stepsPerFrame = 6;
   // private Vector3 bulletVelocity;
    private bool canFire = false;
    //private Vector3 gravity = new Vector3(0, -18f, 0);

    // Use this for initialization
    void Start()
    {
        //bulletVelocity = transform.forward * speed;
    }

    void Update()
    {
        
    }

    public void setSpeed(float s)
    {
        speed = s;
    }

    // old code
    /**

    float stepSize = 1f / stepsPerFrame;
    Vector3 pointA = transform.position;
        for (float step = 0; step< 1; step += stepSize)
        {
            bulletVelocity += gravity* stepSize * Time.deltaTime; // this is where you would add all the bullet physics
            Vector3 pointB = pointA + bulletVelocity * stepSize * Time.deltaTime;

    Ray ray = new Ray(pointA, pointB - pointA);
            if (Physics.Raycast(ray, (pointB - pointA).magnitude))
            {
                Debug.Log("Hit");
                Destroy(this.gameObject);
}
pointA = pointB;
        }
        transform.position = pointA;


    // debugging only
    private void OnDrawGizmos()
    {
        bulletVelocity = transform.forward * speed;
        float stepSize = 0.01f;
        Gizmos.color = Color.red;
        Vector3 predictedBulletVelocity = bulletVelocity;
        Vector3 pointA = transform.position;
        for (float step = 0; step < 1; step += stepSize)
        {
            predictedBulletVelocity += Physics.gravity * stepSize;
            Vector3 pointB = pointA + predictedBulletVelocity * stepSize;
            Gizmos.DrawLine(pointA, pointB);
            pointA = pointB;
        }
    }
    **/
}
