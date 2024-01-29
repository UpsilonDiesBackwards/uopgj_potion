using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    float zoomLevel = 20f;
    [SerializeField] CinemachineVirtualCamera cameraVar;
    [SerializeField] Transform playerTrans;


    void Update()
    {
        zoomLevel -= Input.GetAxis("Mouse ScrollWheel") * zoomLevel * 2;

        if (zoomLevel < 1f ) { zoomLevel = 1f; }
        if (zoomLevel > 8192f ) { zoomLevel = 8192f; }

        cameraVar.m_Lens.OrthographicSize = zoomLevel;

        //cameraVar.m_Lens.Dutch = playerTrans.eulerAngles.z;
    }
}