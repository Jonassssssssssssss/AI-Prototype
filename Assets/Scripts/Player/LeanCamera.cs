using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanCamera : MonoBehaviour
{
    [SerializeField] Transform _left;
    [SerializeField] Transform _right;
    [SerializeField] Transform _center;

    void Update()
    {
        if (Input.GetKey("e")) SetNewCameraPosition(_right);
        else if (Input.GetKey("q")) SetNewCameraPosition(_left);
        else SetNewCameraPosition(_center);
    }

    void SetNewCameraPosition(Transform t)
    {
        transform.position = t.position;
    }
}
