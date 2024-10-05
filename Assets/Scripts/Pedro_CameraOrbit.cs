using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedro_CameraOrbit : MonoBehaviour
{
    public GameObject target;
    private void LateUpdate()
    {
        transform.position = target.transform.position;
    }
}
