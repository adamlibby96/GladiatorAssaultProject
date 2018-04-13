using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenPathForGunSway : MonoBehaviour {

    public Color rayColor = Color.white;
    public List<Transform> path_objects = new List<Transform>();
    Transform[] theArray;

    void OnDrawGizmos()
    {
        Gizmos.color = rayColor;
        theArray = GetComponentsInChildren<Transform>();
        path_objects.Clear();

        foreach (Transform path_obj in theArray)
        {
            if (path_obj != this.transform)
            {
                path_objects.Add(path_obj);
            }
        }

        for (int i = 0; i < path_objects.Count; i++)
        {
            Vector3 position = path_objects[i].position;
            if (i > 0)
            {
                Vector3 previous = path_objects[i - 1].position;
                Gizmos.DrawLine(previous, position);
               // Gizmos.DrawWireSphere(position, 0.2f);
            }
        }
    }
}
