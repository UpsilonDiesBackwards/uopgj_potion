using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Transform robot;
    Vector3 cursor;
    Vector3 target;
    float mod;

    void Start()
    {
        mod = 7;
    }

    void FixedUpdate()
    {
        cursor = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        target = cursor;

        transform.position = robot.position + ((target - robot.position) / mod);
    }
}
