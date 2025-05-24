using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class cameraConfiner : MonoBehaviour
{
    private CinemachineConfiner2D camConfiner;
    private PolygonCollider2D polygonCollider;

    private void Awake()
    {
        camConfiner = GetComponent<CinemachineConfiner2D>();
        polygonCollider = GameObject.FindGameObjectWithTag("CamConfiner").GetComponent<PolygonCollider2D>(); 

        if(polygonCollider != null)
        {
            camConfiner.m_BoundingShape2D = polygonCollider;
        }
    }
}
