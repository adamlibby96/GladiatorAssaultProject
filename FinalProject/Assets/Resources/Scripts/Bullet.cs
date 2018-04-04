using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed = 500.0f;
    [SerializeField] private int stepsPerFrame = 6;
    [SerializeField] private Vector3 bulletVelocity;
    private bool canFire = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!canFire)
        {
            bulletVelocity = transform.forward * speed;
        }

        if (canFire)
        {

            float stepSize = 1f / stepsPerFrame;
            Vector3 pointA = transform.position;

            for (float step = 0; step < 1; step += stepSize)
            {
                bulletVelocity += Physics.gravity * stepSize * Time.deltaTime; // this is where you would add all the bullet physics
                Vector3 pointB = pointA + bulletVelocity * stepSize * Time.deltaTime;

                Ray ray = new Ray(pointA, pointB - pointA);
                if (Physics.Raycast(ray, (pointB - pointA).magnitude))
                {
                    Debug.Log("Hit");
                }


                pointA = pointB;
            }
            transform.position = pointA;

        }
    }

    public void fire()
    {
        canFire = true;
    }

    public void setSpeed(float s)
    {
        speed = s;
    }

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
}
