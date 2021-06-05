using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public GameObject sun;

    private bool right;
    public float orbit;
    void Start()
    {
        right = false;
        
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, sun.transform.position) < orbit)
        {
            right = true;
        }
        if (right)
        {
            transform.RotateAround(sun.transform.position, Vector3.up, 20 * Time.deltaTime);
        }
    }
}
