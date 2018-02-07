using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{





    public GameObject Cube;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - Cube.transform.position;

    }

    void LateUpdate()
    {
        transform.position = Cube.transform.position + offset;
    }
}


